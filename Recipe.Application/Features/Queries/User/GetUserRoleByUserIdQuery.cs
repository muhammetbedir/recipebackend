using MediatR;

namespace Recipe.Application.Features.Queries.Auth
{
    public class GetUserRoleByUserIdQuery : IRequest<string>
    {
        public Guid? Id { get; set; }
    }
}
