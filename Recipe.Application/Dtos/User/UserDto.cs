using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Dtos.User
{
    public class UserDto : BaseResponse
    {
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
    }
}
