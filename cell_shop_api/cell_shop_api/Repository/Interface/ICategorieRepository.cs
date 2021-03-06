using cell_shop_api.Base.Interface;
using CellShop_Api.Models;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.InheritRepository.Interface
{
    public interface ICategorieRepository : IBaseRepository<Categorie>
    {
        Task<Categorie> GetCategorieByName (string name);
    }
}
