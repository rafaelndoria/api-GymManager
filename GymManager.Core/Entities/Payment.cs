namespace GymManager.Core.Entities
{
    public class Payment : Entity
    {
        public Payment(double value, int typePaymentId, int customerId)
        {
            Value = value;
            TypePaymentId = typePaymentId;
            CustomerId = customerId;    

            DatePayment = DateTime.Now;
        }

        public DateTime DatePayment { get; private set; }
        public double Value { get; private set; }
        public int TypePaymentId { get; private set; }
        public int CustomerId { get; private set; }

        public Customer? Customer { get; set; }
        public TypePayment? TypePayment { get; set; }
    }
}
