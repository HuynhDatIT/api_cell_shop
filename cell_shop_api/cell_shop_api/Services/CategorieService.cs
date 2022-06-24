using AutoMapper;
using cell_shop_api.Helper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategorieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int Add(CreateCategorie createCategorie)
        {
            var isExist = _unitOfWork.CategorieRepository.IsNameExist(createCategorie.Name);

            if (isExist)
            {
                return 0;
            }
            else
            {
                var categorie = _mapper.Map<Categorie>(createCategorie);

                _unitOfWork.CategorieRepository.Add(categorie);

                return _unitOfWork.SaveChanges();
            }
        }

        public async Task<IEnumerable<GetCategorie>> GetAllAsync()
        {
            var listCategorie = await _unitOfWork.CategorieRepository.GetAllAsync();

            var listGetCategorie = _mapper.Map<IEnumerable<GetCategorie>>(listCategorie);

            return listGetCategorie;
        }

        public async Task<GetCategorie> GetByIdAsync(int id)
        {
            var categorie = await _unitOfWork.CategorieRepository.GetByIdAsync(id);

            var getCategorie = _mapper.Map<GetCategorie>(categorie);

            return getCategorie;
        }

        public async Task<int> Update(GetCategorie getCategorie)
        {
            var categorie = await _unitOfWork.CategorieRepository.GetByIdAsync(getCategorie.Id);

            if (categorie == null)
                return 0;
            
            categorie.Name = getCategorie.Name;

            _unitOfWork.CategorieRepository.Update(categorie);

            return _unitOfWork.SaveChanges();
        }
    }
}
