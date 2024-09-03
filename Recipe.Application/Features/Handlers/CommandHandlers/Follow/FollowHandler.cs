using MediatR;
using Recipe.Application.Features.Commands.Follow;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Follow
{
    public class FollowHandler : IRequestHandler<FollowCommand>
    {
        private readonly IFollowRepository _followRepository;

        public FollowHandler(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }

        public async Task Handle(FollowCommand request, CancellationToken cancellationToken)
        {
            var entity = new FollowEntity
            {
                FollowedId = request.FollowedId,
                FollowerId = request.FollowerId,
            };
            await _followRepository.InsertAsync(entity);
            await _followRepository.CommitAsync();
        }
    }
}
