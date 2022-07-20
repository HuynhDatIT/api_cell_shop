using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class AccountConfig
    {
        public static void AccountFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(x => x.Id);
            modelBuilder.Entity<Account>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Account>()
                .Property(b => b.Email).IsRequired();
            modelBuilder.Entity<Account>()
                .Property(b => b.UserName).IsRequired();
            modelBuilder.Entity<Account>()
                .Property(b => b.PassWord).IsRequired();
            modelBuilder.Entity<Account>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
            modelBuilder.Entity<Account>()// defaul account la user
               .Property(b => b.RoleId)
               .HasDefaultValue(2);
        }
    }
}
