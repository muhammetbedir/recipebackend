using MediatR;
using Recipe.Application.Features.Commands.Comment;
using Recipe.Application.Interfaces.Repository;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Comment
{
    public class RemoveLikeFromCommentHandler : IRequestHandler<RemoveLikeFromCommentCommand>
    {
        private readonly ICommentLikeRepository _commentLikeRepository;

        public RemoveLikeFromCommentHandler(ICommentLikeRepository commentLikeRepository)
        {
            _commentLikeRepository = commentLikeRepository;
        }

        public async Task Handle(RemoveLikeFromCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _commentLikeRepository.getCommentLikeByUserIdAndCommentId(request.CommentId, request.UserId, request.SubCommentId);
            if (entity != null)
            {
                await _commentLikeRepository.deleteAsync(entity);
                await _commentLikeRepository.CommitAsync();
            }
        }
    }
}
