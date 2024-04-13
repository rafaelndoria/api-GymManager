namespace GymManager.Core.Entities
{
    public class Customer : Entity
    {
        public Customer(string name, string phoneNumber, string email, string cpf, int planId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Cpf = cpf;
            PlanId = planId;

            DateCreated = DateTime.Now;
            Active = true;
            Subscriptions = new List<Subscription>();
            Entries = new List<Entry>();
        }

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Active { get; private set; }
        public DateTime DateCreated { get; private set; }

        public int PlanId { get; private set; }
        public Plan? Plan { get; private set; }
        public IEnumerable<Subscription> Subscriptions { get; private set; }
        public IEnumerable<Entry> Entries { get; private set; }

        public void Inactivate()
        {
            Active = false;
        }

        public void Activate()
        {
            Active = true;
        }

        public void Update(string name, string phoneNumber, string email, int planId)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            PlanId = planId;
        }
    }
}
