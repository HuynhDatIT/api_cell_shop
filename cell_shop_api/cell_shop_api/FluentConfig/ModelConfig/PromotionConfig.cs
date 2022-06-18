using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class PromotionConfig
    {
        public static void PromotionFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Promotion>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
