using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain.Models;

namespace Recipe.Persistence.Configuration
{
    public class CommentLikeConfiguration : IEntityTypeConfiguration<CommentLikeEntity>
    {
        public void Configure(EntityTypeBuilder<CommentLikeEntity> builder)
        {
            builder.HasIndex(x => new { x.UserId, x.SubComentId, x.CommentId }).IsUnique();
            builder
                .HasOne(x=>x.Comment)
                .WithMany(x=>x.CommentLikes)
                .HasForeignKey(x=>x.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(x => x.SubComent)
               .WithMany(x => x.CommentLikes)
               .HasForeignKey(x => x.SubComentId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
