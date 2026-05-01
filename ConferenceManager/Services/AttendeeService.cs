using ConferenceManager.Controllers;
using ConferenceManager.Data;
using ConferenceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Services
{
    public class AttendeeService
    {
        private readonly ISpeakerRepository _attendeeModel;

        public AttendeeService(ISpeakerRepository attendeeModel)
        {
            _attendeeModel = attendeeModel;
        }

        public List<Attendee> TakeAllAttendee()
        {
            return _attendeeModel.GrabAllAttendee();
        }

        public Attendee? TakeAttendeeById(int attendeeId)
        {
            return _attendeeModel.GrabAttendeeById(attendeeId);
        }

        public void CreateAttendee(Attendee newAttendee)
        {
            _attendeeModel.AddAttendee(newAttendee);
        }

    }
}

