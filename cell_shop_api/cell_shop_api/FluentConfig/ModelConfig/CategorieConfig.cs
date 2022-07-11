using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class CategorieConfig
    {
        public static void CategorieFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>().HasKey(x => x.Id);
            modelBuilder.Entity<Categorie>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Categorie>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
