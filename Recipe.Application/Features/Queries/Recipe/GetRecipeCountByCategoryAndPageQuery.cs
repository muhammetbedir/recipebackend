using MediatR;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Queries.Recipe
{
    public class GetRecipeCountByCategoryAndPageQuery : IRequest<int>
    {
        public string Name { get; set; }
    }
}
