using MediatR;
using Recipe.Application.Features.Commands.Follow;
using Recipe.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Follow
{
    public class UnFollowHandler : IRequestHandler<UnFollowCommand>
    {
        private readonly IFollowRepository _followRepository;

        public UnFollowHandler(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }
        public async Task Handle(UnFollowCommand request, CancellationToken cancellationToken)
        {
           var follow =  await _followRepository.getFollowByFollowedAndFollowerId(request.FollowerId, request.FollowedId);
            if (follow != null)
            {
                await _followRepository.deleteAsync(follow);
                await _followRepository.CommitAsync();
            }
        }
    }
}
