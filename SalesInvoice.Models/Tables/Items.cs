using SalesInvoice.Models.Core;

namespace SalesInvoice.Models.Tables
{
    public class Item : BaseStatusModel
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Guid CategoryId { get; set; }
        public decimal ItemUPrice { get; set; }
        public decimal ItemDiscountInPer { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
