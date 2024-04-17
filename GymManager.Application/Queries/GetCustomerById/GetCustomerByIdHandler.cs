using GymManager.Application.ViewModels;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerViewModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.Id);
            if (customer == null)
                return null;
            var customerViewModel = new CustomerViewModel(customer.Id, customer.Name, customer.PhoneNumber, customer.Email, customer.Cpf, customer.Active, customer.DateCreated);
            return customerViewModel;
        }
    }
}
