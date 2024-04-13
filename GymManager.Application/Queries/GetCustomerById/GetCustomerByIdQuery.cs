using GymManager.Application.ViewModels;
using GymManager.Core.Entities;
using MediatR;

namespace GymManager.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerViewModel>
    {
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
