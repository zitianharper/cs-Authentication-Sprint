using ConferenceManager.Data;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Text.Json;

namespace ConferenceManager.Models
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly string _filePath = "Data/AttendeeData.json";
        private readonly List<Attendee> _attendee;

        public AttendeeRepository()
        {
            var json = File.ReadAllText(_filePath);
            _attendee = JsonSerializer.Deserialize<List<Attendee>>(json) ?? new List<Attendee>();
        }

        public List<Attendee> GrabAllAttendee()
        {
          
            return _attendee ?? new List<Attendee>();

        }
        public List<Attendee> GrabAttendeeById() => _attendee;

        public Attendee? GrabAttendeeById(int attendeeId)
        {
            return _attendee.FirstOrDefault(att => att.AttendeeId == attendeeId);
        }

        public void AddAttendee(Attendee newAttendee)
        {
            var nextId = _attendee.Any() ? _attendee.Max(newAttendee => newAttendee.AttendeeId) + 1 : 1;
            newAttendee.AttendeeId = nextId;
            _attendee.Add(newAttendee);
        }
    }

}