using CellShop_Api.Models;
using System.Collections.Generic;

namespace cell_shop_api.ViewModels.Response
{
    public class GetCart
    {
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
