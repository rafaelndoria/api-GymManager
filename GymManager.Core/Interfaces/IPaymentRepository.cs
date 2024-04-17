using GymManager.Core.Entities;

namespace GymManager.Core.Interfaces
{
    public interface IPaymentRepository 
    {
        Task CreateAsync(Payment payment);
    }
}
