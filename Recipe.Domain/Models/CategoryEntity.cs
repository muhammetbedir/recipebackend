namespace Recipe.Domain.Models
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<RecipeEntity> Recipes { get; set; }
    }
}
