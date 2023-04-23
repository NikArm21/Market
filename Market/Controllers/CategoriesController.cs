using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market;
using Market.Models;
using Market.Services;
using Microsoft.AspNetCore.Authorization;

namespace Market.Controllers
{
    [Authorize(Roles ="admin,manager")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
            _service = service;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetCategories();

            return categories != null ?
                        View(categories) :
                        Problem("Entity set 'MarketDbContext.Categories'  is null.");
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var categories = await _service.GetCategories();

            if (id == null || categories == null)
            {
                return NotFound();
            }

            var category = _service.GetCategoryById((int)id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var categories = _service.GetCategories();
            if (id == null || categories == null)
            {
                return NotFound();
            }

            var category = _service.GetCategoryById((int)id);
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateCategory(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CategoryExists(category.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var category = await _service.GetCategoryById((int)id);

            if (id == null || category == null)
            {
                return NotFound();
            }


            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _service.GetCategoryById((int)id);

            if (category == null)
            {
                return Problem("Entity set 'MarketDbContext.Categories'  is null.");
            }
            if (category != null)
            {
                await _service.DeleteCateegory(id);
            }

            return RedirectToAction(nameof(Index));
        }

        //private bool CategoryExists(int id)
        //{
        //    return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
