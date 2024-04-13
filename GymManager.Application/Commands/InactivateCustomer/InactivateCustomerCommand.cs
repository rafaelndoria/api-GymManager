using MediatR;

namespace GymManager.Application.Commands.InactivateCustomer
{
    public class InactivateCustomerCommand : IRequest<bool>
    {
        public InactivateCustomerCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
