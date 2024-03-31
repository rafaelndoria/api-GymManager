namespace GymManager.Core.Entities
{
    public class PlanType : Entity
    {
        public PlanType(string name, int periodInMonths)
        {
            Name = name;
            PeriodInMonths = periodInMonths;
        }

        public PlanType(int id, string name, int periodInMonths)
        {
            Id = id;
            Name = name;
            PeriodInMonths = periodInMonths;
        }

        public string Name { get; private set; }
        public int PeriodInMonths { get; private set; }

        public IEnumerable<Plan> Plans { get; private set; } = new List<Plan>();
    }
}
