using AutoMapper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class PromotionService : IPromotionService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PromotionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateLinkAsync(CreatePromotion createPromotion)
        {
            var promotion = _mapper.Map<Promotion>(createPromotion);
            await _unitOfWork.PromotionRepository.AddAsync(promotion);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
                return true;
            return false;
        }

        public async Task<bool> DeleteLinkAsync(int id)
        {
            var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(id);
            if (promotion == null)
                return false;
            _unitOfWork.PromotionRepository.Delete(promotion);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
                return true;
            return false;
        }

        public async Task<IEnumerable<GetPromotion>> GetAllAsync()
        {
            var listpromotion = await _unitOfWork.PromotionRepository.GetAllAsync();
            var listpromotionResult = _mapper.Map<IEnumerable<GetPromotion>>(listpromotion);

            return listpromotionResult;
        }

        public async Task<GetPromotion> GetByIdAsync(int id)
        {
            var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(id);

            var getPromotion = _mapper.Map<GetPromotion>(promotion);

            return getPromotion;
        }

        public async Task<bool> UpdateLinkAsync(UpdatePromotion updatePromotion)
        {
            var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(updatePromotion.Id);
            if (promotion == null)
                return false;

            promotion.Content = updatePromotion.Content;
            promotion.StartDate = updatePromotion.StartDate;
            promotion.EndDate = updatePromotion.EndDate;
            promotion.Discount = updatePromotion.Discount;
            promotion.Status = updatePromotion.Status;
            _unitOfWork.PromotionRepository.Update(promotion);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
                return true;
            return false;
        }
    }
}
