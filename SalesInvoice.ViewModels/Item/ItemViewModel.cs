using SalesInvoice.ViewModels.Core;

namespace SalesInvoice.ViewModels.Item
{
    public class ItemViewModel : BaseViewModel
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public decimal ItemUPrice { get; set; }
        public decimal ItemDiscountInPer { get; set; }
        public string ItemCombineName { get; set; }
    }
}
