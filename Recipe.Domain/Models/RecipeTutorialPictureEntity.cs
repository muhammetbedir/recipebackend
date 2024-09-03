namespace Recipe.Domain.Models
{
    public class RecipeTutorialPictureEntity : BaseEntity
    {
        public Guid? RecipeId { get; set; }
        public RecipeEntity Recipe { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }
}
