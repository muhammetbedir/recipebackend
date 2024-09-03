using MediatR;
using Recipe.Domain.Models;

namespace Recipe.Application.Features.Commands.Comment
{
    public class AddSubCommentToRecipeCommand : IRequest
    {
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public Guid? RecipeId { get; set; }
        public Guid? ParentComentId { get; set; }
    }
}
