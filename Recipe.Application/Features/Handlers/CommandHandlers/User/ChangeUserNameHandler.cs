using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Features.Commands.User;
using Recipe.Common.Exceptions;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.User
{
    public class ChangeUserNameHandler : IRequestHandler<ChangeUserNameCommand>
    {
        private readonly UserManager<UserEntity> _userManager;

        public ChangeUserNameHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task Handle(ChangeUserNameCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                throw new RecipeException("Kullanıcı bulunamadı daha sonra tekrar deneyin.", 400);
            }
            await _userManager.SetUserNameAsync(user, request.UserName);
        }
    }
}
