using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.InactivateCustomer
{
    public class InactivateCustomerHandler : IRequestHandler<InactivateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public InactivateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(InactivateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.Id);
            if (customer == null)
                return false;
            customer.Inactivate();
            await _customerRepository.UpdateAsync(customer);
            return true;
        }
    }
}
