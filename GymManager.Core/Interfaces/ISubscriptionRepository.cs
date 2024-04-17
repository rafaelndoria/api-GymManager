using GymManager.Core.Entities;

namespace GymManager.Core.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task CreateAsync(Subscription subscription);
        Task UpdateAsync(Subscription subscription);
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<Subscription> GetByIdAsync(int id);
    }
}
