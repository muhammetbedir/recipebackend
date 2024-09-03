using MediatR;

namespace Recipe.Application.Features.Commands.Follow
{
    public class FollowCommand : IRequest
    {
        public Guid? FollowerId { get; set; }
        public Guid? FollowedId { get; set; }
    }
}
