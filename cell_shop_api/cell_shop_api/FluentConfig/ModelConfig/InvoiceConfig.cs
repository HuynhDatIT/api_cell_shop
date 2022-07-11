using CellShop_Api.Enum;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class InvoiceConfig
    {
        public static void InvoiceFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().HasKey(x => x.Id);
            modelBuilder.Entity<Invoice>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Invoice>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
            modelBuilder.Entity<Invoice>()
                .Property(b => b.DateInvoice)
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Invoice>()
                .Property(b => b.Discount)
                .HasDefaultValue(0);
            modelBuilder.Entity<Invoice>()
               .Property(b => b.DeliveryStatus)
               .HasDefaultValue(DeliveryStatus.Order);
        }
    }
}
