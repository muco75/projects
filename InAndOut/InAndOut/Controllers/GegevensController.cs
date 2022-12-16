using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    //[Route("api/[controller]")] // bunu verhuizen yap -> KlantenController
    public class GegevensController : Controller
    {
        private readonly ApplicationDbContext _database;

        public object Leeftijd { get; private set; }

        public GegevensController(ApplicationDbContext db)
        {
            _database = db;
        }

        private int VanGeboorteDatumNaarLeeftijd(DateTime geboorteDatum)
        {
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - geboorteDatum.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (geboorteDatum.Date > today.AddYears(-age)) age--;

            return age;
        }

        public IActionResult Index()
        {
            IEnumerable<itemView> objlist = _database.Ttems.ToList().Select(item => new itemView
            {
                Id = item.Id,
                Borrwer = item.Borrwer,
                Klantadres = item.Klantadres,
                Leeftijd = VanGeboorteDatumNaarLeeftijd(item.GeboorteDatum)
            });
            return View(objlist);
        }
        //Get Create
        public IActionResult Toevoegen()
        {
            return View();
        }
        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Toevoegen(item obj)
        {
            _database.Ttems.Add(obj);
            _database.SaveChanges();
            return RedirectToAction("index");
        }

        //get delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var item = _database.Ttems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        //post delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int? id)

        {
            var obj = _database.Ttems.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _database.Ttems.Remove(obj);
            _database.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Datum (item Date)
        {
            _database.Ttems.Add(Date);
            _database.SaveChanges();
            return RedirectToAction("index");
        }

        /*[HttpGet("/klanten")]
        public List<item> GetKlanten()
        {
            var items = _database.Ttems.ToList();
            return items;
        }*/

    }
}
