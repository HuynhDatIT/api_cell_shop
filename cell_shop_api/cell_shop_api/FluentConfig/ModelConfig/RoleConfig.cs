using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class RoleConfig
    {
        public static void RoleFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(x => x.Id);

            modelBuilder.Entity<Role>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Role>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
