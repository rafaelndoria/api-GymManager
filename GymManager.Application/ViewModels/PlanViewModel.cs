namespace GymManager.Application.ViewModels
{
    public class PlanViewModel
    {
        public PlanViewModel(int id, string name, double price, int entriePerDay, bool active, DateTime dateCreated)
        {
            Id = id;
            Name = name;
            Price = price;
            EntriePerDay = entriePerDay;
            Active = active;
            DateCreated = dateCreated;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int EntriePerDay { get; private set; }
        public bool Active { get; private set; }
        public DateTime DateCreated { get; private set; }
    }
}
