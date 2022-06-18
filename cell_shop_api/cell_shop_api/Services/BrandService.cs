using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork UnitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            var listItem = await UnitOfWork.BrandRepository.GetAllAsync();

            return listItem;
        }
        public async Task<Brand> GetByIdAsync(int id)
        {
            var item = await UnitOfWork.BrandRepository.GetByIdAsync(id);

            return item;
        }
    }
}
