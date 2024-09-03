using MediatR;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Queries.Recipe
{
    public class GetRecipeByUserIdQuery : IRequest<List<GetAllRecipesDto>>
    {
        public Guid? UserId { get; set; }
        public Guid? ProfileId { get; set; }
    }
}
