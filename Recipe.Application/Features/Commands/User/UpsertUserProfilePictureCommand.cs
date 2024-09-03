using MediatR;

namespace Recipe.Application.Features.Commands.User
{
    public class UpsertUserProfilePictureCommand : IRequest<string>
    {
        public Guid? UserId { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
