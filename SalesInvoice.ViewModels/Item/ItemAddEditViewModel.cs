using SalesInvoice.ViewModels.Core;

namespace SalesInvoice.ViewModels.Item
{
    public class ItemAddEditViewModel : BaseViewModel
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Guid CategoryId { get; set; }
        public decimal ItemUPrice { get; set; }
        public decimal ItemDiscountInPer { get; set; }
    }
}
