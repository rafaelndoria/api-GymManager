using GymManager.Core.Entities;

namespace GymManager.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}
