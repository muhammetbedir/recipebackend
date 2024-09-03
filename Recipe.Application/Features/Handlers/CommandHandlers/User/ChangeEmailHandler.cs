using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Features.Commands.User;
using Recipe.Common.Exceptions;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.User
{
    public class ChangeEmailHandler : IRequestHandler<ChangeEmailCommand>
    {
        private readonly UserManager<UserEntity> _userManager;

        public ChangeEmailHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                throw new RecipeException("Kullanıcı bulunamadı daha sonra tekrar deneyin.",400);
            }
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordCorrect)
            {
                throw new RecipeException("Şifre yanlış.", 400);
            }
            await _userManager.SetEmailAsync(user, request.Email);
        }
    }
}
