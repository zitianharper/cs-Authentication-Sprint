using ConferenceManager.Data;
using System.Collections.Generic;

namespace ConferenceManager.Models
{
    public interface ISpeakerRepository
    {
        List<Speaker> GrabAllSpeaker();
        Speaker? GrabSpeakerById(int id);
        void AddSpeaker(Speaker newSpeaker);

    }
}
