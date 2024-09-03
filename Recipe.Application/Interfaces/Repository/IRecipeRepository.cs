using Recipe.Application.Features.Queries.Recipe;
using Recipe.Domain.Models;

namespace Recipe.Application.Repository
{
    public interface IRecipeRepository : IGenericRepository<RecipeEntity>
    {
        Task<List<RecipeEntity>> getRecipesByPage(GetRecipesByPageQuery request);
        Task<RecipeEntity> getRecipesById(long id);
        Task<List<RecipeEntity>> getRecipesByCategoryAndPage(GetRecipesByCategoryAndPageQuery request);
        Task<List<RecipeEntity>> getPopularRecipesByPage(GetPopularRecipesByPageQuery request);
        Task<List<RecipeEntity>> getLatestRecipesByPage(GetLatestRecipesByPageQuery request);
        Task<int> getRecipeCountByCategoryAndPage(GetRecipeCountByCategoryAndPageQuery request);
        Task<int> getRecipeCount();
        Task<List<RecipeEntity>> getRecipesByUserId(Guid? userId);
        Task<List<RecipeEntity>> getBookedRecipesByUserId(Guid? userId);
        Task<List<RecipeEntity>> getWeeklyPopularRecipesByPage(GetWeeklyPopularRecipesByPageQuery request);
        List<RecipeEntity> getAllRecipes();
    }
}
