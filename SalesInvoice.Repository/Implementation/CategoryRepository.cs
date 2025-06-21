using SalesInvoice.Data.Implementation;
using SalesInvoice.Models.Tables;
using SalesInvoice.Repository.Contract;
using SalesInvoice.Repository.Core;

namespace SalesInvoice.Repository.Implementation
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
