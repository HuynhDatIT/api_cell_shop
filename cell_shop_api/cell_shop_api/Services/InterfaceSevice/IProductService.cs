using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IProductService 
    {
        Task<IEnumerable<GetProduct>> GetAllAsync();
        Task<GetProduct> GetByIdAsync(int id);
        Task<IList<GetProduct>> GetProductByModelIdAsync(int modelId);
        Task<bool> CreateProductAsync(CreateProduct createProduct);
        Task<bool> UpdateProductAsync(UpdateProduct updateProduct);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> UpdateRatingProductAsync(int productId, float avgRating);
        Task<IList<GetProduct>> GetProductsByCatagorieAsync(int catogorieId);
        Task<IList<GetProduct>> SearchProductAsync(int? categorieId, int? brandId, string? name);
    }
}
