using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueBackend.data;
using VueBackend.models;

namespace VueBackend.Controllers

{

    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _database;
        public ToDoController(ApplicationDbContext db)
        {
            _database = db;
        }


        [HttpGet]
        [Route("get")]
        public List<item> GetTask()
        {
            var items = _database.Items.ToList();
            return items;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddTask([FromBody] item item)
        {
            _database.Items.Add(item);
            _database.SaveChanges();
            return new OkResult();
        }

        // Update(changes)

        [HttpPost]
        [Route("update/{id}")]
        public ActionResult changeTask(int? id, [FromBody] item item)
        {

            //item ophalen van dataabse
            var entity = _database.Items.FirstOrDefault(item => item.Id == id);
            if (entity != null)
                {
                // item veranderen 

                entity.Status = item.Status;
                entity.Task = item.Task;


            }
            
            _database.SaveChanges();
            return new OkResult();
        }


        //post delete

        [HttpDelete]
        [Route("delete/{id}")]
        //[ValidateAntiForgeryToken]
        public IActionResult PostDelete(int? id)

        {
            var obj = _database.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _database.Items.Remove(obj);
            _database.SaveChanges();
            return new OkResult();
        }

    }

}
