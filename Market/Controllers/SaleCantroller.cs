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
        private static List<SaleItem> items = new List<SaleItem>();
        private static int SaleRowId = 0;
        public SaleController(ISaleService service, IWareHouseService wareHouseService)
        {
            _service = service;
            _wareHouseService = wareHouseService;
        }

        // GET: SaleCantroller
        public ActionResult Index()
        {
            var sale = new Sale();
            //var a = _service.CreateSaleHistory(sale);
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
            items.Add(new SaleItem() { SaleRowId = SaleRowId++ });

            return PartialView("_SaleRow", items);
        }
        public async Task RemoveSaleRow(int SaleRowId)
        {
            var item = items.Where(i => i.SaleRowId == SaleRowId).FirstOrDefault();

            items.Remove(item);
        }

        public async Task<IActionResult> GetReceiptModal()
        {
            return PartialView("_SalesReceipt");
        }

        public async Task<ActionResult> Sale()
        {
            return View("SaleCheck");
        }

        [HttpPost]
        public async Task<ActionResult> Sale(List<SaleItem> sales)
        {
            //Clear list
            items = new List<SaleItem>();

            var saledItems = await _service.CreateSaleHistory(sales);
            if (saledItems)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false, error = "Error" });
        }

    }
}
