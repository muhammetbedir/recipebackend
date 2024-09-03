using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Interfaces.Repository
{
    public interface ICommentLikeRepository : IGenericRepository<CommentLikeEntity>
    {
        Task<CommentLikeEntity> getCommentLikeByUserIdAndCommentId(Guid? commentId, Guid? userId, Guid? subCommentId);
    }
}
