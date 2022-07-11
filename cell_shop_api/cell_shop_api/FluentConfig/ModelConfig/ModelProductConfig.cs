using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace cell_shop_api.FluentConfig.ModelConfig
{
    public static class ModelProductConfig
    {
        public static void ModelProductFluent(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelProduct>().HasKey(x => x.Id);
            modelBuilder.Entity<ModelProduct>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<ModelProduct>()
                .Property(b => b.Status)
                .HasDefaultValue(true);
        }
    }
}
