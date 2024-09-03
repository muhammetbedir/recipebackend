using MediatR;

namespace Recipe.Application.Features.Commands.User
{
    public class ChangeEmailCommand : IRequest
    {
        public Guid? UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
