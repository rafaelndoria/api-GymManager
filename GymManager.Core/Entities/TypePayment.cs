namespace GymManager.Core.Entities
{
    public class TypePayment : Entity
    {
        public TypePayment(string name)
        {
            Name = name;
        }

        public TypePayment(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public IEnumerable<Payment> Payments { get; set; } = new List<Payment>();
    }
}
