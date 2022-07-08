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
        }

        public Task<bool> CreateAddresseAsync(CreateAddresse createAddresse)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAddresseAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<GetAddresse>> GetAddressesByAccountAsync(int accountID)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountID);

            if(account == null) return null;

            var addresses = await _unitOfWork.AddressesRepository
                                        .GetAddressesByAccountIdAsync(accountID);

            var getAddresses = _mapper.Map<IList<GetAddresse>>(addresses);

            return getAddresses;
        }

        public Task<bool> UpdateAddresseAsync(UpdateAddresse updateAddresse)
        {
            throw new System.NotImplementedException();
        }
    }
}
