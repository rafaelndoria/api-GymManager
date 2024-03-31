namespace GymManager.Core.Entities
{
    public class Entry : Entity
    {
        public Entry(DateTime date, string timeIn, int customerId)
        {
            Date = date;
            TimeIn = timeIn;
            CustomerId = customerId;
        }

        public DateTime Date { get; private set; }
        public string TimeIn { get; private set; }
        public string? TimeOn { get; private set; }

        public int CustomerId { get; private set; }
        public Customer? Customer { get; private set; }

        public void SetTimeOn(string timeOn)
        {
            ValidateEntry(timeOn);
            TimeOn = timeOn;
        }

        private void ValidateEntry(string timeOnInput)
        {
            try
            {
                if (!DateTime.TryParse(timeOnInput, out var timeOn))
                {
                    throw new Exception("Invalid time format");
                }

                var timeIn = DateTime.Parse(TimeIn);
                if (timeOn < timeIn)
                {
                    throw new Exception("TimeOn cannot be less than TimeIn");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Validation failed: " + ex.Message);
            }
        }
    }
}
