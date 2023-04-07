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

            if (product == null)
            {
                return false;
            }
            if (product.Count < count)
            {
                return false;
            }

            product.Count -= count;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddProduct(int id, int count)
        {
            var product = await _context.WareHouses.Where(w => w.Id == id).FirstOrDefaultAsync();

            if (product.Count > 0)
            {
                product.Count += count;
            }
            else
            {
                await _context.WareHouses.AddAsync(new WareHouse() { Count = count, ProductId = id });
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
