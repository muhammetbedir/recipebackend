using Recipe.Application.Features.Queries.Comment;
using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Interfaces.Repository
{
    public interface ICommentRepository : IGenericRepository<CommentEntity>
    {
        Task<List<CommentEntity>> getRecipeCommentsByPage(GetRecipeCommentsByPageQuery request);
        Task<int> getCommentCountByRecipeId(Guid? recipeId);
        Task<List<CommentEntity>> getRecipeCommentByUserId(Guid? userId);
    }
}
