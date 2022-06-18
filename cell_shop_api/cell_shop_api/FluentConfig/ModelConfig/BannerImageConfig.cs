using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class BannerImageConfig
    {
        public static void BannerFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Brand>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
