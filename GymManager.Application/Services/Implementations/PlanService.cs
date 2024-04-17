using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;

namespace GymManager.Application.Services.Implementations
{
    public class PlanService : IPlanService
    {
        private readonly ICustomerRepository _customerRepository;

        public PlanService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool ValidPlanTime(List<PlanTime> planTimes, string requestStartTime, string requestEndTime)
        {
            TimeSpan newStartTime = TimeSpan.Parse(requestStartTime);
            TimeSpan newEndTime = TimeSpan.Parse(requestEndTime);

            foreach (var existingPlanTime in planTimes)
            {
                TimeSpan existingStartTime = TimeSpan.Parse(existingPlanTime.StartTime);
                TimeSpan existingEndTime = TimeSpan.Parse(existingPlanTime.EndTime);

                if ((newStartTime >= existingStartTime && newStartTime < existingEndTime) ||
                    (newEndTime > existingStartTime && newEndTime <= existingEndTime) ||
                    (newStartTime <= existingStartTime && newEndTime >= existingEndTime))
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<Customer> GetCustomerVerifyHasPlan(int customerId)
        {
            var customer = await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
                throw new Exception("Customer does not exist");
            if (customer.Plan == null)
                throw new Exception("Customer doest not have an active plan");

            return customer;
        }
    }
}
