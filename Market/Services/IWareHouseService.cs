using Market.Models;

namespace Market.Services
{
    public interface IWareHouseService
    {
        Task<bool> SaleProduct(int productid, int count);
        Task<bool> AddProduct(ProductWareShortModel wareHouse);
        Task<WareHouse> GetProductInWarehausByIdAsync(int productId);
        Task<WareHouse> GetProductById(int id);
        Task<List<ProductWareShortModel>> GetProducts();
        Task<bool> EditProduct(WareHouse product);
    }

}
