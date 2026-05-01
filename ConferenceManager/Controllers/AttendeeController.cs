using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ConferenceManager.Data;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendeeController : ControllerBase
    {
            private readonly AttendeeService _attendeeService;

            public AttendeeController(AttendeeService attendeeService)
            {
                _attendeeService = attendeeService;
            }

            //GET all Attendees

            [HttpGet]
            public ActionResult<List<Attendee>> GetAllAttendee()
            {
                return Ok(_attendeeService.TakeAllAttendee());
            }

            // GET /Attendee/{id}
            [HttpGet("{id}")]
            public IActionResult GetAttendeeById(int attendeeId)
            {
                var att = attendeeService.TakeAttendeeById(attendeeId);

                if (att == null)
                {
                    return NotFound();
                }

                return Ok(att);
            }

            //Post Attendee
            [Authorize]
            [HttpPost]
            public IActionResult PostAttendee(Attendee newAttendee)
            {
                if (newAttendee == null)
                {
                    return BadRequest();
                }

                _attendeeService.CreateAttendee(newAttendee);

                return CreatedAtAction(nameof(GetAttendeeById), new { id = newAttendee.AttendeeId}, newAttendee);
            }


        
    }
}
}
