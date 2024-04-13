using MediatR;

namespace GymManager.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int PlanId { get; set; }
    }
}
