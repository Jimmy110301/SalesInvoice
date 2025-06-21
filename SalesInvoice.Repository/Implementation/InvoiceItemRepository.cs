using SalesInvoice.Data.Contract;
using SalesInvoice.Models.Tables;
using SalesInvoice.Repository.Contract;
using SalesInvoice.Repository.Core;

namespace SalesInvoice.Repository.Implementation
{
    internal class InvoiceItemRepository : BaseRepository<InvoiceItem>, IInvoiceItemRepository
    {
        public InvoiceItemRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
