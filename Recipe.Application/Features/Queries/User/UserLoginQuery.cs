using MediatR;
using Recipe.Application.Dtos.User;

namespace Recipe.Application.Features.Queries.Auth
{
    public class UserLoginQuery : IRequest<LoginDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
