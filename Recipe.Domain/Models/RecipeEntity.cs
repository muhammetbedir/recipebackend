namespace Recipe.Domain.Models
{
    public class RecipeEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid UserId { get; set; }
        public CategoryEntity Category { get; set; }
        public UserEntity User { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<DailyMealRecipeEntity> DailyMealRecipes { get; set; }
        public ICollection<BookEntity> Books { get; set; }
        public ICollection<RecipeTutorialPictureEntity> RecipeTutorialPictures { get; set; }
    }
}
