using Microsoft.EntityFrameworkCore;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence;

namespace Recipe.Persistence.Repository
{
    public class RecipeTutorialPictureRepository : GenericRepository<RecipeTutorialPictureEntity>, IRecipeTutorialPictureRepository
    {
        public RecipeTutorialPictureRepository(RecipeAppDbContext context) : base(context)
        {
        }
        public async Task<List<RecipeTutorialPictureEntity>> getAllRecipeTutorialPicturesByRecipeId(Guid? recipeId)
        {
            return await _context.RecipeTutorialPictures.Where(x=>x.RecipeId == recipeId).ToListAsync();
        }
    }
}
