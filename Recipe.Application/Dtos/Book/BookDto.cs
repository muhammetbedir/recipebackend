using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Dtos.Book
{
    public class BookDto : BaseResponse
    {
        public Guid? RecipeId { get; set; }
        public RecipeEntity Recipe { get; set; }
        public Guid? UserId { get; set; }
    }
}
