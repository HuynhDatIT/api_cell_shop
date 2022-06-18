using cell_shop_api.Repository.InheritRepository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;

namespace cell_shop_api.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        IModelProductRepository ModelProductRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategorieRepository CategorieRepository { get; }

        IBrandRepository BrandRepository { get; }
        void SaveChanges();

        void SaveChangesAsync();
    }
}
