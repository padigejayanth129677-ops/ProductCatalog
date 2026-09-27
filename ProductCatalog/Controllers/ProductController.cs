using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        // Product list
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Laptop",
                Category = "Electronics",
                Price = 55000,
                Quantity = 10,
                Description = "HP Laptop with 8GB RAM and 512GB SSD"
            },

            new Product
            {
                ProductId = 2,
                ProductName = "Smartphone",
                Category = "Electronics",
                Price = 25000,
                Quantity = 20,
                Description = "Android smartphone with 128GB storage"
            },

            new Product
            {
                ProductId = 3,
                ProductName = "Headphones",
                Category = "Accessories",
                Price = 2500,
                Quantity = 30,
                Description = "Wireless Bluetooth headphones"
            },

            new Product
            {
                ProductId = 4,
                ProductName = "Keyboard",
                Category = "Accessories",
                Price = 1500,
                Quantity = 15,
                Description = "USB mechanical keyboard"
            }
        };


        // GET: Product
        public ActionResult Index()
        {
            return View(products);
        }


        // GET: Product/Details/1
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Product product = products.FirstOrDefault(p => p.ProductId == id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }


        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = products.Count + 1;

                products.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}