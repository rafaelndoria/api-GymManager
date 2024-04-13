using MediatR;

namespace GymManager.Application.Commands.ActivateCustomer
{
    public class ActivateCustomerCommand : IRequest<bool>
    {
        public ActivateCustomerCommand(int id)
        {
            Id = Id;
        }
        public int Id { get; private set; }
    }
}
