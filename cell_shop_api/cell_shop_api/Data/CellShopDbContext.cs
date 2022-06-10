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

            modelBuilder.Entity<Account>()
           .HasOne<Role>(a => a.Role)
           .WithMany(r => r.Accounts)
           .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<Log>()
          .HasOne<Account>(l => l.Account)
          .WithMany(a => a.Logs)
          .HasForeignKey(l => l.AccountId);

            modelBuilder.Entity<WishList>()
          .HasOne<Account>(w => w.Account)
          .WithMany(a => a.WishLists)
          .HasForeignKey(w => w.AccountId);

            modelBuilder.Entity<Addresse>()
         .HasOne<Account>(ar => ar.Account)
         .WithMany(a => a.Addresses)
         .HasForeignKey(a => a.AccountId);

            modelBuilder.Entity<Invoice>()
         .HasOne<Account>(w => w.Account)
         .WithMany(a => a.Invoices)
         .HasForeignKey(i => i.AccountId);

            modelBuilder.Entity<Review>()
         .HasOne<Account>(w => w.Account)
         .WithMany(a => a.Reviews)
         .HasForeignKey(r => r.AccountId);

            modelBuilder.Entity<Cart>()
         .HasOne<Account>(w => w.Account)
         .WithMany(a => a.Carts)
         .HasForeignKey(c => c.AccountId);

            modelBuilder.Entity<WishList>()
        .HasOne<Product>(w => w.Product)
        .WithMany(p => p.WishLists)
        .HasForeignKey(w => w.ProductId);

            modelBuilder.Entity<InvoiceDetail>()
       .HasOne<Invoice>(id => id.Invoice)
       .WithMany(i => i.InvoiceDetails)
       .HasForeignKey(id => id.InvoiceId);

            modelBuilder.Entity<Review>()
       .HasOne<Product>(r => r.Product)
       .WithMany(p => p.Reviews)
       .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<InvoiceDetail>()
       .HasOne<Product>(w => w.Product)
       .WithMany(p => p.InvoiceDetails)
       .HasForeignKey(a => a.ProductId);

            modelBuilder.Entity<BannerImage>()
       .HasOne<Product>(bi => bi.Product)
       .WithMany(p => p.BannerImages)
       .HasForeignKey(bi => bi.ProductId);

            modelBuilder.Entity<Cart>()
       .HasOne<Product>(c => c.Product)
       .WithMany(p => p.Carts)
       .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<Product>()
       .HasOne<ModelProduct>(p => p.ModelProduct)
       .WithMany(mp => mp.Products)
       .HasForeignKey(mp => mp.ModelProductId);

            modelBuilder.Entity<ProductImage>()
       .HasOne<Product>(pi => pi.Product)
       .WithMany(p => p.ProductImages)
       .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<ModelProduct>()
       .HasOne<Brand>(mp => mp.Brand)
       .WithMany(b => b.ModelProducts)
       .HasForeignKey(mp => mp.BrandId);

            modelBuilder.Entity<ModelProduct>()
       .HasOne<Categorie>(mp => mp.Categorie)
       .WithMany(c => c.ModelProducts)
       .HasForeignKey(mp => mp.CategorieId);

            modelBuilder.Entity<Brand>()
                .Property(b => b.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Brand>()
                .Property(b => b.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Categorie>()
                .Property(c => c.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Categorie>()
                .Property(c => c.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<ModelProduct>()
                .Property(mp => mp.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<ModelProduct>()
                .Property(mp => mp.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.Id).UseIdentityColumn(1, 1);
            modelBuilder.Entity<Product>()
                .Property(p => p.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Brand>().HasData(
                new BrandViewModel { Id = 1, Name = "Apple" },
                new BrandViewModel { Id = 2, Name = "SamSung" }
                );
            modelBuilder.Entity<Categorie>().HasData(
                new CategorieViewModel { Id = 1, Name = "Dien thoai" }
                );
            modelBuilder.Entity<ModelProduct>().HasData(
                new ModelProductViewModel
                {
                    Id = 1,
                    Name = "Iphone 12",
                    BrandId = 1,
                    CategorieId = 1,
                    Specification = "Man hinh Amoled, 16inch",
                    Description = "Dat"
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new ProductViewModel
                {
                    Id = 1,
                    Color = "Red",
                    Ram = 6,
                    Rom = 512,
                    Price = 25000000,
                    Stock = 10,
                    Rating = 4.5f,
                    ModelProductId = 1
                },
                new ProductViewModel
                {
                    Id = 2,
                    Color = "Black",
                    Ram = 6,
                    Rom = 512,
                    Price = 25000000,
                    Stock = 10,
                    Rating = 4.5f,
                    ModelProductId = 1
                }
                );

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
