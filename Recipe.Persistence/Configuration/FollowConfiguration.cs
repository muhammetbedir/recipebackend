using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain.Models;

namespace Recipe.Persistence.Configuration
{
    public class FollowConfiguration : IEntityTypeConfiguration<FollowEntity>
    {
        public void Configure(EntityTypeBuilder<FollowEntity> builder)
        {
            builder.HasIndex(x => new { x.FollowerId, x.FollowedId}).IsUnique();
        }
    }
}
