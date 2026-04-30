using ConferenceManager.Data;
using ConferenceManager.Models;
using System.Collections.Generic;

namespace ConferenceManager.Models
{
    public interface IEventsRepository
    {
        List<Events> GrabAllEvents();
        Events? GrabEventsById(int id);
        void AddEvent(Events newEvent);

    }
}
