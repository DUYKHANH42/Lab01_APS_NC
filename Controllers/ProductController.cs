using Lab01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lab01.Controllers
{
    public class ProductController : Controller
    {
        public List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop Dell", Price = 15000000 },
            new Product { Id = 2, Name = "iPhone 15", Price = 12000000 }
        };
        public IActionResult Index()
        {

            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {   
            if (!Validation(product)) {
                return BadRequest("Invalid product data");
            }
            else
            {
                product.Id = products.Count + 1;
                products.Add(product);
                return View("Index", products);
            }
        }
        public bool Validation(Product product) {
            if(product.Name == null || product.Price <= 0) {
                Response.StatusCode = 400;
                return false;
            }
            return true;
        } 
    }
}
