using System;

namespace cell_shop_api.ViewModels.Response
{
    public class GetProfile
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public bool Male { get; set; }
        public string AvatarPath { get; set; }
    }
}
