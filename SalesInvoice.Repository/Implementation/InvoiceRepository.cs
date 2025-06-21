using SalesInvoice.Data.Contract;
using SalesInvoice.Models.Tables;
using SalesInvoice.Repository.Contract;
using SalesInvoice.Repository.Core;

namespace SalesInvoice.Repository.Implementation
{
    internal class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
