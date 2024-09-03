using MediatR;

namespace Recipe.Application.Features.Commands.User
{
    public class ChangePasswordCommand : IRequest
    {
        public Guid? UserId { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
