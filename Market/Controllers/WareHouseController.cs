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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WareHouseController/Create
        public ActionResult AddProduct()
        {
            return View();
        }

        // POST: WareHouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(WareHouse wareHouse) { 
            try
            {
                //_marketDbContext.WareHouses.Add(wareHouse);
                //_marketDbContext.SaveChanges(); 
                //_service.SaleProduct();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WareHouseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WareHouseController/Edit/5
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

        // GET: WareHouseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WareHouseController/Delete/5
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
