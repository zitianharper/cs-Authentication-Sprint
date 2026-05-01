using ConferenceManager.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using ConferenceManager.EventsServices;
using Microsoft.AspNetCore.Authorization;


namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Server is running");
        }
    }



    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventsService _eventsService;

        public EventsController(EventsService eventsService)
        {
            _eventsService = eventsService;
        }

        //get events

        [HttpGet]
        public ActionResult<List<Events>>  GetAllEvents ()
        {
            return Ok(_eventsService.TakeAllEvents());
        }

        // GET /events/{id}
        [HttpGet("{id}")]
        public IActionResult GetEventsById(int id)
        {
            var ev = _eventsService.TakeEventById(id);

            if (ev == null)
            {
                return NotFound(); 
            }

            return Ok(ev); 
        }

        //Post Event
        [Authorize]
        [HttpPost]
        public IActionResult PostEvent(Events newEvent)
        {
            if(newEvent == null)
            {
                return BadRequest();
            }

            _eventsService.CreateEvent(newEvent);

            return CreatedAtAction(nameof(GetEventsById), new { id = newEvent.Id }, newEvent);
        }

       
    }
}
