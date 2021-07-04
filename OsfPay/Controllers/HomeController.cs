using Microsoft.AspNetCore.Mvc;
using OsfPay.Data;
using OsfPay.Data.Entities;
using OsfPay.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OsfPay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products;
                
            products = _productRepository.AllProducts.OrderBy(p => p.ProductId);
            ProductViewModel modelProduct = new ProductViewModel();
            modelProduct.Products = products;
                        
            return View(modelProduct);
        }

       
    }
}
