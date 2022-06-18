using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class LogConfig
    {
        public static void LogFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Log>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
