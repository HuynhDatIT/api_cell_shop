﻿using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Interface.IServices
{
    public interface ICategorieService
    {
        Task<Categorie> GetById(int id);
        Task<IList<Categorie>> GetAll();
    }
}
