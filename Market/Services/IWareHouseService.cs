using Microsoft.AspNetCore.Mvc;

namespace Market.Services
{
    public interface IWareHouseService
    {
        Task<bool> SaleProduct(int productid, int count);
    }
}
