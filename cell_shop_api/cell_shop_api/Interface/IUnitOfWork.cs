using CellShop_Api.Data;
using CellShop_Api.Models;

namespace CellShop_Api.Interface
{
    public interface IUnitOfWork
    {
       IGenericRepositoryCURD<ModelProduct> ModelProductRepository { get; }
        IGenericRepositoryCURD<Product> ProductRepositoryCURD { get; }
        IGenericRepositoryCURD<Categorie> CategorieRepositoryCURD { get; }

        IGenericRepositoryCURD<Brand> BrandRepositoryCURD { get; }
        void SaveChanges();

        void SaveChangesAsync();
    }
}
