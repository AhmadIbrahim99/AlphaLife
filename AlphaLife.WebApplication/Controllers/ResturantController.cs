using AlphaLife.WebApplication.Models;
using AlphaLife.WebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Controllers
{
    [Authorize]
    public class ResturantController : Controller
    {
        private readonly IResturantService _service;
        public ResturantController(IResturantService service)
        {
            _service = service;
        }
        //GET: Category/Create
        public IActionResult Create() => View();

        //POST: From Category/Create
        [HttpPost]
        public async Task<IActionResult> Create(Resturant resturant)
        {
            if (!ModelState.IsValid) return View(resturant);
            await _service.Add(resturant);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index() => View(await _service.GetResturantByUserIdAndRoleAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
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
        public async Task<IActionResult> Edit(int id, Resturant resturant)
        {
            if (!ModelState.IsValid) return View(resturant);

            if (id != resturant.Id) return View(resturant);

            await _service.Update(id, resturant);
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
