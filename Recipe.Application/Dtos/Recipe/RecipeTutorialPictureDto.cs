namespace Recipe.Application.Dtos.Recipe
{
    public class RecipeTutorialPictureDto
    {
        public Guid? Id { get; set; }
        public Guid? RecipeId { get; set; }
        public string ImageUrl { get; set; }
        public byte[]? ImageData { get; set; }
        public int Order { get; set; }
    }
}
