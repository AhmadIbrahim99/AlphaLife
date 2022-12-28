using AlphaLife.WebApplication.Models;
using AlphaLife.WebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        //GET: Category/Create
        public IActionResult Create() => View();

        //POST: From Category/Create
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid) return View(category);
            List<Category> result = (List<Category>) await _service.GetAll();
            var cat = result.Find(c => c.NameAR == category.NameAR || c.NameEN == category.NameEN);
            if(cat != null) return View(category);
            await _service.Add(category);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index() => View(await _service.GetAll());
        //GET: Category/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetById(id);
            if (data == null) return View("NotFound");

            return View(data);
        }

        //GET: Category/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetById(id);
            if (data == null) return View("NotFound");

            return View(data);
        }

        //POST: From Category/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (!ModelState.IsValid) return View(category);

            if (id != category.Id) return View(category);

            await _service.Update(id, category);
            return RedirectToAction(nameof(Index));
        }

        //GET: Category/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetById(id);
            if (data == null) return View("NotFound");

            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var data = await _service.GetById(id);
            if (data == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
