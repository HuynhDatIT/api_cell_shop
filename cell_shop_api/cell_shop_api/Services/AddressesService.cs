using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class AddressesService : IAddressesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private int accountId;
        public AddressesService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;

            accountId = _claimsService.GetCurrentAccountId;
        }

        public async Task<bool> CreateAddresse(CreateAddresse createAddresse)
        {
            var addresse = _mapper.Map<Addresse>(createAddresse);

            addresse.AccountId = accountId;

            await _unitOfWork.AddressesRepository.AddAsync(addresse);
           
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAddresseAsync(int id)
        {
            var addresse = await _unitOfWork.AddressesRepository.GetByIdAsync(id);

            if (addresse == null) return false;

            addresse.Status = false;

            _unitOfWork.AddressesRepository.Update(addresse);

            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<IList<GetAddresse>> GetAddressesByAccountAsync()
        {

            var addresses = await _unitOfWork.AddressesRepository
                                        .GetAddressesByAccountIdAsync(accountId);

            var getAddresses = _mapper.Map<IList<GetAddresse>>(addresses);

            return getAddresses;
        }

        public async Task<bool> UpdateAddresseAsync(UpdateAddresse updateAddresse)
        {
            var addresse = await _unitOfWork.AddressesRepository
                                            .GetByIdAsync(updateAddresse.Id);

            if (addresse == null) return false;

            var addresseNew = _mapper.Map(updateAddresse, addresse);

            _unitOfWork.AddressesRepository.Update(addresseNew);

            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
