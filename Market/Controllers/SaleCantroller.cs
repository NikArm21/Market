using Market.Models;
using Market.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class SaleCantroller : Controller
    {
        private readonly ISaleService _service;
        public SaleCantroller(ISaleService service)
        {
            _service = service;
        }

        // GET: SaleCantroller
        public ActionResult Index()
        {
            var sale = new Sale();
            var a = _service.CreateSaleHistory(sale);
            return View("SaleView");
        }

        public async Task<Product> GetProductById(int id)
        {
            //return  _context.Products.Find(id);
            return null;
        }

        public async Task<ActionResult> SaleView()
        {
            var sale = new Sale();
            var a = _service.CreateSaleHistory(sale);
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SaleView(List<Sale> sales)
        {
            return View();
        }

    }
}
