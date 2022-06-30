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

        public async Task<bool> AddAsync(CreateCategorie createCategorie)
        {
            var categorie = await _unitOfWork.CategorieRepository
                                       .GetCategorieByName(createCategorie.Name);

            if (categorie != null)
                return false;
            else
            {
                var categorienew = _mapper.Map<Categorie>(createCategorie);

                await _unitOfWork.CategorieRepository.AddAsync(categorie);

                return _unitOfWork.SaveChanges() > 0;
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
        public async Task<bool> UpdateAsync(GetCategorie getCategorie)
        {
            var categorie = await _unitOfWork.CategorieRepository.GetByIdAsync(getCategorie.Id);

            if (categorie == null)
                return false;

            categorie.Name = getCategorie.Name;

            _unitOfWork.CategorieRepository.Update(categorie);

            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
