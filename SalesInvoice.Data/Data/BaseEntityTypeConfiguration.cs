using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesInvoice.Data.Data
{
    public abstract class BaseEntityTypeConfiguration<TModel> : IEntityTypeConfiguration<TModel>
        where TModel : class
    {
        protected abstract void RegisterModel(EntityTypeBuilder<TModel> builder);

        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            // INFO:: Register the extended functionality
            RegisterModel(builder);
        }
    }
}
