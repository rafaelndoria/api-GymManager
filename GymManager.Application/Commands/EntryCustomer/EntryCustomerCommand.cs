using MediatR;

namespace GymManager.Application.Commands.EntryCustomer
{
    public class EntryCustomerCommand : IRequest<Unit>
    {
        public string Cpf { get; set; }
    }
}
