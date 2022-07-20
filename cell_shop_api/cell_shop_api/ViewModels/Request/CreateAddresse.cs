using cell_shop_api.Enum;

namespace cell_shop_api.ViewModels.Request
{
    public class CreateAddresse
    {
        public string Address { get; set; }
        public TypeAddresses Type { get; set; }
        public string Phone { get; set; }
    }
}
