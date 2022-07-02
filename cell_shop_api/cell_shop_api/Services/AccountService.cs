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
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(CreateAccount createAccount)
        {
            var account = await _unitOfWork.AccountRepository
                                          .GetAccountAsync(createAccount.UserName,
                                                           createAccount.Email);
            if (account != null)
                return false;

            var accountNew = _mapper.Map<Account>(createAccount);

            await _unitOfWork.AccountRepository.AddAsync(accountNew);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);

            if (account == null)
                return false;

            account.Status = false;

            _unitOfWork.AccountRepository.Update(account);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<IEnumerable<GetAccount>> GetAllAsync()
        {
            var listAccount = await _unitOfWork.AccountRepository.GetAllAsync();

            var listGetAccount = _mapper.Map<IEnumerable<GetAccount>>(listAccount);

            return listGetAccount;
        }

        public async Task<GetAccount> GetByIdAsync(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);

            var getAccount = _mapper.Map<GetAccount>(account);
            
            return getAccount;
        }
        public async Task<bool> UpdateAsync(UpdateAccount updateAccount)
        {
            var account = await _unitOfWork.AccountRepository
                                            .GetByIdAsync(updateAccount.Id);
            if (account == null)
                return false;

            var accountupdate = _mapper.Map(updateAccount, account);

            await _unitOfWork.AccountRepository.AddAsync(accountupdate);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
