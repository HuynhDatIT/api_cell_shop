﻿using cell_shop_api.Repository;
using cell_shop_api.Repository.InheritRepository.Interface;
using cell_shop_api.Repository.Interface;
using cell_shop_api.Unit_Of_Work;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace CellShop_Api.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CellShopDbContext _dbContext;
        private IModelProductRepository modelProductRepository;
        private IProductRepository productRepository;
        private ICategorieRepository categorieRepository;
        private IBrandRepository brandRepository;
        private ICartRepository cartRepository;
        private IProductImageRepository productImageRepository;
        private IAccountRepository accountRepository;
        private IInvoiceRepository invoiceRepository;
        private IInvoiceDetailRepository invoiceDetailRepository;
        private IWishListRepository wishListRepository;
        private IRoleRepository roleRepository;
        public UnitOfWork(CellShopDbContext dbContext)
        {
            _dbContext = dbContext;
            modelProductRepository = new ModelProductRepository(_dbContext);
            productRepository = new ProductRepository(_dbContext);
            categorieRepository = new CategorieRepository(_dbContext);
            brandRepository = new BrandRepository(_dbContext);
            cartRepository = new CartRepository(_dbContext);
            productImageRepository = new ProductImageRepository(_dbContext);
            accountRepository = new AccountRepository(dbContext);
            invoiceRepository = new InvoiceRepository(dbContext);
            invoiceDetailRepository = new InvoiceDetailRepository(dbContext);
            wishListRepository = new WishListRepository(dbContext);
            roleRepository = new RoleRepository(dbContext);
        }

        public IModelProductRepository ModelProductRepository
        {
            get { return modelProductRepository; }
        }

        public IProductRepository ProductRepository
        {
            get { return productRepository; }
        }
        public ICategorieRepository CategorieRepository
        {
            get { return categorieRepository; }
        }

        public IBrandRepository BrandRepository
        {
            get { return brandRepository; }
        }

        public ICartRepository CartRepository
        {
            get { return cartRepository; }
        }

        public IProductImageRepository ProductImageRepository
        {
            get { return productImageRepository; }
        }

        public IAccountRepository AccountRepository
        {
            get { return accountRepository; }
        }

        public IInvoiceRepository InvoiceRepository
        {
            get { return invoiceRepository; }
        }

        public IInvoiceDetailRepository InvoiceDetailRepository
        {
            get { return invoiceDetailRepository; }
        }

        public IWishListRepository WishListRepository
        {
            get { return wishListRepository; }
        }

        public IRoleRepository RoleRepository
        {
            get { return roleRepository; }
        }
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

    }
}
