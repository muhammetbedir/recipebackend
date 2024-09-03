using Recipe.Application.Dtos.User;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Dtos.Comments
{
    public class CommentDto : BaseResponse
    {
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public UserDto User { get; set; }
        public List<SubCommentDto> SubComents { get; set; }
        public bool IsLiked { get; set; }
        public int LikeCount { get; set; }
    }
}
