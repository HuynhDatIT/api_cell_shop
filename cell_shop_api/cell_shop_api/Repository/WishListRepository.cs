﻿using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;

namespace cell_shop_api.Repository
{
    public class WishListRepository : BaseRepositoryCURD<WishList>, IWishListRepository
    {
        public WishListRepository(CellShopDbContext db) : base(db)
        {
        }
    }
}
