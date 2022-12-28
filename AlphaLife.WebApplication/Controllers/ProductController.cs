using AlphaLife.WebApplication.Data.ViewModels;
using AlphaLife.WebApplication.Models;
using AlphaLife.WebApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlphaLife.WebApplication.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        private readonly IResturantService _serviceRes;
        private readonly ICategoryService _serviceCat;
        public ProductController(IProductService service, IResturantService serviceRes, ICategoryService serviceCat)
        {
            _service = service;
            _serviceRes = serviceRes;
            _serviceCat = serviceCat;
        }

        //GET: Category/Create
        public async Task<IActionResult> Create()
        {
            var resturants = await _serviceRes.GetResturantByUserIdAndRoleAsync
                (User.FindFirstValue(ClaimTypes.NameIdentifier));
            var categories = await _serviceCat.GetAll();
            ViewBag.Resturants = new SelectList(resturants, "Id", "NameAR");
            ViewBag.Categories = new SelectList(categories, "Id", "NameAR");
            return View();
        }
        //POST: From Category/Create
        [HttpPost]
        public async Task<IActionResult> Create(NewProdcutVM product)
        {
            var resturants = await _serviceRes.GetResturantByUserIdAndRoleAsync
                (User.FindFirstValue(ClaimTypes.NameIdentifier));
            var categories = await _serviceCat.GetAll();
            ViewBag.Resturants = new SelectList(resturants, "Id", "NameAR");
            ViewBag.Categories = new SelectList(categories, "Id", "NameAR");

            if (!ModelState.IsValid) return View(product);

            List<Product> result = (List<Product>) await _service.GetAll();

            var cat = result.Find(c => (c.NameAR == product.NameAR || c.NameEN == product.NameEN) && c.ResturantId == product.ResturantId);
            
            if (cat != null) return View(product);
            product.SalePrice = product.Price - product.Price * (product.OnSale / 100);
            await _service.Add(product);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index() => View(await _service.GetAll(x => x.Resturant));
        //GET: Category/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetById(id, x => x.Resturant);
            
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
        public async Task<IActionResult> Edit(int id, NewProdcutVM product)
        {
            if (!ModelState.IsValid) return View(product);

            if (id != product.Id) return View(product);

            await _service.Update(id, product);
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
