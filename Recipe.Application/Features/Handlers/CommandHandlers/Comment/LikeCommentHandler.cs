using MediatR;
using Recipe.Application.Features.Commands.Comment;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Handlers.CommandHandlers.Comment
{
    public class LikeCommentHandler : IRequestHandler<LikeCommentCommand>
    {
        private readonly IGenericRepository<CommentLikeEntity> _commentLikeRepository;

        public LikeCommentHandler(IGenericRepository<CommentLikeEntity> commentLikeRepository)
        {
            _commentLikeRepository = commentLikeRepository;
        }

        public async Task Handle(LikeCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = new CommentLikeEntity
            {
                CommentId = request.CommentId,
                UserId = request.UserId,
                SubComentId = request.SubCommentId,
            };
            await _commentLikeRepository.InsertAsync(entity);
            await _commentLikeRepository.CommitAsync();
        }
    }
}
