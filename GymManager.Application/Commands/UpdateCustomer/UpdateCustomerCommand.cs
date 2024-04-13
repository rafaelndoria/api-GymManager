using MediatR;

namespace GymManager.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int PlanId { get; set; }
        public int? Id { get; set; }
    }
}
