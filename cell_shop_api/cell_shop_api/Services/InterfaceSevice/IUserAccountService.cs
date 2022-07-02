﻿using cell_shop_api.ViewModels;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Models;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IUserAccountService
    {
        Task<bool> RegisterAsync(Register register);
        Task<Token> AuthenticaAsync(Login login);
        Task<bool> ForgotPasswordAsync(ForgotPassword forgotPassword);
        Task<bool> UpdateProfileAsync(UpdateProfile updateProfile);

    }
}