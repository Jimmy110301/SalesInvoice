using SalesInvoice.ViewModels.Core;

namespace SalesInvoice.ViewModels.Invoice
{
    public class InvoiceListViewModel : BaseViewModel
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public string InvoiceCustomerName { get; set; }
        public string InvoiceCustomerNo { get; set; }
        public string InvoicePaymentMode { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal DiscountAmount { get; set; }
    }

    public class InvoiceViewModel : BaseViewModel
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDateTime { get; set; }
        public string InvoiceCustomerName { get; set; }
        public string InvoiceCustomerNo { get; set; }
        public int InvoicePaymentMode { get; set; }
        public decimal AmountPaid { get; set; }
        public List<InvoiceItemListViewModel> Items { get; set; } = new List<InvoiceItemListViewModel>();
    }
}
