using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class WareHouseService : IWareHouseService
    {
        private readonly MarketDbContext _context;

        public WareHouseService(MarketDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaleProduct(int productid, int count)
        {
            WareHouse product = _context.WareHouses.FirstOrDefault(w => w.ProductId == productid);

            if (product == null || product.Count < count)
            {
                return false;
            }

            product.Count -= count;

            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AddProduct(ProductWareShortModel wareHouse)
        {
            var product = await _context.WareHouses.Where(w => w.Id == wareHouse.ProductId).FirstOrDefaultAsync();

            if (product == null)
            {
                await _context.WareHouses.AddAsync(new WareHouse() { Count = wareHouse.Count, ProductId = wareHouse.ProductId });
            }
            else
            {
                product.Count += wareHouse.Count;
            }

            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<WareHouse> GetProductInWarehausByIdAsync(int productId)
        {
            return await _context.WareHouses.FirstOrDefaultAsync(w => w.ProductId == productId);
        }

        public async Task<WareHouse> GetProductById(int id)
        {
            var product = await _context.WareHouses.Where(p => p.ProductId == id).FirstOrDefaultAsync();

            return product;
        }

        public async Task<List<ProductWareShortModel>> GetProducts()
        {
            var products = await _context.Products.Select(p => new ProductWareShortModel
            {
                ProductId = p.Id,
                ProductName = p.Name,
            }).ToListAsync();
            return products;
        }
    }
}
