using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class ReviewConfig
    {
        public static void ReviewFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasKey(x => x.Id);
            modelBuilder.Entity<Review>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Review>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
