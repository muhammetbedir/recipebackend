using MediatR;

namespace Recipe.Application.Features.Queries.Comment
{
    public class GetRecipeCommentCountQuery : IRequest<int>
    {
        public Guid? RecipeId { get; set; }
    }
}
