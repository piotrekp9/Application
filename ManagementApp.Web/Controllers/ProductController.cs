using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productService;

        public ProductController(IProductService productService) => this.productService = productService;

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var products = ProductMapper.MapManyToViewModel(productService.GetProducts());
            if (string.IsNullOrEmpty(filter)) return View(products);

            return View(products.Where(product => 
            product.Name.Contains(filter)));
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ProductViewModel product)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                productService.AddProduct(ProductMapper.MapToDomainModel(product));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Details(int productId)
        {
            if (productId < 1) return BadRequest();
            try
            {
                return View(productService.GetProductById(productId));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public IActionResult Update(ProductViewModel product)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                productService.UpdateProduct(ProductMapper.MapToDomainModel(product));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int productId)
        {
            if (productId < 1) return BadRequest();

            try
            {
                productService.DeleteProduct(productId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
