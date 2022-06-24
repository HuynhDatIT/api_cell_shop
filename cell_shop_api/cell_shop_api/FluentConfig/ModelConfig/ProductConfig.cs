using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class ProductConfig
    {
        public static void ProductFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Product>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
            modelBuilder.Entity<Product>()
                .Property(b => b.Rating)
                .HasDefaultValue(0);
        }
    }
}
