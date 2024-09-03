using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recipe.Domain.Models;

namespace Recipe.Infrastructure.Persistence.Configuration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<RecipeEntity>
    {
        public void Configure(EntityTypeBuilder<RecipeEntity> builder)
        {
            builder
                .HasMany(x=>x.Comments)
                .WithOne(x=>x.Recipe)
                .HasForeignKey(x=>x.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
