using ConferenceManager.Data;
using ConferenceManager.EventsServices;
using ConferenceManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.EventsServices
{
    public class EventsService
    {
        private readonly IEventsRepository _eventsModel;

        public EventsService(IEventsRepository eventsModel)
        {
            _eventsModel = eventsModel;
        }

        public List<Events> TakeAllEvents()
        {
            return _eventsModel.GrabAllEvents();
        }

        public Events? TakeEventById(int id)
        {
            return _eventsModel.GrabEventsById(id);
        }

    }
}

