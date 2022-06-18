﻿using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class InvoiceConfig
    {
        public static void InvoiceFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Invoice>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
