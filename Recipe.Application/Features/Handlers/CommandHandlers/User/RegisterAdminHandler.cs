using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Features.Commands.Auth;
using Recipe.Common.Exceptions;
using Recipe.Common.Helpers;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Auth
{
    public class RegisterAdminHandler : IRequestHandler<RegisterAdminCommand>
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public RegisterAdminHandler(UserManager<UserEntity> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByNameAsync(request.UserName);
            if (userExists != null)
                throw new RecipeException("User already exists!", 400);

            UserEntity user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new RecipeException("User creation failed! Please check user details and try again.", 400);

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole<Guid>(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole<Guid>(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
        }
    }
}
