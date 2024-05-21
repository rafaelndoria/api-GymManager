using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.EntryCustomer
{
    public class EntryCustomerHandler : IRequestHandler<EntryCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEntryService _entryService;

        public EntryCustomerHandler(ICustomerRepository customerRepository, IEntryService entryService)
        {
            _customerRepository = customerRepository;
            _entryService = entryService;
        }

        public async Task<Unit> Handle(EntryCustomerCommand request, CancellationToken cancellationToken)
        { 
            try
            {
                var customer = await _customerRepository.GetCustomerByCpf(request.Cpf);
                if (customer == null)
                    throw new Exception("Customer not registered in the system");

                if (customer.Subscription == null)
                    throw new Exception("Customer does not have an active subscription");
                customer.Subscription.VerifyAccess();

                if (customer.Subscription.Status != Core.Enum.EStatusSubscription.Active)
                {
                    await _customerRepository.UpdateAsync(customer);
                    throw new Exception("Customer is not active in the system");
                }

                var time = DateTime.Now.TimeOfDay.ToString();

                var entry = _entryService.IsExit(customer);
                if (entry != null)
                {
                    entry.SetTimeOn(time);
                    await _customerRepository.UpdateEntryAsync(entry);
                    return Unit.Value;
                }

                _entryService.VerifyEntryCustomer(customer);

                var newEntry = new Entry(DateTime.Now, time, customer.Id);

                await _customerRepository.CreateEntryAsync(entry);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Customer not allowed to enter: " + ex.Message);
            }
           
        }
    }
}
