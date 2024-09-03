using Recipe.Application.Dtos.Recipe;

namespace Recipe.Application.Dtos.Comments
{
    public class CommentsWithRecipesDto : CommentDto
    {
        public GetRecipeByIdDto Recipe {  get; set; }
    }
}
