using GymManager.Core.Entities;

namespace GymManager.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByCpf(string cpf);
        Task CreateEntryAsync(Entry entry);
        Task UpdateEntryAsync(Entry entry);
    }
}
