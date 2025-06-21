using SalesInvoice.Models.Core;

namespace SalesInvoice.Models.Tables
{
    public class Category : BaseStatusModel
    {
        public string CategoryName { get; set; }

        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
