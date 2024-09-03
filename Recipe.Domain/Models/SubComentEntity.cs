namespace Recipe.Domain.Models
{
    public class SubComentEntity : BaseEntity
    {
        public string Content { get; set; }
        public Guid? UserId { get; set; }
        public Guid? RecipeId { get; set; }
        public Guid? ParentComentId { get; set; }
        public RecipeEntity Recipe { get; set; }
        public UserEntity User { get; set; }
        public CommentEntity ParentComent { get; set; }
        public ICollection<CommentLikeEntity> CommentLikes { get; set; }
    }
}
