namespace Recipe.Domain.Models
{
    public class BookEntity : BaseEntity
    {
        public Guid? RecipeId { get; set; }
        public RecipeEntity Recipe {  get; set; } 
        public Guid? UserId { get; set; }
        public UserEntity User { get; set; }
    }
}