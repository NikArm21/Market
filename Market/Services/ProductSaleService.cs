using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class ProductSaleService : IProductSaleService
    {
        private readonly MarketDbContext _context;
        private readonly IWareHouseService _wareHouseService;

        public ProductSaleService(MarketDbContext context, IWareHouseService wareHouseService)
        {
            _context = context;
            _wareHouseService = wareHouseService;
        }

        public async Task<int> CreatSaledProduct(ProductSaleHistory productSaleHistory)
        {
            if (productSaleHistory == null)
            {
                return 0;
            }
            var product = await _context.Products.FindAsync(productSaleHistory.ProductId);
            productSaleHistory.Income = (product.Price - product.Cost) * productSaleHistory.Count;
            var result = await _wareHouseService.SaleProduct(productSaleHistory.ProductId, productSaleHistory.Count);
            if (!result)
            {
                return -1;
            }
            await _context.ProductSaleHistories.AddAsync(productSaleHistory);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductSaleHistory>> GetProductSalesBySaleID(int saleID)
        {
            return await _context.ProductSaleHistories.Where(s => s.SaleHistoryId == saleID).ToListAsync();
        }
    }
}
