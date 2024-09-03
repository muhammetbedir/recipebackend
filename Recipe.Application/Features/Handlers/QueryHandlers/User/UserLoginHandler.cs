using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Dtos.User;
using Recipe.Application.Features.Queries.Auth;
using Recipe.Common.Exceptions;
using Recipe.Common.Helpers;
using Recipe.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Auth
{
    public class UserLoginHandler : IRequestHandler<UserLoginQuery, LoginDto>
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserLoginHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<LoginDto> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetTokenHelper.GetToken(authClaims);
                return new LoginDto
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    Id = user.Id,
                    UserName = user.UserName,
                    Role = userRoles.Where(x => x == UserRoles.Admin).Any() ? "admin" : "standard",
                    ProfilePicture = user.ProfilePicture,
                };
            }
            throw new RecipeException("User not found.", 404);
        }
    }
}