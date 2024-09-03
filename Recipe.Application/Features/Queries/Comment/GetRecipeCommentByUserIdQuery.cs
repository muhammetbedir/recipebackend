using MediatR;
using Recipe.Application.Dtos.Comments;

namespace Recipe.Application.Features.Queries.Comment
{
    public class GetRecipeCommentByUserIdQuery : IRequest<List<CommentsWithRecipesDto>>
    {
        public Guid? UserId { get; set; }
    }
}
