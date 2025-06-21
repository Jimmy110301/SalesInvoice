using SalesInvoice.Models.Tables;
using SalesInvoice.Repository.Core;

namespace SalesInvoice.Repository.Contract
{
    public interface IInvoiceItemRepository : IBaseRepository<InvoiceItem>
    {
    }
}
