using ConferenceManager.Data;
using System.Collections.Generic;

namespace ConferenceManager.Models
{
    public interface IAttendeeRepository
    {
        List<Attendee> GrabAllAttendee();
        Attendee? GrabAttendeeById(int id);
        void AddAttendee(Attendee newAttendee);

    }
}
