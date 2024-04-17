using GymManager.Core.Enum;

namespace GymManager.Core.Entities
{
    public class Subscription : Entity
    {
        public Subscription(int customerId, int planId)
        {
            CustomerId = customerId;
            PlanId = planId;

            DateSubscription = DateTime.Now;
        }

        public DateTime DateSubscription { get; private set; }
        public EStatusSubscription Status { get; private set; }
        public DateTime? AccessPermittedUntil { get; private set; }

        public int CustomerId { get; private set; }
        public Customer? Customer { get; private set; }
        public int PlanId { get; private set; }
        public Plan? Plan { get; private set; }

        public void StartSubscription(int periodInMonths)
        {
            if (Status == EStatusSubscription.Active)
                throw new Exception("Subscription is active");
            AccessPermittedUntil = DateSubscription.AddMonths(periodInMonths);
            Status = EStatusSubscription.Active;
        }

        public void EndSubscription()
        {
            Status = EStatusSubscription.Blocked;
            AccessPermittedUntil = null;
        }

        public void ActiveSubscription()
        {
            if (Status != EStatusSubscription.Blocked)
                throw new Exception("Active subscription only when status is Blocked");

            Status = EStatusSubscription.Active;
        }

        public void BlockSubscription()
        {
            Status = EStatusSubscription.Blocked;
        }

        public void RenewSubscription(int periodInMonths)
        {
            DateTime dayNow = DateTime.Now;
            int addDaysSubscription = 0;

            if (AccessPermittedUntil != null && dayNow < AccessPermittedUntil)
            {
                DateTime dayAccess = (DateTime)AccessPermittedUntil;
                addDaysSubscription = (int)(dayAccess - dayNow).TotalDays;
            }

            AccessPermittedUntil = dayNow.AddDays(addDaysSubscription).AddMonths(periodInMonths);
            Status = EStatusSubscription.Active;
        }

        public void VerifyAccess()
        {
            if (AccessPermittedUntil == null)
                EndSubscription();

            if (DateTime.Now > AccessPermittedUntil)
                EndSubscription();
        }
    }
}
