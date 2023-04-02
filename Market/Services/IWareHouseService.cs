using Microsoft.AspNetCore.Mvc;

namespace Market.Services
{
    public interface IWareHouseService
    {
        public  Task<bool> SaleProduct(int productid, int count);
    }
}
