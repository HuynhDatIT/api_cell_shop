using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class CartConfig
    {
        public static void CartFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().HasKey(x => x.Id);
            modelBuilder.Entity<Cart>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Cart>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
