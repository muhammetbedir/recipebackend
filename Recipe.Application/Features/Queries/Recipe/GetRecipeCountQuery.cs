using MediatR;

namespace Recipe.Application.Features.Queries.Recipe
{
    public class GetRecipeCountQuery : IRequest<int>
    {
    }
}
