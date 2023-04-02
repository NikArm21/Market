using Market.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class ProductSaleController : Controller
    {
        private readonly IProductSaleService _service;

        public ProductSaleController(IProductSaleService service)
        {
            _service = service;
        }
        // GET: ProductSaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductSaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductSaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductSaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductSaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductSaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductSaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
