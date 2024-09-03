using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Interfaces.Repository
{
    public interface IRecipeTutorialPictureRepository : IGenericRepository<RecipeTutorialPictureEntity>
    {
        Task<List<RecipeTutorialPictureEntity>> getAllRecipeTutorialPicturesByRecipeId(Guid? recipeId);
    }
}
