namespace GymManager.Core.Entities
{
    public class Payment : Entity
    {
        public Payment(DateTime datePayment, double value, int typePaymentId)
        {
            DatePayment = datePayment;
            Value = value;
            TypePaymentId = typePaymentId;
        }

        public DateTime DatePayment { get; private set; }
        public double Value { get; private set; }

        public int TypePaymentId { get; set; }
        public TypePayment? TypePayment { get; set; }
    }
}
