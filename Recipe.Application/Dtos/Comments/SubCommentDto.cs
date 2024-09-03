using Recipe.Application.Dtos.User;
using Recipe.Domain.Models;
using Recipe.Presentation.Dtos.Common;

namespace Recipe.Application.Dtos.Comments
{
    public class SubCommentDto : BaseResponse
    {
        public Guid? Id { get; set; }
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public Guid? RecipeId { get; set; }
        public Guid? ParentComentId { get; set; }
        public UserDto User { get; set; }
        public bool IsLiked { get; set; }
        public int LikeCount { get; set; }
    }
}
