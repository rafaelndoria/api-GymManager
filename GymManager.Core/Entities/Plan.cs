namespace GymManager.Core.Entities
{
    public class Plan : Entity
    {
        public Plan(string name, double price, int entriesPerDay, int planTypeId)
        {
            Name = name;
            Price = price;
            EntriesPerDay = entriesPerDay;
            PlanTypeId = planTypeId;

            DateCreated = DateTime.Now;
            Active = true;
            PlanTimes = new List<PlanTime>();
            Customers = new List<Customer>();
            Subscriptions = new List<Subscription>();
        }

        public string Name { get; private set; }
        public double Price { get; private set; }
        public int EntriesPerDay { get; private set; }
        public bool Active { get; private set; }
        public DateTime DateCreated { get; private set; }

        public int PlanTypeId { get; private set; }
        public PlanType? PlanType { get; private set; }
        public IEnumerable<PlanTime> PlanTimes { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }

        public void Activate()
        {
            Active = true;
        }

        public void Inactivate()
        {
            Active = false;
        }

        public void Update(string name, double price, int entriesPerDay, int planTypeId)
        {
            Name = name;
            Price = price;
            EntriesPerDay = entriesPerDay;
            PlanTypeId = planTypeId;
        }
    }
}
