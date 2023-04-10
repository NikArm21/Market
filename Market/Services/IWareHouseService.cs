using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Services
{
    public interface IWareHouseService
    {
        Task<bool> SaleProduct(int productid, int count);
        Task<bool> AddProduct(int id, int count);
        Task<WareHouse> GetProductInWarehausByIdAsync(int productId);
    }

}
