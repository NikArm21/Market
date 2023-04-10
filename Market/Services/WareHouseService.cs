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

        public async Task<bool> AddProduct(WareHouse wareHouse)
        {
            var product = await _context.WareHouses.Where(w => w.Id ==wareHouse.Product.Id).FirstOrDefaultAsync();
           
            if(product == null)
            {
                await _context.WareHouses.AddAsync(new WareHouse() { Count =wareHouse.Count, ProductId = wareHouse.Product.Id });
            }
            else
            {
                product.Count +=wareHouse.Count;
            }
            
            int result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<WareHouse> GetProductInWarehausByIdAsync(int productId)
        {
            return await _context.WareHouses.FirstOrDefaultAsync(w=>w.ProductId==productId);
        }
    }
}
