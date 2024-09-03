using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Application.Interfaces.Repository;
using Recipe.Application.Repository;
using Recipe.Infrastructure.Persistence;
using Recipe.Persistence.Repository;

namespace Recipe.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<RecipeAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnStr")));
            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IRecipeRepository, RecipeRepository>();
            serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IRecipeTutorialPictureRepository, RecipeTutorialPictureRepository>();
            serviceCollection.AddScoped<IFollowRepository, FollowRepository>();
            serviceCollection.AddScoped<ICommentLikeRepository, CommentLikeRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
