using ConferenceManager.Data;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Text.Json;
using ConferenceManager.Models;

namespace ConferenceManager.Models
{
    public class EventsRepository : IEventsRepository
    {
        private readonly string _filePath = "Data/EventsData.json";
        private readonly List<Events> _events;

        public EventsRepository()
        {
            var json = File.ReadAllText(_filePath);
            _events = JsonSerializer.Deserialize<List<Events>>(json) ?? new List<Events>();
        }

        public List<Events> GrabAllEvents()
        {
          
            return _events ?? new List<Events>();

        }
        public List<Events> GrabEventsById() => _events;

        public Events? GrabEventsById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }
    }

}