using GymManager.Core.Entities;

namespace GymManager.Core.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task UpdateAsync(User user);
        Task<User> GetByUserNameAndPasswordHashAsync(string username, string password);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
