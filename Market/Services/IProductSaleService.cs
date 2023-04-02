using Market.Models;

namespace Market.Services
{
    public interface IProductSaleService
    {
        public Task<List<ProductSaleHistory>> GetProductSalesBySaleID(int SaleID);
        public Task<int> CreatSaledProduct(ProductSaleHistory productSaleHistory);
    }
}
