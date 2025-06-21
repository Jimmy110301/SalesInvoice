using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesInvoice.Models.Tables;

namespace SalesInvoice.Data.Data
{
    public class EfInvoiceMap : BaseEntityTypeConfiguration<Invoice>
    {
        protected override void RegisterModel(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(s => s.Id);

            builder.ToTable("Invoice");
        }
    }
}
