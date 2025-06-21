using System.Linq.Expressions;

namespace SalesInvoice.Data.Contract
{
    public interface IDataContext
    {
        Task<bool> DeleteAsync<TModel>(TModel entity)
            where TModel : class;

        Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            where TModel : class;

        Task<IEnumerable<TModel>> GetAllByPredicateAsync<TModel>(Expression<Func<TModel, bool>> predicate)
              where TModel : class;

        ValueTask<TModel?> GetByIdAsync<TModel>(object? id)
            where TModel : class;

        Task<bool> InsertAsync<TModel>(TModel entity)
            where TModel : class;

        Task<bool> UpdateAsync<TModel>(TModel entity)
            where TModel : class;
    }
}
