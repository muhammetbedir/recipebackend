using MediatR;

namespace Recipe.Application.Features.Commands.Comment
{
    public class AddCommentToRecipeCommand : IRequest
    {
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public Guid? RecipeId { get; set; }
    }
}
