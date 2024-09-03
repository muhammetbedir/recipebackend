using Microsoft.AspNetCore.Identity;

namespace Recipe.Domain.Models
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }

        public ICollection<RecipeEntity> Recipes { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
        public ICollection<DailyMealListEntity> DailyMealList { get; set; }
        public ICollection<BookEntity> Books { get; set; }
        public ICollection<FollowEntity> Followers { get; set; }
        public ICollection<FollowEntity> Following { get; set; }
        public ICollection<CommentLikeEntity> CommentLikes { get; set; }
    }
}
