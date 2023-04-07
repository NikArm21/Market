using Market.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.Services
{
    public class SaleService : ISaleService
    {
        private readonly MarketDbContext _context;
        private readonly IProductSaleService _productSaleService;

        public SaleService(MarketDbContext context, IProductSaleService productSaleService)
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

        public async Task<List<SaleHistory>> GetSaleHistory()
        {
            return await _context.SaleHistories.Select(s => new SaleHistory() { Date = s.Date, Result = s.Result }).ToListAsync();
        }

        public async Task<SaleHistory> GetSaleHistoryById(int id)
        {
            return await _context.ProductSaleHistories.Where(s => s.SaleHistoryId == id).Select(s=>
            new SaleHistory() 
            {
                Date = s.SaleHistory.Date,
                Result = s.SaleHistory.Result
            }).FirstAsync();
        }
    }
}
