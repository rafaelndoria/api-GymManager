using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetAllCustomers
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerViewModel>>
    {
    }
}
