using Market.Models;
using Market.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Market.Controllers
{
    public class WareHouseController : Controller
    {
        private readonly IWareHouseService _service;

        public WareHouseController(IWareHouseService service)
        {
            _service = service;
        }

        // GET: WareHouseController
        public async Task<IActionResult> Index()
        {


            return View();
        }

        // GET: WareHouseController/Details/5

        // GET: WareHouseController/Create
        public async Task<ActionResult> AddProduct(int id = 0)
        {
            //var model = await _service.GetProductInWarehausByIdAsync(id);
            var products = await _service.GetProducts();

            ViewBag.Products = new SelectList(products, "ProductId", "ProductName");

            return PartialView("_AddNewProductToWare");
        }

        // POST: WareHouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddProduct(ProductWareShortModel wareHouse)
        {
            try
            {
                //_marketDbContext.WareHouses.Add(wareHouse);
                //_marketDbContext.SaveChanges(); 
                //_service.SaleProduct();
                bool result = await _service.AddProduct(wareHouse);
                if (result)
                {
                    return Json(new { success = true });
                }
                return Json(new
                {
                    success = false
                });
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetProductById(id);

            if (product != null)
            {
                return PartialView("_AddProductWare", product);
            }
            else
            {
                return Json(new { success = false });
            }
        }



    }
}
