using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById((int)request.Id);
            if (customer == null)
                return false;
            customer.Update(request.Name, request.PhoneNumber, request.Email, request.PlanId);
            await _customerRepository.UpdateAsync(customer);
            return true;
        }
    }
}
