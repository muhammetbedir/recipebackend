namespace Recipe.Domain.Models
{
    public class CommentLikeEntity : BaseEntity
    {
        public Guid? UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid? CommentId { get; set; }
        public CommentEntity Comment { get; set; }
        public Guid? SubComentId { get; set; }
        public SubComentEntity SubComent { get; set; }
    }
}
