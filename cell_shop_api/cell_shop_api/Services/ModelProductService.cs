using CellShop_Api.Interface;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Services
{
    public class ModelProductService : IGenericService<ModelProduct>
    {
        private readonly IUnitOfWork unitOfWork;

        public ModelProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<IList<ModelProduct>> GetAll()
        {
            var list = unitOfWork.ModelProductRepository.GetAll();
            return list;
        }

        public Task<ModelProduct> GetById(int id)
        {
           var item = unitOfWork.ModelProductRepository.GetById(id);
            return item;
        }
    }
}
