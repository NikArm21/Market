using Market.Models;

namespace Market.Services
{
    public interface IProductSaleService
    {
         Task<List<ProductSaleHistory>> GetProductSalesBySaleID(int SaleID);
         Task<int> CreatSaledProduct(ProductSaleHistory productSaleHistory);
    }
}
