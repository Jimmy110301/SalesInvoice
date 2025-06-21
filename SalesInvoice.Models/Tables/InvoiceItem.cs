using SalesInvoice.Models.Core;

namespace SalesInvoice.Models.Tables
{
    public class InvoiceItem : BaseModel
    {
        public Guid InvoiceId { get; set; }
        public Guid ItemId { get; set; }
        public int ItemQty { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal ItemAmount { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Item Item { get; set; }
    }
}
