using MediatR;
using Recipe.Application.Dtos.Recipe;

namespace Recipe.Application.Features.Queries.Recipe
{
    public class GetRecipesByIdQuery : IRequest<GetRecipeByIdDto>
    {
        public long Id { get; set; }
        public Guid? UserId { get; set; }
    }
}
