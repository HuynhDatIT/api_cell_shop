using CellShop_Api.Interface;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Services
{
    public class ProductService : IGenericService<Product>
    {
        private IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<Product>> GetAll()
        {
            var list = await unitOfWork.ProductRepositoryCURD.GetAll();

            return list;
        }

        public async Task<Product> GetById(int id)
        {
            var item = await unitOfWork.ProductRepositoryCURD.GetById(id);
            return item;
        }
    }
}
