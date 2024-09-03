using MediatR;
using Recipe.Application.Dtos.Recipe;

namespace Recipe.Application.Features.Commands.Recipe
{
    public class AddRecipeTutorialPicturesComand : IRequest
    {
        public List<RecipeTutorialPictureDto> Pictures { get; set; }
    }
}
