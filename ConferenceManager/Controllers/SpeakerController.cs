using ConferenceManager.Data;
using ConferenceManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeakerController : ControllerBase
    {
            private readonly SpeakerService _speakerService;

            public SpeakerController(SpeakerService speakerService)
            {
                _speakerService = speakerService;
            }

            //GET all Speaker

            [HttpGet]
            public ActionResult<List<Speaker>> GetAllSpeaker()
            {
                return Ok(_speakerService.TakeAllSpeaker());
            }

            // GET /Speaker/{id}
            [HttpGet("{id}")]
            public IActionResult GetSpeakerById(int speakerId)
            {
                var speaker = speakerService.TakeSpeakerById(speakerId);

                if (speaker == null)
                {
                    return NotFound();
                }

                return Ok(speaker);
            }

            //Post Speaker
            [Authorize]
            [HttpPost]
            public IActionResult PostSpeaker(Speaker newSpeaker)
            {
                if (newSpeaker == null)
                {
                    return BadRequest();
                }

                _speakerService.CreateSpeaker(newSpeaker);

                return CreatedAtAction(nameof(GetSpeakerById), new { id = newSpeaker.SpeakerId}, newSpeaker);
            }


        
    }
}
}
