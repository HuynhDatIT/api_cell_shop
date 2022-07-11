using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class LinkConfig
    {
        public static void LinkFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>().HasKey(x => x.Id);
            modelBuilder.Entity<Link>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Link>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
