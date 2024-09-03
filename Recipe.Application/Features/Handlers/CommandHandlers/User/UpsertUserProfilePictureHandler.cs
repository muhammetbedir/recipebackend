using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipe.Application.Common.Helpers;
using Recipe.Application.Features.Commands.User;
using Recipe.Common.Exceptions;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.User
{
    public class UpsertUserProfilePictureHandler : IRequestHandler<UpsertUserProfilePictureCommand, string>
    {
        private readonly UserManager<UserEntity> _userManager;

        public UpsertUserProfilePictureHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(UpsertUserProfilePictureCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (request.ProfilePicture.Length > 0 && user != null)
            {
                user.ProfilePicture = await FileService.SaveImageAsync(request.ProfilePicture, $"user_{user.Id}.jpg", "users");
                await _userManager.UpdateAsync(user);
                return user.ProfilePicture;
            }
            throw new RecipeException("Hata", 400);
        }
    }
}
