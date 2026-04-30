using ConferenceManager.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using ConferenceManager.EventsServices;


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

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<ConferenceManagerController> _logger;

        //public ConferenceManagerController(ILogger<ConferenceManagerController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
