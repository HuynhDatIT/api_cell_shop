using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class LogConfig
    {
        public static void LogFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().HasKey(x => x.Id);
            modelBuilder.Entity<Log>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Log>()
                .Property(b => b.Time)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
