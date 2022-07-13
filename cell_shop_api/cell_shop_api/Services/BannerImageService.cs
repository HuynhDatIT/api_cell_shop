using AutoMapper;
using cell_shop_api.Enum;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class BannerImageService : IBannerImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISaveImageService _saveImageService;

        public BannerImageService(IUnitOfWork unitOfWork, IMapper mapper, ISaveImageService saveImageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _saveImageService = saveImageService;
        }

        public async Task<bool> CreateBannerImageAnsyc(CreateBannerImage createBannerImage)
        {
            var banner = _mapper.Map<BannerImage>(createBannerImage);

            var path = await _saveImageService.SaveImageAsync(createBannerImage.File, TypeImage.ImageBanner);

            banner.Path = path;

            await _unitOfWork.BannerImageRepository.AddAsync(banner);
            
            return await _unitOfWork.SaveChangesAsync() > 0;
            

        }

        public async Task<bool> DelteBannerImageAnsyc(int bannerId)
        {
            var bannerImage = await _unitOfWork.BannerImageRepository.GetBannerImageById(bannerId);
            if (bannerImage == null) return false;
            _unitOfWork.BannerImageRepository.Delete(bannerImage);
            return await _unitOfWork.SaveChangesAsync()>0;

        }

        public async Task<IEnumerable<GetBannerImage>> GetAllBannerImageAsync()
        {
            var listBannerImage = await _unitOfWork.BannerImageRepository.GetAllAsync();
            var bannerImage = _mapper.Map<IEnumerable<GetBannerImage>>(listBannerImage);
            return bannerImage;
        }

        public async Task<bool> UpdateBannerImageAnsyc(UpdateBannerImage updateBannerImage)
        {
            var bannerUpdate = _mapper.Map<BannerImage>(updateBannerImage);
            var path = await _saveImageService.SaveImageAsync(updateBannerImage.File, TypeImage.ImageBanner);
            bannerUpdate.Path = path;
            _unitOfWork.BannerImageRepository.Update(bannerUpdate);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
