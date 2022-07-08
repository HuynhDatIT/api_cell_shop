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
    public class LinkService : ILinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LinkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateLinkAsync(CreateLink createLink)
        {
            var link = _mapper.Map<Link>(createLink);
            await _unitOfWork.LinkRepository.AddAsync(link);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
                return true;
            return false;
        }

        public async Task<bool> DeleteLinkAsync(int id)
        {
            var link = await _unitOfWork.LinkRepository.GetByIdAsync(id);
            if (link == null)
                return false;
            _unitOfWork.LinkRepository.Delete(link);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
                return true;
            return false;
        }

        public async Task<IEnumerable<GetLink>> GetAllAsync()
        {
            var listLink = await _unitOfWork.LinkRepository.GetAllAsync();
            var listLinkResult = _mapper.Map<IEnumerable<GetLink>>(listLink);

            return listLinkResult;
        }

        public async Task<GetLink> GetByIdAsync(int id)
        {
            var link = await _unitOfWork.LinkRepository.GetByIdAsync(id);

            var getLink = _mapper.Map<GetLink>(link);

            return getLink;
        }

        public async Task<bool> UpdateLinkAsync(UpdateLink updateLink)
        {
            var link = await _unitOfWork.LinkRepository.GetByIdAsync(updateLink.Id);
            if (link == null)
                return false;
            
            link.PathLink = updateLink.PathLink;
            link.Title =   updateLink.Title;
            link.Status = updateLink.Status;
            _unitOfWork.LinkRepository.Update(link);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
                return true;
            return false;
        }
    }
}
