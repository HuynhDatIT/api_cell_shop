using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class InvoiceDetailConfig
    {
        public static void InvoiceDetailFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>().HasKey(x => x.Id);
            modelBuilder.Entity<InvoiceDetail>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<InvoiceDetail>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
