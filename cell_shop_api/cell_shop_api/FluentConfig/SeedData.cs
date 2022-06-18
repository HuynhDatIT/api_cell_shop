using CellShop_Api.Models;
using CellShop_Api.ViewModels;
using Microsoft.EntityFrameworkCore;
using Mini_project_API.Helper;

namespace cell_shop_api.FluentConfig
{
    public static class SeedData
    {
        public static void SeedAllData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie
                {
                    Id = 1,
                    Name = "Điện thoại"
                },
                 new Categorie
                 {
                     Id = 2,
                     Name = "Laptop"
                 }
                );
            modelBuilder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Apple"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Samsung"
                }
                );

            modelBuilder.Entity<ModelProduct>().HasData(
                new ModelProduct
               {
                   Id = 1,
                   Name = "Iphone 12",
                   BrandId = 1,
                   CategorieId = 1,
                   Specification = "{Màn hình: '12 inch'}",
                   Description = "Đây là mô tả của sp"
               },
                 new ModelProduct
                 {
                     Id = 2,
                     Name = "Note 21 Ultra",
                     BrandId = 2,
                     CategorieId = 1,
                     Specification = "{Màn hình: '12 inch'}",
                     Description = "Đây là mô tả của sp"
                 }
               );
            modelBuilder.Entity<Product>().HasData(
                new Product
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
                new Product
                {
                    Id = 2,
                    Color = "Black",
                    Ram = 6,
                    Rom = 512,
                    Price = 25000000,
                    Stock = 10,
                    Rating = 4.5f,
                    ModelProductId = 1
                },
                new Product
                {
                    Id = 1,
                    Color = "Red",
                    Ram = 6,
                    Rom = 512,
                    Price = 25000000,
                    Stock = 10,
                    Rating = 4.5f,
                    ModelProductId = 2
                },
                new Product
                {
                    Id = 3,
                    Color = "Black",
                    Ram = 6,
                    Rom = 512,
                    Price = 25000000,
                    Stock = 10,
                    Rating = 4.5f,
                    ModelProductId = 2
                }
                );
            modelBuilder.Entity<Account>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "admin",
                },
                new Role
                {
                    Id = 2,
                    Name = "user",
                }
                );
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    UserName = "admin",
                    PassWord = "12345".HashMD5(),
                    RoleId = 1,
                    FullName = "Huynh Tan Dat",
                    Email = "admin@gmail.com",
                },
                new Account
                {
                    Id = 2,
                    UserName = "user1",
                    PassWord = "12345".HashMD5(),
                    RoleId = 2,
                    FullName = "Nguoi dung 1",
                    Email = "user1@gmail.com",
                },
                new Account
                {
                    Id = 3,
                    UserName = "user2",
                    PassWord = "12345".HashMD5(),
                    RoleId = 1,
                    FullName = "Huynh Tan Dat",
                    Email = "admin@gmail.com",
                }
                );
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    ProductId = 1,
                    AccountId = 2,
                    Quantity = 1
                },
                new Cart
                {
                    Id = 2,
                    ProductId = 2,
                    AccountId = 2,
                    Quantity = 1
                },
                new Cart
                {
                    Id = 1,
                    ProductId = 3,
                    AccountId = 2,
                    Quantity = 1
                }
                );
            modelBuilder.Entity<WishList>().HasData(
                new WishList
                {
                    Id = 1,
                    AccountId = 2,
                    ProductId= 1,
                },
                new WishList
                {
                    Id = 2,
                    AccountId = 3,
                    ProductId = 2,
                }
                );
        }
    }
}
