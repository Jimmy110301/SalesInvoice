using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesInvoice.Models.Tables;

namespace SalesInvoice.Data.Data
{
    public class EfInvoiceItemMap : BaseEntityTypeConfiguration<InvoiceItem>
    {
        protected override void RegisterModel(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Invoice)
                .WithMany(s => s.InvoiceItems)
                .HasForeignKey(s => s.InvoiceId);

            builder.HasOne(s => s.Item)
                .WithMany(s => s.InvoiceItems)
                .HasForeignKey(s => s.ItemId);

            builder.ToTable("InvoiceItems");
        }
    }
}
