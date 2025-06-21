using SalesInvoice.Models.Core;
using System.Linq.Expressions;

namespace SalesInvoice.Repository.Core
{
    public interface IBaseRepository<TModel>
        where TModel : BaseModel
    {
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> predicate);
        ValueTask<TModel?> GetAsync(object id);
        Task<bool> InsertAsync(TModel entity);
        Task<bool> UpdateAsync(TModel entity);
        Task<bool> DeleteAsync(TModel entity);
    }
}
