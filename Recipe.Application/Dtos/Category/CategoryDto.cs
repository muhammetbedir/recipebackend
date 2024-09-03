using Recipe.Presentation.Dtos.Common;

namespace Recipe.Presentation.Dtos.Category
{
    public class CategoryDto : BaseResponse
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
