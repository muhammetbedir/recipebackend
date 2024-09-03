using Recipe.Application.Repository;
using Recipe.Domain.Models;

namespace Recipe.Application.Interfaces.Repository
{
    public interface IFollowRepository : IGenericRepository<FollowEntity>
    {
        Task<int> getFollowerCount(Guid? userId);
        Task<int> getFollowedCount(Guid? userId);
        Task<FollowEntity> getFollowByFollowedAndFollowerId(Guid? followerId, Guid? followedId);
    }
}
