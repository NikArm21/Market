﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Market.Controllers
{
    [Authorize(Roles = "admin,manager")]
    public class EmployesController : Controller
    {
        // GET: EmployesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployesController/Create
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

        // GET: EmployesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployesController/Edit/5
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

        // GET: EmployesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployesController/Delete/5
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
