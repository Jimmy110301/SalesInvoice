using SalesInvoice.Data.Contract;
using SalesInvoice.Models.Core;
using System.Linq.Expressions;

namespace SalesInvoice.Repository.Core
{
    public class BaseRepository<TModel> : IBaseRepository<TModel>
        where TModel : BaseModel
    {
        private readonly IDataContext dataContext;

        public BaseRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Task<bool> DeleteAsync(TModel entity)
        {
            return dataContext.DeleteAsync(entity);
        }

        public Task<IEnumerable<TModel>> GetAllAsync()
        {
            return dataContext.GetAllAsync<TModel>();
        }

        public Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TModel, bool>> predicate)
        {
            return dataContext.GetAllByPredicateAsync(predicate);
        }

        public ValueTask<TModel?> GetAsync(object id)
        {
            return dataContext.GetByIdAsync<TModel>(id);
        }

        public Task<bool> InsertAsync(TModel entity)
        {
            return dataContext.InsertAsync(entity);
        }

        public Task<bool> UpdateAsync(TModel entity)
        {
            return dataContext.UpdateAsync(entity);
        }
    }
}