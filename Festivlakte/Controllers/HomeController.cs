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
            // alle festivals ophalen
            var festivals = GetAllFestivals();

            // lijst met producten in html stoppen
            return View(festivals);
        }
        [Route("festivals")]
        public IActionResult Festivals()
        {
            // alle festivals ophalen
            var festivals = GetAllFestivals();

            // lijst met producten in html stoppen
            return View(festivals);
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

        public List<Festivals> GetAllFestivals ()
        {

            //alle festivals ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * from festivals");

            //lijst maken om alle festivals in te stoppen
            List<Festivals> festivals = new List<Festivals>();

            foreach (var row in rows)
            {
                //Voor elke rij maken we nu een festival
                Festivals p = new Festivals();
                p.Naam = row["naam"].ToString();
                p.Beschrijving = row["beschrijving"].ToString ();
                p.Datum_begin = row["datum_begin"].ToString();
                p.Datum_eind = row["datum_eind"].ToString();
                p.Tijd = row["tijd"].ToString();
                p.Beschrijving_lang = row["beschrijving_lang"].ToString();
                p.Afbeelding = row["afbeelding"].ToString();
                p.Id = Convert.ToInt32(row["id"]);

                //en dat destival voegen we toe aan de lijst met producten
                festivals.Add(p);
            }

            return festivals;
        }

    }
}
