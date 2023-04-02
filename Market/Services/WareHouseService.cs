using Market.Models;

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
    }
}
