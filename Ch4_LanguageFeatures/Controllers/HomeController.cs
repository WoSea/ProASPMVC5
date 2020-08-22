using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch4_LanguageFeatures.Models;

namespace Ch4_LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /* public ActionResult Index()
         {
             return View();
         }*/

        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        public ViewResult AutoProperty()
        {
            //Create a new Product obk=ject
            Product myProduct = new Product();

            //Ser the property value
            myProduct.Name = "John";

            //get the property
            string productName = myProduct.Name;

            //generate the view
            return View("Result", (object)String.Format("Product name: {0}", productName));
        }
        public ViewResult CreateProduct()
        {
            /* //createa new Product object
             Product myProduct = new Product();

             //set the property values
             myProduct.ProductID = 100;
             myProduct.Name = "John";
             myProduct.Description = "A boat for one person";
             myProduct.Price = 275M;
             myProduct.Category = "Watersports";
             */
            // create and populate a new Product object
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "John",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };
            return View("Result", (object)string.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int>
            {
                {"apple",10 },{ "orange",20},{"plum",30}
            };
            return View("Result", (object)stringArray[1]);
        }
        public ViewResult UseExtension()
        {
           
            //create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product{Name="John",Price=275M},
                    new Product{Name="Wick",Price=34.26M},
                    new Product{Name="Smith",Price=22M},
                    new Product{Name="Min",Price=65M}
                }
            };
            //get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Total:{0:c}", cartTotal));  
        }
        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                     new Product{Name="John",Price=275M},
                    new Product{Name="Wick",Price=34.26M},
                    new Product{Name="Smith",Price=22M},
                    new Product{Name="Min",Price=65M}
                }
            };
            //create and populate an array of Product objects
            Product[] productArray =
            { new Product{Name="John",Price=275M},
                    new Product{Name="Wick",Price=34.26M},
                    new Product{Name="Smith",Price=22M},
                    new Product{Name="Min",Price=65M}

            };

            //get the total value of the products in the cart
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();

            return View("Result",(object)String.Format("Cart Total: {0},Array Total: {1}",
                cartTotal,arrayTotal));
        }

        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products=new List<Product>
                {
                    new Product{Name="John",Category="WaterSports",Price=275M},
                    new Product{Name="Wick",Category="WaterSports",Price=34.26M},
                    new Product{Name="Smith",Category="Soccer",Price=22M},
                    new Product{Name="Min",Category="Soccer",Price=65M}
                }
             };
            /*  Func<Product, bool> categoryFilter = delegate (Product prod)
                {
                    return prod.Category=="Soccer";
                };*/
            Func<Product, bool> categoryFilter = pro => pro.Category == "Soccer";
            decimal total = 0;
            //  foreach (Product prod in products.FilterByCategory("Soccer"))
            // foreach(Product prod in products.Filter(categoryFilter))
            foreach (Product prod in products.Filter(prod=> prod.Category=="Soccer" || prod.Price>20))
            {
                total += prod.Price;

            }  

            return View("Result",(object)string.Format("Total:{0}",total));
        }

        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new {Name="MVC", Category= "Pattern" },
                new {Name="Hat", Category= "Clothing" },
                new {Name="Apple", Category= "Fruit" },
            };
            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }
            return View("Result", (object)result.ToString());
        }
        public ViewResult FindProducts()
        {
            Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };
            /*   var foundProducts = from match in products
                                   orderby match.Price descending
                                   select new { match.Name, match.Price };*/
            var foundProducts = products.OrderByDescending(e => e.Price)
              .Take(3).Select(e=>new { e.Name,e.Price});

            products[2] = new Product { Name="Stadium", Price=56};
            // create the result
            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);
               /* if (++count == 3)
                {
                    break;
                }*/
            }
            return View("Result", (object)result.ToString());
        }

        public ViewResult SumProducts()
        {
            Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };
            var results = products.Sum(e=>e.Price);
            products[2] = new Product { Name= "Stadium", Price=7950};
            return View("Result",(object)String.Format("Sum: {0:c}",results));

        }
    }
}