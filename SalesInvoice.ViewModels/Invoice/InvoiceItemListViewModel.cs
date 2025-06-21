using SalesInvoice.ViewModels.Core;

namespace SalesInvoice.ViewModels.Invoice
{
    public class InvoiceItemListViewModel : BaseViewModel
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public int ItemQty { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public decimal ItemDiscount { get; set; }
        public decimal ItemAmount { get; set; }
        public string ItemCombineName { get; set; }
    }
}
