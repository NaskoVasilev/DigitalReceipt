namespace DigitalReceipt.Data.Models
{
    public class CashierCompany
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string CashierId { get; set; }
        public User Cashier { get; set; }
    }
}
