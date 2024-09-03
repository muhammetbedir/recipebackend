namespace Recipe.Domain.Models
{
    public class DailyMealRecipeEntity : BaseEntity
    {
        public Guid? RecipeId { get; set; }
        public RecipeEntity Recipe { get; set; }
        public Guid? DailyMealListId { get; set; }
        public DailyMealListEntity DailyMealList { get; set; }
    }
}
