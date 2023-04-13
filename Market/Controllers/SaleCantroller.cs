using Market.Models;
using Market.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Market.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _service;
        private readonly IWareHouseService _wareHouseService;
        public SaleController(ISaleService service, IWareHouseService wareHouseService)
        {
            _service = service;
            _wareHouseService = wareHouseService;
        }

        // GET: SaleCantroller
        public ActionResult Index()
        {
            var sale = new Sale();
            var a = _service.CreateSaleHistory(sale);
            return View("SaleView");
        }

        public async Task<IActionResult> GetProductById(int id)
        {
            //return  _context.Products.Find(id);
            var productWare = await _wareHouseService.GetProductById(id);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var product = System.Text.Json.JsonSerializer.Serialize(productWare, options);

            if (productWare != null)
            {
                return Json(new { success = true, product });
            }
            return Json(new
            {
                success = false,
                message = "Haven't this product"
            });
        }

        public async Task<IActionResult> GetSaleRow()
        {
            return PartialView("_SaleRow");
        }

        public async Task<ActionResult> Sale()
        {
            return View("SaleCheck");
        }

        [HttpPost]
        public async Task<ActionResult> Sale(List<SaleItem> sales)
        {
            return View();
        }

    }
}
