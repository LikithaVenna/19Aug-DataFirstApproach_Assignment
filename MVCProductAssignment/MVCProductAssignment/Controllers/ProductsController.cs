using MVCProductAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProductAssignment.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var products = GetProduct();
            return View(products);
        }
        private IEnumerable<Product> GetProduct()
        {
            return new List<Product>()
            {
                new Product{productId=101,productName="AC",productRate=45000},
                new Product{productId=102,productName="Mobile",productRate=38000},
                new Product{productId=103,productName="Bike",productRate=94000}
            };
        }
        public ActionResult Details(int id)
        {
            var product = GetProduct().SingleOrDefault(c => c.productId == id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }
    }
}