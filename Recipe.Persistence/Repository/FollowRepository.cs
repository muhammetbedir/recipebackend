using Microsoft.EntityFrameworkCore;
using Recipe.Application.Interfaces.Repository;
using Recipe.Domain.Models;
using Recipe.Infrastructure.Persistence;

namespace Recipe.Persistence.Repository
{
    public class FollowRepository : GenericRepository<FollowEntity>, IFollowRepository
    {
        public FollowRepository(RecipeAppDbContext context) : base(context)
        {
        }
        public async Task<int> getFollowerCount(Guid? userId)
        {
            return await _context.Followers.Where(x => x.FollowedId == userId).CountAsync();
        }
        public async Task<int> getFollowedCount(Guid? userId)
        {
            return await _context.Followers.Where(x => x.FollowerId == userId).CountAsync();
        }

        public async Task<FollowEntity> getFollowByFollowedAndFollowerId(Guid? followerId, Guid? followedId)
        {
            return await _context.Followers.Where(x=>x.FollowerId==followerId&& x.FollowedId == followedId).FirstOrDefaultAsync();
        }
    }
}
