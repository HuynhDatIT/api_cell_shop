﻿using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class AddresseConfig
    {
        public static void AddresseFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresse>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Addresse>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}