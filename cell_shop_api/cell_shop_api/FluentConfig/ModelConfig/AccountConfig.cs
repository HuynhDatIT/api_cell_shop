using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class AccountConfig
    {
        public static void AccountFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Account>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
