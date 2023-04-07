using Market.Models;
using Market.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View("SaleView");
        }

        // GET: SaleCantroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleCantroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleCantroller/Create
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

        // GET: SaleCantroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleCantroller/Edit/5
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

        // GET: SaleCantroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleCantroller/Delete/5
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

        public Product GetProductById(int id)
        {
            //return  _context.Products.Find(id);
            return null;
        }

        public async Task<ActionResult> SaleView()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SaleView(List<Sale> sales)
        {
            return View();
        }

    }
}
