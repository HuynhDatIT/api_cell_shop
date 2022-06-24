using cell_shop_api.Base.Interface;
using CellShop_Api.Models;

namespace cell_shop_api.Repository.InheritRepository.Interface
{
    public interface ICategorieRepository : IBaseRepository<Categorie>
    {
        bool IsNameExist(string name);
    }
}
