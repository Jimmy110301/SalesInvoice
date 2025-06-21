using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesInvoice.Models.Tables;

namespace SalesInvoice.Data.Data
{
    public class EfCategoryMap : BaseEntityTypeConfiguration<Category>
    {
        protected override void RegisterModel(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(s => s.Id);

            builder.ToTable("Category");
        }
    }
}
