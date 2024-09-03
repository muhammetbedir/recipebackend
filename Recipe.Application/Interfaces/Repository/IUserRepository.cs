using Recipe.Domain.Models;

namespace Recipe.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        void Commit();
        Task CommitAsync();
        Task<UserEntity> getUserByUserName(string userName);
    }
}
