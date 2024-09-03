using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Features.Commands.Auth;
using Recipe.Common.Exceptions;
using Recipe.Common.Helpers;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Auth
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public RegisterUserHandler(UserManager<UserEntity> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var userExists = await _userManager.FindByNameAsync(request.UserName);
            if (userExists != null)
                throw new RecipeException("Kullanıcı zaten mevcut!", 400);

            UserEntity user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName
            };
            var result = await _userManager.CreateAsync(user, request.Password);
         
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            if (!result.Succeeded)
                throw new RecipeException("Kullanıcı oluşturulamadı! Lütfen girmiş olduğunuz bilgilerin kurallara uygun olduğundan emin olunuz.", 400);
        }
    }
}
