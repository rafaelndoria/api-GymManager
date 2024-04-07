namespace GymManager.Application.ViewModels
{
    public class PlanDetailsViewModel
    {
        public PlanDetailsViewModel(int id, string name, double price, int entriesPerDay, bool active, DateTime dateCreated, string planTypeName, int periodInMonths)
        {
            Id = id;
            Name = name;
            Price = price;
            EntriesPerDay = entriesPerDay;
            Active = active;
            DateCreated = dateCreated;
            PlanTypeName = planTypeName;
            PeriodInMonths = periodInMonths;
            PlanTimes = new List<PlanTimeViewModel>();
            Subscriptions = new List<SubscriptionViewModel>();   
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int EntriesPerDay { get; private set; }
        public bool Active { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string PlanTypeName { get; private set; }
        public int PeriodInMonths { get; private set; }
        public List<PlanTimeViewModel> PlanTimes { get; private set; }
        public List<SubscriptionViewModel> Subscriptions { get; private set; }
    }
}
