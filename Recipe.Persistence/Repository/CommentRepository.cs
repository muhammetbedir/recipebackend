using Microsoft.EntityFrameworkCore;
using Recipe.Application.Features.Queries.Comment;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence;

namespace Recipe.Persistence.Repository
{
    public class CommentRepository : GenericRepository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(RecipeAppDbContext context) : base(context)
        {
        }
        public async Task<List<CommentEntity>> getRecipeCommentsByPage(GetRecipeCommentsByPageQuery request)
        {
            var data = _context.Comments
                .Where(x => x.RecipeId == request.RecipeId)
                .Skip(request.Count * request.Page)
                .Take(request.Count)
                .Include(x => x.User)
                .Include(x => x.CommentLikes)
                .Include(x => x.SubComents.OrderBy(x => x.CreateDate))
                    .ThenInclude(sub => sub.User)
                .Include(x => x.SubComents)
                    .ThenInclude(sub => sub.CommentLikes);

            return await data.ToListAsync();
        }
        public async Task<int> getCommentCountByRecipeId(Guid? recipeId)
        {
            var commentCount = await _context.Comments.Where(x => x.RecipeId == recipeId).CountAsync();
            var subCommentCount = await _context.SubComents.Where(x => x.RecipeId == recipeId).CountAsync();
            return commentCount + subCommentCount;
        }

        public async Task<List<CommentEntity>> getRecipeCommentByUserId(Guid? userId)
        {
            var data = _context.Comments.Where(x => x.Recipe.UserId == userId).OrderByDescending(x => x.CreateDate);
            await data.Include(x => x.User).LoadAsync();
            await data.Include(x => x.Recipe).LoadAsync();
            await data.Include(x => x.CommentLikes).LoadAsync();
            return await data.ToListAsync();
        }
    }
}
