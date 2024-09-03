using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Dtos.User
{
    public class UserProfileDto 
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int FollowerCount { get; set; }
        public int FollowedCount { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsFollowing { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string About { get; set; }
        public string PhoneNumber { get; set; }
    }
}
