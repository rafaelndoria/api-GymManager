using GymManager.Core.Entities;

namespace GymManager.Application.Services.Interfaces
{
    public interface IEntryService
    {
        void VerifyEntryCustomer(Customer customer);
        Entry IsExit(Customer customer);
    }
}
