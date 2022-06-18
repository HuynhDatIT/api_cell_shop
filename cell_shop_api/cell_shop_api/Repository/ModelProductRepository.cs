using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.InheritRepository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;

namespace cell_shop_api.Repository
{
    public class ModelProductRepository : BaseRepositoryCURD<ModelProduct>, IModelProductRepository
    {
        public ModelProductRepository(CellShopDbContext db) : base(db)
        {
        }
    }
}
