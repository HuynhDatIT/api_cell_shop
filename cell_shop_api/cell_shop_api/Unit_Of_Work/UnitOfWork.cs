using CellShop_Api.Data;
using CellShop_Api.Interface;
using CellShop_Api.Models;
using CellShop_Api.Repository;

namespace CellShop_Api.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CellShopDbContext _dbContext;
        private IGenericRepositoryCURD<ModelProduct> _modelProductRepository;
        private IGenericRepositoryCURD<Product> _productRepository;
        private IGenericRepositoryCURD<Categorie> _catogorieRepository;
        private IGenericRepositoryCURD<Brand> _brandRepository;
        public UnitOfWork(CellShopDbContext db)
        {
            _dbContext = db;
            _modelProductRepository = new GenericRepositoryCURD<ModelProduct>(_dbContext);
            _productRepository = new GenericRepositoryCURD<Product>(_dbContext);
            _catogorieRepository = new GenericRepositoryCURD<Categorie>(_dbContext);
            _brandRepository = new GenericRepositoryCURD<Brand>(_dbContext);
        }

        public IGenericRepositoryCURD<ModelProduct> ModelProductRepository
        {
            get { return _modelProductRepository; }
        }

        public IGenericRepositoryCURD<Product> ProductRepositoryCURD
        {
            get { return _productRepository; }
        }

        public IGenericRepositoryCURD<Categorie> CategorieRepositoryCURD
        {
            get { return _catogorieRepository; }
        }

        public IGenericRepositoryCURD<Brand> BrandRepositoryCURD
        {
            get { return _brandRepository; }
        }
        

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
