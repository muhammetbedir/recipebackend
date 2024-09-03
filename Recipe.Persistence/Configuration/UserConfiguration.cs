using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain.Models;

namespace Recipe.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
               .HasMany(f => f.Followers)
               .WithOne(u => u.Followed)
               .HasForeignKey(f => f.FollowedId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(f => f.Following)
                .WithOne(u => u.Follower)
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
