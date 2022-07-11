using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class WishListConfig
    {
        public static void WishListFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishList>().HasKey(x => x.Id);
            modelBuilder.Entity<WishList>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<WishList>()
               .Property(b => b.Status)
               .HasDefaultValue(true);
        }
    }
}
