using Market.Models;
using Market.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class WareHouseController : Controller
    {
        private readonly IWareHouseService _service;

        public WareHouseController(IWareHouseService service)
        {
            _service= service;
        }

        // GET: WareHouseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WareHouseController/Details/5

        // GET: WareHouseController/Create
        public async Task<ActionResult> AddProduct(int id = 0)
        {
            WareHouse model=await _service.GetProductInWarehausByIdAsync(id);
                ;//stanal trvac idov product@ service.GetProductInWarehausByIdAsync


            return View(model);
        }

        // POST: WareHouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> AddProduct(WareHouse wareHouse) { 
            try
            {
                //_marketDbContext.WareHouses.Add(wareHouse);
                //_marketDbContext.SaveChanges(); 
                //_service.SaleProduct();
                await _service.AddProduct (wareHouse.Product.Id, wareHouse.Count);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
