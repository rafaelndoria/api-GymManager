using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.ActivateCustomer
{
    public class ActivateCustomerHandler : IRequestHandler<ActivateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public ActivateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(ActivateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.Id);
            if (customer == null) 
                return false;
            customer.Activate();
            await _customerRepository.UpdateAsync(customer);
            return true;
        }
    }
}
