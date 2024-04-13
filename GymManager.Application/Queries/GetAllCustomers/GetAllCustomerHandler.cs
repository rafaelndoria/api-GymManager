using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetAllCustomers
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerViewModel>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerViewModel>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            if (customers == null)
                return null;
            var customersViewModel = customers.Select(x => new CustomerViewModel(x.Name, x.PhoneNumber, x.Email, x.Cpf, x.Active, x.DateCreated));
            return customersViewModel;
        }
    }
}
