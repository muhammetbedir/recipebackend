using MediatR;
using Recipe.Application.Dtos.User;

namespace Recipe.Application.Features.Queries.Auth
{
    public class GetUserByUserNameQuery : IRequest<UserProfileDto>
    {
        public string UserName { get; set; }
        public Guid? CurrentUserId { get; set; }
    }
}
