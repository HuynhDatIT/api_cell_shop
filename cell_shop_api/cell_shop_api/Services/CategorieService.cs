using CellShop_Api.Interface;
using CellShop_Api.Interface.IServices;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Services
{
    public class CategorieService : IGenericService<Categorie>
    {
        private readonly IUnitOfWork UnitOfWork;

        public CategorieService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<IList<Categorie>> GetAll()
        {
           var listItem = await UnitOfWork.CategorieRepositoryCURD.GetAll();

            return listItem;
        }

        public Task<Categorie> GetById(int id)
        {
            var caregorieItem = UnitOfWork.CategorieRepositoryCURD.GetById(id);
            
            return caregorieItem;
        }
    }
}
