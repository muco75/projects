using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;


namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _database;
        public CarController(ApplicationDbContext db)
        {
            _database = db;
        }

        [HttpGet]
        [Route("get")]
        public List<Item> GetTask()
        {
            var cars = _database.Items.ToList();
            return cars;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddTask([FromBody] Item item)
        {
            _database.Items.Add(item);
            _database.SaveChanges();

            var response = new
            {
                Message = "Data saved succesfully",
                Data = item
            };

            return Ok(response);
        }



    }
}
