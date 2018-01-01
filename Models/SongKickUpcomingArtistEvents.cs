using System.Collections.Generic;

namespace mvvmframework
{
    public class UpcomingArtistEvent_Artist
    {
        public string displayName { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public List<object> identifier { get; set; }
    }

    public class UpcomingArtistEvent_Performance
    {
        public string billing { get; set; }
        public string displayName { get; set; }
        public int billingIndex { get; set; }
        public UpcomingArtistEvent_Artist artist { get; set; }
        public int id { get; set; }
    }

    public class UpcomingArtistEvent_Start
    {
        public string time { get; set; }
        public string datetime { get; set; }
        public string date { get; set; }
    }

    public class UpcomingArtistEvent_Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string city { get; set; }
    }

    public class UpcomingArtistEvent_Country
    {
        public string displayName { get; set; }
    }

    public class UpcomingArtistEvent_State
    {
        public string displayName { get; set; }
    }

    public class UpcomingArtistEvent_MetroArea
    {
        public string displayName { get; set; }
        public UpcomingArtistEvent_Country country { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public UpcomingArtistEvent_State state { get; set; }
    }

    public class UpcomingArtistEvent_Venue
    {
        public double? lat { get; set; }
        public double? lng { get; set; }
        public string displayName { get; set; }
        public string uri { get; set; }
        public UpcomingArtistEvent_MetroArea metroArea { get; set; }
        public int? id { get; set; }
    }

    public class UpcomingArtistEvent_End
    {
        public object time { get; set; }
        public object datetime { get; set; }
        public string date { get; set; }
    }

    public class UpcomingArtistEvent_Series
    {
        public string displayName { get; set; }
    }

    public class UpcomingArtistEvent_Event
    {
        public string type { get; set; }
        public List<UpcomingArtistEvent_Performance> performance { get; set; }
        public string status { get; set; }
        public string displayName { get; set; }
        public UpcomingArtistEvent_Start start { get; set; }
        public bool? ageRestriction { get; set; }
        public UpcomingArtistEvent_Location location { get; set; }
        public UpcomingArtistEvent_Venue venue { get; set; }
        public double popularity { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public UpcomingArtistEvent_End end { get; set; }
        public UpcomingArtistEvent_Series series { get; set; }
    }

    public class UpcomingArtistEvent_Results
    {
        public List<UpcomingArtistEvent_Event> Event { get; set; }
    }

    public class UpcomingArtistEvent_ResultsPage
    {
        public string status { get; set; }
        public UpcomingArtistEvent_Results results { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int totalEntries { get; set; }
    }

    public class UpcomingArtistEvent
    {
        public UpcomingArtistEvent_ResultsPage resultsPage { get; set; }
    }
}
