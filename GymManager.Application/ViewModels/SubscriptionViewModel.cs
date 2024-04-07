using GymManager.Core.Enum;

namespace GymManager.Application.ViewModels
{
    public class SubscriptionViewModel
    {
        public SubscriptionViewModel(int id, DateTime dateSubscription, EStatusSubscription status, DateTime accessPermittedUntil, string customerName, string customerPhoneNumber, string customerEmail)
        {
            Id = id;
            DateSubscription = dateSubscription;
            Status = status;
            AccessPermittedUntil = accessPermittedUntil;
            CustomerName = customerName;
            CustomerPhoneNumber = customerPhoneNumber;
            CustomerEmail = customerEmail;
        }

        public int Id { get; private set; }
        public DateTime DateSubscription { get; private set; }
        public EStatusSubscription Status { get; private set; }
        public DateTime AccessPermittedUntil { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerPhoneNumber { get; private set; }
        public string CustomerEmail { get; private set; }
    }
}
