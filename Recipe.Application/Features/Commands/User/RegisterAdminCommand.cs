using MediatR;

namespace Recipe.Application.Features.Commands.Auth
{
    public class RegisterAdminCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
