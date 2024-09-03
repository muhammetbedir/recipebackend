using Recipe.Application.Dtos.Comments;
using Recipe.Presentation.Dtos.Category;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Presentation.Dtos.Recipe
{
    public class GetAllRecipesDto : BaseResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTime { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid UserId { get; set; }
        public CategoryDto Category { get; set; }
        public bool IsBooked { get; set; }
        public Guid? BookId { get; set; }
        public int BookedCount { get; set; }
        public int CommentCount { get; set; }   
    }
}
