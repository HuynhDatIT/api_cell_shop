using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Enum;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mini_project_API.Helper;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly ISaveImageService _saveImageService;
        private readonly IEmailService _emailService;
        private int accountId;

        public UserAccountService(IUnitOfWork unitOfWork, 
                    IMapper mapper, IConfiguration configuration,
                    IClaimsService claimsService,
                    ISaveImageService saveImageService, 
                    IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
            _configuration = configuration;
            _saveImageService = saveImageService;
            _emailService = emailService;

            accountId = _claimsService.GetCurrentAccountId;
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPassword forgotPassword)
        {
            var account = await _unitOfWork
                                   .AccountRepository
                                   .GetAccountByEmailAsync(forgotPassword.Email);
            if (account == null)
                return false;

            var newPassword = GetRandomAlphaNumeric(6);

            account.PassWord = newPassword.HashMD5();

            _unitOfWork.AccountRepository.Update(account);

            try
            {
                _emailService.SendEmailForgotPassword(newPassword, account.Email, account.FullName);
            }
            catch (Exception)
            {
                throw;
            }

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        private static string GetRandomAlphaNumeric(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<Token> AuthenticaAsync(Login login)
        {
            var account = await _unitOfWork.AccountRepository
                                           .Login(login.Username, login.Password);
            if (account == null)
            {
                return new Token
                {
                    Messeges = "Fail",
                    TokenJWT = null
                };
            }
            else
            {
                return new Token
                {
                    Messeges = "Success",
                    TokenJWT = GeneraToken(account)
                };
            }

        }

        public async Task<bool> RegisterAsync(Register register)
        {
            var account = await _unitOfWork.AccountRepository
                                           .GetAccountAsync(register.UserName,
                                                            register.Email);
            if (account != null)
                return false;

            var accountNew = _mapper.Map<Account>(register);

            await _unitOfWork.AccountRepository.AddAsync(accountNew);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        private string GeneraToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                 new Claim(ClaimTypes.PrimarySid, account.Id.ToString()),
                 new Claim(ClaimTypes.Role, account.Role.Name)
              }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                                        new SymmetricSecurityKey(tokenKey),
                                            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenstring = tokenHandler.WriteToken(token);

            return tokenstring;
        }

        public async Task<bool> UpdateProfileAsync(UpdateProfile updateProfile)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId);
            
            var accountupdate = _mapper.Map(updateProfile, account);

            if(updateProfile.file != null)
            {
                var path = await _saveImageService.SaveImageAsync(updateProfile.file, TypeImage.ImageAccount);

                accountupdate.AvatarPath = path;
            }    

            _unitOfWork.AccountRepository.Update(accountupdate);

            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<GetProfile> GetProfileAsync()
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId);

            return _mapper.Map<GetProfile>(account);
        }
        public async Task<bool> ChangePasswordAsync(ChangePassword changePassword)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId);

            if (account.PassWord != changePassword.OldPassword.HashMD5()) return false;

            account.PassWord = changePassword.NewPassword.HashMD5();

            _unitOfWork.AccountRepository.Update(account);

            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
