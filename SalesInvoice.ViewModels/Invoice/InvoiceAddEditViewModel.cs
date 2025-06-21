using SalesInvoice.ViewModels.Core;

namespace SalesInvoice.ViewModels.Invoice
{
    public class InvoiceAddEditViewModel : BaseViewModel
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public string InvoiceCustomerName { get; set; }
        public string InvoiceCustomerNo { get; set; }
        public int InvoicePaymentMode { get; set; }
        public decimal AmountPaid { get; set; }

        public List<InvoiceItemAddEditViewModel> Items { get; set; } = new List<InvoiceItemAddEditViewModel>();
    }

    public class InvoiceItemAddEditViewModel
    {
        public Guid ItemId { get; set; }
        public int ItemQty { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal ItemAmount { get; set; }  // If from frontend not passed then its consider
    }
}
