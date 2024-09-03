using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Features.Queries.Auth;
using Recipe.Common.Exceptions;
using Recipe.Common.Helpers;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.QueryHandlers.Auth
{
    public class GetUserRoleByUserIdHandler : IRequestHandler<GetUserRoleByUserIdQuery, string>
    {
        private readonly UserManager<UserEntity> _userManager;

        public GetUserRoleByUserIdHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> Handle(GetUserRoleByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                throw new RecipeException("Kullanıcı bulunamadı.", 401);
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.Where(x => x == UserRoles.Admin).Any() ? "admin" : "standard";
        }
    }
}
