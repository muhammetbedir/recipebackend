using Microsoft.EntityFrameworkCore;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence;

namespace Recipe.Persistence.Repository
{
    public class CommentLikeRepository : GenericRepository<CommentLikeEntity>, ICommentLikeRepository
    {
        public CommentLikeRepository(RecipeAppDbContext context) : base(context)
        {
        }
        public async Task<CommentLikeEntity> getCommentLikeByUserIdAndCommentId(Guid? commentId, Guid? userId, Guid? subCommentId)
        {
            return await _context.CommentLikes.Where(x=>(x.CommentId ==  commentId || x.SubComentId == subCommentId) && x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
