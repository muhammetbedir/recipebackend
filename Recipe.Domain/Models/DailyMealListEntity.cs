namespace Recipe.Domain.Models
{
    public class DailyMealListEntity  : BaseEntity
    {
        public Guid? UserId { get; set; }
        public int Amount { get; set; }
        public DateTime MealDate { get; set; }
        public UserEntity User { get; set; }
        public ICollection<DailyMealRecipeEntity> DailyMealRecipes { get; set; }
    }
}
