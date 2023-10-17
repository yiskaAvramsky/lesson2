using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        static  List<Event> events = new List<Event> { new Event { id = 1, title = "default event1" ,start= DateTime.Now}, new Event { id = 2, title = "default event2", start = DateTime.Now }, new Event { id = 3, title = "default event3", start = DateTime.Now } };
        static int count = 3;

        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }



        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
        {
            events.Add(new Event { id = count++, title = eve.title,start=eve.start });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            //TODO
            //find event by id
            //update properties
            var ev = events.Find(e => e.id == id);
            ev.title = eve.title;
            ev.start = eve.start;

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.id == id);
            events.Remove(eve);
        }
    }
}
