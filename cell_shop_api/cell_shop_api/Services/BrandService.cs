using CellShop_Api.Interface;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Services
{
    public class BrandService : IGenericService<Brand>
    {
        private readonly IUnitOfWork UnitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<IList<Brand>> GetAll()
        {
            var listItem = await UnitOfWork.BrandRepositoryCURD.GetAll();

            return listItem;
        }

        public Task<Brand> GetById(int id)
        {
            var item = UnitOfWork.BrandRepositoryCURD.GetById(id);

            return item;
        }
    }
}
