using ASPProductTask2.Entities;
using ASPProductTask2.Models;
using ASPProductTask2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ASPProductTask2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataService _dataService;

        public HomeController(ILogger<HomeController> logger, DataService service)
        {
            _logger = logger;
            _dataService = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = new ProductListViewModel
            {
                Products = this._dataService.Products,
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            this._dataService.DeleteProductById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel()
            {
                Product = new Product()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Product.Id = _dataService.Products.Count + 1;
                _dataService.AddNewProduct(vm.Product);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dataService.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); 
            }
            var vm = new ProductEditViewModel { Product = product };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _dataService.UpdateProduct(vm.Product);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
