using Market.Models;

namespace Market.Services
{
    public interface ISaleService
    {
        Task<List<SaleHistory>> GetSaleHistory();
        Task<bool> CreateSaleHistory(Sale sale);
        Task<SaleHistory> GetSaleHistoryById(int id);

    }
}
