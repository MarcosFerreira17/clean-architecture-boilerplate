using System;
using System.Net;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetProducts();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Evita ataques CSRF - Falsificação de solitações entre sites.
        public IActionResult Create([Bind("Id,Name,Description,Price")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productVM = await _productService.GetById(id);

            if (productVM == null) return NotFound();

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id,Name,Description,Price")] ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(productVM);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productVM = await _productService.GetById(id);

            if (productVM == null)
            {
                return NotFound();
            }

            return View(productVM);
        }
        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var productVM = await _productService.GetById(id);

            if (productVM == null) return NotFound();

            return View(productVM);
        }

        [HttpPost(), ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}