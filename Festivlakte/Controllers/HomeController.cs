using Festivlakte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using Festivlakte.Database;
using Festivlakte.Controllers.Databases;

namespace Festivlakte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // alle producten ophalen
            var products = GetAllProducts();

            // lijst met producten in html stoppen
            return View(products);
        }
        [Route("festivals")]
        public IActionResult Festivals()
        {
            return View();
        }

        [Route("detail")]
        public IActionResult Detail()
        {
            return View();
        }

        [Route("transport")]
        public IActionResult Transport()
        {
            return View();
        }

        [Route ("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("contact")]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
                return Redirect("/succes");

            return View(person);
        }

        [Route("succes")]
        public IActionResult Succes()
        {
            return View();
        }

        [Route("algemeen")]
        public IActionResult Algemeen ()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public List<Product> GetAllProducts ()
        {

            //alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * from product");

            //lijst maken om allee producten in te stoppen
            List<Product> products = new List<Product>();

            foreach (var row in rows)
            {
                //Voor elke rij maken we nu een product
                Product p = new Product();
                p.Naam = row["naam"].ToString();
                p.Prijs = row["prijs"].ToString ();
                p.Beschikbaarheid = Convert.ToInt32(row["beschikbaarheid"]);
                p.Id = Convert.ToInt32(row["id"]);

                //en dat product voegen we toe aan de lijst met producten
                products.Add(p);
            }

            return products;
        }

    }
}
