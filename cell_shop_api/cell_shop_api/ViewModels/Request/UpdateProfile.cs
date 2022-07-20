using Microsoft.AspNetCore.Http;
using System;

namespace cell_shop_api.ViewModels.Request
{
    public class UpdateProfile
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public bool Male { get; set; } 
    }
}
