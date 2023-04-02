using Market.Models;

namespace Market.Services
{
    public interface ISaleService
    {
        public Task<SaleHistory> GetSaleHistory();
        public Task<SaleHistory> GetSaleHistoryById();
        public Task<bool> CreateSaleHistory(Sale sale);
    }
}
