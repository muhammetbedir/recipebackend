using Recipe.Application.Dtos.Comments;
using Recipe.Application.Dtos.User;
using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Category;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Dtos.Recipe
{
    public class GetRecipeByIdDto : BaseResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public CategoryDto Category { get; set; }
        public bool IsBooked { get; set; }
        public List<RecipeTutorialPictureDto> RecipeTutorialPictures { get; set; }
        public Guid? BookId { get; set; }
        //public List<CommentDto> Comments { get; set; }
    }
}
