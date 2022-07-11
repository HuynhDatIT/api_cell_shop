using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class ProductImageConfig
    {
        public static void ProductImageFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>().HasKey(x => x.Id);
            modelBuilder.Entity<ProductImage>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<ProductImage>()
                 .Property(b => b.Status)
                 .HasDefaultValue(true);
        }
    }
}
