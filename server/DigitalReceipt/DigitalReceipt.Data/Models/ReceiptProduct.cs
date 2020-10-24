namespace DigitalReceipt.Data.Models
{
    public class ReceiptProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }

        public int Quantity { get; set; }
    }
}
