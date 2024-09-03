namespace Recipe.Domain.Models
{
    public class FollowEntity : BaseEntity
    {
        public Guid? FollowerId { get; set; }
        public UserEntity Follower { get; set; }
        public Guid? FollowedId { get; set; }
        public UserEntity Followed { get; set; }
    }
}
