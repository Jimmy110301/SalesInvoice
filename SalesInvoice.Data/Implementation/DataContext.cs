using Microsoft.EntityFrameworkCore;
using SalesInvoice.Data.Contract;
using SalesInvoice.Data.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace SalesInvoice.Data.Implementation
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options), IDataContext
    {
        public async Task<bool> DeleteAsync<TModel>(TModel entity)
            where TModel : class
        {
            Set<TModel>().Remove(entity);
            return (await SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
            where TModel : class
        {
            return await Set<TModel>().ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllByPredicateAsync<TModel>(Expression<Func<TModel, bool>> predicate)
            where TModel : class
        {
            return await Set<TModel>().Where(predicate).ToListAsync();
        }

        public async ValueTask<TModel?> GetByIdAsync<TModel>(object? id)
            where TModel : class
        {
            return await FindAsync<TModel>(id);
        }

        public async Task<bool> InsertAsync<TModel>(TModel entity)
            where TModel : class
        {
            await Set<TModel>().AddAsync(entity);
            return (await SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateAsync<TModel>(TModel entity)
            where TModel : class
        {
            var entityEntry = Set<TModel>().Entry(entity);
            entityEntry.State = EntityState.Modified;
            return (await SaveChangesAsync()) > 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ModelRegisterHelper.RegisterModelMappings(GetType().Assembly, builder);
        }
    }
    public class ModelRegisterHelper
    {
        internal static void RegisterModelMappings(Assembly assembly, ModelBuilder builder)
        {
            var allConfigurationsForType = assembly.GetTypes().Where(type => type.IsClass && !type.IsAbstract && type.BaseType is { IsGenericType: true } &&
             type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityTypeConfiguration<>)).ToArray();
            builder.ApplyConfigurationsFromAssembly(assembly, t => allConfigurationsForType.Contains(t));
        }
    }
}
