using SalesInvoice.Data.Contract;
using SalesInvoice.Models.Tables;
using SalesInvoice.Repository.Contract;
using SalesInvoice.Repository.Core;

namespace SalesInvoice.Repository.Implementation
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(IDataContext dataContext) : base(dataContext)
        {
        }
    }
}
