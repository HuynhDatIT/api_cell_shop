using cell_shop_api.Enum;

namespace cell_shop_api.ViewModels.Request
{
    public class UpdateAddresse
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public TypeAddresses Type { get; set; }
        public string Phone { get; set; }
    }
}
