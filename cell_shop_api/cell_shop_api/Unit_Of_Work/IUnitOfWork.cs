using cell_shop_api.Repository.InheritRepository.Interface;
using cell_shop_api.Repository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace cell_shop_api.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        IModelProductRepository ModelProductRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategorieRepository CategorieRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICartRepository CartRepository { get; }
        IProductImageRepository ProductImageRepository { get; }
        IAccountRepository AccountRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IInvoiceDetailRepository InvoiceDetailRepository { get; }
        IWishListRepository WishListRepository { get; }
        IRoleRepository RoleRepository { get; }
        ILinkRepository LinkRepository { get; }
        IPromotionRepository PromotionRepository { get; }
        IAddressesRepository AddressesRepository { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
