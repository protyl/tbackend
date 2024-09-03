namespace api.Models
{   
    public enum PaymentMethod
    {
        CreditCard
    }

    public enum PaymentStatus
    {
        SUCCESS,
        PENDING,
        FAILED,
    }
    public class Payment
    {
        public string PaymentID { get; set; } = string.Empty;
        public string orderID { get; set; } = string.Empty;
        public double TotalPrice { get; set; }

        public DateTime ProcessingDate { get; set; }
        public PaymentMethod PaymentMethod{ get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}