using System;
namespace mvvmframework
{
    public class SongKickEssentialArtistEvent
    {
        public string ArtistName { get; set; }
        public string Venue { get; set; }
        public string VenueCountry { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string EventType { get; set; }
    }
}
