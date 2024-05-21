using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using GymManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task CreateEntryAsync(Entry entry)
        {
            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByCpf(string cpf)
        {
            return await _context.Customers.
                Include(x => x.Subscription)
                .Include(x => x.Plan)
                    .ThenInclude(x => x.PlanType)
                .Include(x => x.Plan)
                    .ThenInclude(x => x.PlanTimes)
                .Include(x => x.Entries)
                .FirstOrDefaultAsync(x => x.Cpf == cpf);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers
                .Include(x => x.Plan)
                    .ThenInclude(x => x.PlanType)
                .Include(x => x.Subscription)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntryAsync(Entry entry)
        {
            _context.Entries.Update(entry);
            await _context.SaveChangesAsync();
        }
    }
}
