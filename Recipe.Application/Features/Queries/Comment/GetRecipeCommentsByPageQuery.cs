using MediatR;
using Recipe.Application.Dtos.Comments;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Features.Queries.Comment
{
    public class GetRecipeCommentsByPageQuery : PaginationRequestDto, IRequest<List<CommentDto>>
    {
        public Guid? RecipeId { get; set; }
        public Guid? UserId { get; set; }
    }
}
