using Market.Models;

namespace Market.Services
{
    public class SaleService : ISaleService
    {
        private readonly MarketDbContext _context;
        private readonly ProductSaleService _productSaleService;

        public SaleService(MarketDbContext context, ProductSaleService productSaleService)
        {
            _context = context;
            _productSaleService = productSaleService;
        }

        public async Task<bool> CreateSaleHistory(Sale sale)
        {
            int sum = 0;
            var transaction = _context.Database.BeginTransaction();
            var saleHistory = new SaleHistory()
            {
                Date = DateTime.Now,
                Result = sale.ItemList.Sum(s => s.Total),
            };
            await _context.SaleHistories.AddAsync(saleHistory);
            sum=await _context.SaveChangesAsync();
           
            saleHistory = _context.SaleHistories.FirstOrDefault(s => s.Date == saleHistory.Date);
            foreach (var item in sale.ItemList)
            {
                ProductSaleHistory pr = new ProductSaleHistory()
                {
                    ProductId = item.ProductID,
                    Count = item.Count,
                    SaleHistoryId = saleHistory.Id,

                };
               sum += await _productSaleService.CreatSaledProduct(pr);
                
            }
            if (sum == sale.ItemList.Count + 1)
            {
                transaction.Commit();
                return true;
            }

            transaction.Rollback();
            return false;

            
            

        }

        public Task<SaleHistory> GetSaleHistory()
        {
            throw new NotImplementedException();
        }

        public Task<SaleHistory> GetSaleHistoryById()
        {
            throw new NotImplementedException();
        }
    }
}
