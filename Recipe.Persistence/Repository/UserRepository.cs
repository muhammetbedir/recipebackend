using Microsoft.EntityFrameworkCore;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence;

namespace Recipe.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly RecipeAppDbContext _context;
        public UserRepository(RecipeAppDbContext context)
        {
            _context = context;
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> getUserByUserName(string userName)
        {
            var data = _context.Users.Where(x => x.UserName == userName);
            await data.Include(x => x.Followers).LoadAsync();
            return await data.FirstOrDefaultAsync();
        }

    }
}
