﻿using Microsoft.AspNetCore.Mvc;
using ShrimplyShrimpWeb.Data;
using ShrimplyShrimpWeb.Models;

namespace ShrimplyShrimpWeb.Controllers
{
    public class ShrimpController : Controller
    {
        private readonly ShrimplyShrimpDbContext _shrimplyShrimpDbContext;

        public ShrimpController(ShrimplyShrimpDbContext shrimplyShrimpDbContext)
        {
            _shrimplyShrimpDbContext = shrimplyShrimpDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Shrimp> shrimps = _shrimplyShrimpDbContext.Shrimps;
            return View(shrimps);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Shrimp shrimp)
        {
            if (shrimp.Name == shrimp.DisplayOrder.ToString())
            {
                ModelState.AddModelError("ShrimpError", "Shrimp Name cannot match DisplayOrder");
            }
            if (ModelState.IsValid)
            {
                _shrimplyShrimpDbContext.Shrimps.Add(shrimp);
                _shrimplyShrimpDbContext.SaveChanges();
                TempData["success"] = "Shrimp created successfully";
                return RedirectToAction("Index");
            }
            return View(shrimp);
        }
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var existingShrimp = _shrimplyShrimpDbContext.Shrimps.Find(id);
            if (existingShrimp == null)
            {
                return NotFound();
            }

            return View(existingShrimp);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Shrimp shrimp)
        {
            if (shrimp.Name == shrimp.DisplayOrder.ToString())
            {
                ModelState.AddModelError("ShrimpError", "Shrimp Name cannot match DisplayOrder");
            }
            if (ModelState.IsValid)
            {
                _shrimplyShrimpDbContext.Shrimps.Update(shrimp);
                _shrimplyShrimpDbContext.SaveChanges();
                TempData["success"] = "Shrimp edited successfully";
                return RedirectToAction("Index");
            }
            return View(shrimp);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var existingShrimp = _shrimplyShrimpDbContext.Shrimps.Find(id);
            if (existingShrimp == null)
            {
                return NotFound();
            }

            return View(existingShrimp);
        }
        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var shrimp = _shrimplyShrimpDbContext.Shrimps.Find(id);
            if (shrimp == null)
            {
                return NotFound();
            }

            _shrimplyShrimpDbContext.Shrimps.Remove(shrimp);
            _shrimplyShrimpDbContext.SaveChanges();
            TempData["success"] = "Shrimp deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
