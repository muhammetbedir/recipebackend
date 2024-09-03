namespace Recipe.Domain.Models
{
    public class CommentEntity : BaseEntity
    {
        public string Content { get; set; } 
        public Guid? UserId { get; set; }
        public Guid? RecipeId { get; set; }
        public RecipeEntity Recipe { get; set; }
        public UserEntity User { get; set; }
        public ICollection<SubComentEntity> SubComents { get; set; }
        public ICollection<CommentLikeEntity> CommentLikes { get; set; }
    }
}
