using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesInvoice.Models.Tables;

namespace SalesInvoice.Data.Data
{
    public class EfItemMap : BaseEntityTypeConfiguration<Item>
    {
        protected override void RegisterModel(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Category)
                .WithMany(s => s.Items)
                .HasForeignKey(s => s.CategoryId);

            builder.ToTable("Items");
        }
    }
}
