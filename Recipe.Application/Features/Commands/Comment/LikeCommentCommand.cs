using MediatR;

namespace Recipe.Application.Features.Commands.Comment
{
    public class LikeCommentCommand : IRequest
    {
        public Guid? CommentId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? SubCommentId { get; set; }
    }
}
