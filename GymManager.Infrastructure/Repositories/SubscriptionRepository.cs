using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using GymManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Infrastructure.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _context.Subscriptions.Include(x => x.Customer).ToListAsync();
        }

        public async Task<Subscription> GetByIdAsync(int id)
        {
            return await _context.Subscriptions.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
        }
    }
}
