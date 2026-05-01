using ConferenceManager.Data;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Text.Json;

namespace ConferenceManager.Models
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly string _filePath = "Data/SpeakerData.json";
        private readonly List<Speaker> _speaker;

        public SpeakerRepository()
        {
            var json = File.ReadAllText(_filePath);
            _speaker = JsonSerializer.Deserialize<List<Speaker>>(json) ?? new List<Speaker>();
        }

        public List<Speaker> GrabAllSpeaker()
        {
          
            return _speaker ?? new List<Speaker>();

        }
        public List<Speaker> GrabSpeakerById() => _speaker;

        public Speaker? GrabSpeakerById(int speakerId)
        {
            return _speaker.FirstOrDefault(spe => spe.SpeakerId == speakerId);
        }

        public void AddSpeaker(Speaker newSpeaker)
        {
            var nextId = _speaker.Any() ? _speaker.Max(newSpeaker => newSpeaker.SpeakerId) + 1 : 1;
            newSpeaker.SpeakerId = nextId;
            _speaker.Add(newSpeaker);
        }
    }

}