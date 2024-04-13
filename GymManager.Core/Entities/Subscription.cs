using GymManager.Core.Enum;

namespace GymManager.Core.Entities
{
    public class Subscription : Entity
    {
        public Subscription(DateTime dateSubscription, int customerId, int planId)
        {
            DateSubscription = dateSubscription;
            CustomerId = customerId;
            PlanId = planId;
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

        public void UpdatePlan(int planId, int periodInMonths)
        {
            if (DateTime.Now < AccessPermittedUntil)
                throw new Exception("Only change plans when it ends");

            DateSubscription = DateTime.Now;
            PlanId = planId;
            AccessPermittedUntil = DateSubscription.AddMonths(periodInMonths);
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
