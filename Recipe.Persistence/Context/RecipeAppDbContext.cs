using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence.Configuration;
using Recipe.Common.Helpers;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Emit;

namespace Recipe.Infrastructure.Persistence
{
    public class RecipeAppDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
    {
        public RecipeAppDbContext(DbContextOptions<RecipeAppDbContext> options) : base(options)
        {
        }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<DailyMealListEntity> DailyMealLists { get; set; }
        public DbSet<DailyMealRecipeEntity> DailyMealRecipes { get; set; }
        public DbSet<RecipeEntity> Recipes { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<RecipeTutorialPictureEntity> RecipeTutorialPictures { get; set; }
        public DbSet<SubComentEntity> SubComents { get; set; }
        public DbSet<FollowEntity> Followers { get; set; }
        public DbSet<CommentLikeEntity> CommentLikes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(RecipeConfiguration).Assembly);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    builder.Entity(entityType.ClrType)
                                .Property(nameof(BaseEntity.VisibleId))
                                .ValueGeneratedOnAdd();
                    builder.Entity(entityType.ClrType)
                              .HasIndex(nameof(BaseEntity.VisibleId))
                              .IsUnique();
                }
            }
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            //var user = HttpContextHelper.GetUser()?.Claims.FirstOrDefault() != null ? new Guid(HttpContextHelper.GetUser()?.Claims?.FirstOrDefault(c => c.Type.Equals("id", StringComparison.OrdinalIgnoreCase))?.Value) : new Guid(ConfigurationHelper.config["systemAdmin"]);
            foreach (var item in ChangeTracker.Entries())
            {
                switch (item.Entity)
                {
                    case BaseEntity entityBase:
                        switch (item.State)
                        {
                            case EntityState.Detached:
                                break;
                            case EntityState.Unchanged:
                                break;
                            case EntityState.Deleted:
                                break;
                            case EntityState.Modified:
                                Entry(entityBase).Property(x => x.CreateDate).IsModified = false;
                                entityBase.UpdateDate = DateTime.UtcNow;
                                break;
                            case EntityState.Added:
                                entityBase.UpdateDate = DateTime.UtcNow;
                                entityBase.CreateDate = DateTime.UtcNow;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                switch (item.Entity)
                {
                    case BaseEntity entityBase:
                        switch (item.State)
                        {
                            case EntityState.Detached:
                                break;
                            case EntityState.Unchanged:
                                break;
                            case EntityState.Deleted:
                                break;
                            case EntityState.Modified:
                                Entry(entityBase).Property(x => x.CreateDate).IsModified = false;
                                Entry(entityBase).Property(x => x.VisibleId).IsModified = false;
                                entityBase.UpdateDate = DateTime.UtcNow;
                                break;
                            case EntityState.Added:
                                entityBase.UpdateDate = DateTime.UtcNow;
                                entityBase.CreateDate = DateTime.UtcNow;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
