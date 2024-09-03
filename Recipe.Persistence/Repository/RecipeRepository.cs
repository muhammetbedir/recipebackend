using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Recipe.Application.Features.Queries.Recipe;
using Recipe.Application.Repository;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Recipe.Persistence.Repository
{
    public class RecipeRepository : GenericRepository<RecipeEntity>, IRecipeRepository
    {
        public RecipeRepository(RecipeAppDbContext context) : base(context)
        {
        }

        public async Task<List<RecipeEntity>> getRecipesByPage(GetRecipesByPageQuery request)
        {
            var data = _context.Recipes.Skip(request.Page * request.Count).Take(request.Count);
            await data.Include(x => x.Category).LoadAsync();
            await data.Include(x => x.Books).LoadAsync();
            return await data.ToListAsync();
        }
        public async Task<int> getRecipeCount()
        {
            return await _context.Recipes.CountAsync();
        }
        public async Task<List<RecipeEntity>> getPopularRecipesByPage(GetPopularRecipesByPageQuery request)
        {
            var data = _context.Recipes.OrderByDescending(x => x.Books.Count).Skip(request.Page * request.Count).Take(request.Count);
            await data.Include(x => x.Category).LoadAsync();
            await data.Include(x => x.Books).LoadAsync();
            return await data.ToListAsync();
        }
        public async Task<List<RecipeEntity>> getWeeklyPopularRecipesByPage(GetWeeklyPopularRecipesByPageQuery request)
        {
            var oneWeekAgo = DateTime.UtcNow.AddDays(-7);

            var data = _context.Recipes
                .OrderByDescending(recipe => recipe.Books.Count(book => book.CreateDate >= oneWeekAgo))
            .Skip(request.Page * request.Count)
                .Take(request.Count);

            await data.Include(x => x.Category).LoadAsync();
            await data.Include(x => x.Books).LoadAsync();
            return await data.ToListAsync();
        }
        public async Task<List<RecipeEntity>> getLatestRecipesByPage(GetLatestRecipesByPageQuery request)
        {
            var data = _context.Recipes.OrderByDescending(x => x.CreateDate).Skip(request.Page * request.Count).Take(request.Count);
            await data.Include(x => x.Category).LoadAsync();
            await data.Include(x => x.Books).LoadAsync();
            return await data.ToListAsync();
        }

        public async Task<List<RecipeEntity>> getRecipesByUserId(Guid? userId)
        {
            var data = _context.Recipes.Where(x => x.UserId == userId).OrderByDescending(x => x.CreateDate);
            await data.Include(x => x.Category).LoadAsync();
            await data.Include(x => x.Books).LoadAsync();
            return await data.ToListAsync();
        }

        public async Task<List<RecipeEntity>> getBookedRecipesByUserId(Guid? userId)
        {
            var data = _context.Recipes.Where(x => x.Books.Where(x => x.UserId == userId).Any()).OrderByDescending(x => x.CreateDate);
            await data.Include(x => x.Category).LoadAsync();
            await data.Include(x => x.Books).LoadAsync();
            return await data.ToListAsync();
        }

        public async Task<List<RecipeEntity>> getRecipesByCategoryAndPage(GetRecipesByCategoryAndPageQuery request)
        {
            var data = _context.Recipes
                .Where(x => x.Category.Name == request.Name)
                .Skip(request.Page * request.Count)
                .Take(request.Count);
            await data.Include(x => x.Books).LoadAsync();
            await data.Include(x => x.Category).LoadAsync();
            return await data.ToListAsync();
        }
        public async Task<int> getRecipeCountByCategoryAndPage(GetRecipeCountByCategoryAndPageQuery request)
        {
            return await _context.Recipes
                .Where(x => x.Category.Name == request.Name).CountAsync();
        }

        public async Task<RecipeEntity> getRecipesById(long id)
        {
            var data = _context.Recipes.Where(x => x.VisibleId == id);
            await data.Include(x => x.Category).LoadAsync();
            await data.Include(x => x.User).LoadAsync();
            await data.Include(x => x.Books).LoadAsync();
            await data.Include(x => x.RecipeTutorialPictures).LoadAsync();
            return await data.FirstOrDefaultAsync();
        }
        public List<RecipeEntity> getAllRecipes()
        {
            var data = _context.Recipes;
            data.Include(x => x.Category).Load();
            data.Include(x => x.Books).Load();
            return data.ToList();
        }
    }
}
