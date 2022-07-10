﻿using cell_shop_api.Base.Interface;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Account : IBaseModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Log> Logs { get; set; }
        public ICollection<Addresse> Addresses { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<WishList> WishLists { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
