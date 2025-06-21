using SalesInvoice.Models.Core;

namespace SalesInvoice.Models.Tables
{
    public class Invoice : BaseStatusModel
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public string InvoiceCustomerName { get; set; }
        public string InvoiceCustomerNo { get; set; }
        public int InvoicePaymentMode { get; set; }
        public decimal AmountPaid { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}
