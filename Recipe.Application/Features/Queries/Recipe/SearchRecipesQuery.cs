using MediatR;
using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Recipe;

namespace Recipe.Application.Features.Queries.Recipe
{
    public class SearchRecipesQuery : IRequest<List<GetAllRecipesDto>>
    {
        public string Query { get; set; }

        public SearchRecipesQuery(string query)
        {
            Query = query;
        }
    }
}
