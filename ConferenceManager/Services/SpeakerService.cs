using ConferenceManager.Controllers;
using ConferenceManager.Data;
using ConferenceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Services
{
    public class SpeakerService
    {
        private readonly ISpeakerRepository _speakerModel;

        public SpeakerService(ISpeakerRepository speakerModel)
        {
            _speakerModel = speakerModel;
        }

        public List<Speaker> TakeAllSpeaker()
        {
            return _speakerModel.GrabAllSpeaker();
        }

        public Attendee? TakeSpeakerById(int speakerId)
        {
            return _speakerModel.GrabAttendeeById(speakerId);
        }

        public void CreateAttendee(Speaker newSpeaker)
        {
            _speakerModel.AddAttendee(newSpeaker);
        }

    }
}

