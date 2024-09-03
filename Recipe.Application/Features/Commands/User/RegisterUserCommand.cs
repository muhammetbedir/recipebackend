using MediatR;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Features.Commands.Auth
{
    public class RegisterUserCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
