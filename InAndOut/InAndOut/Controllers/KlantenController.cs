using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    [Route("api/klanten")]
    public class KlantenController
    {

        private readonly ApplicationDbContext _database;

        public KlantenController(ApplicationDbContext db)
        {
            _database = db;
        }

        [HttpGet("get")]
        public List<item> GetKlanten()
        {
            var items = _database.Ttems.ToList();
            return items;
        }

        [HttpPost("post")]
        public ActionResult AddKlant([FromBody] item item)
        {
            _database.Ttems.Add(item);
            _database.SaveChanges();
            return new OkResult();
        }
    }
}
