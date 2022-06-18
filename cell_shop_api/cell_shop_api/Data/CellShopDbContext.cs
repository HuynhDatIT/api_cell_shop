using CellShop_Api.Models;
using CellShop_Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CellShop_Api.Data
{
    public class CellShopDbContext : DbContext
    {
        public CellShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }




        #region DbSet<>
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Addresse> Addresses { get; set; }
        public DbSet<BannerImage> BannerImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<ModelProduct> modelProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<WishList> WishLists { get; set; }


        #endregion

    }
}
