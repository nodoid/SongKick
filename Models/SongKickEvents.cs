using System.Collections.Generic;
using Newtonsoft.Json;

namespace mvvmframework
{
    public class UpcomingVenueEvents_Start
    {
        public string time { get; set; }
        public string datetime { get; set; }
        public string date { get; set; }
    }

    public class UpcomingVenueEvents_Location
    {
        public string city { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class UpcomingVenueEvents_Artist
    {
        public string uri { get; set; }
        public int id { get; set; }
        public List<object> identifier { get; set; }
        public string displayName { get; set; }
    }

    public class UpcomingVenueEvents_Performance
    {
        public int billingIndex { get; set; }
        public UpcomingVenueEvents_Artist artist { get; set; }
        public string billing { get; set; }
        public int id { get; set; }
        public string displayName { get; set; }
    }

    public class UpcomingVenueEvents_Country
    {
        public string displayName { get; set; }
    }

    public class UpcomingVenueEvents_MetroArea
    {
        public UpcomingVenueEvents_Country country { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public string displayName { get; set; }
    }

    public class UpcomingVenueEvents_Venue
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public UpcomingVenueEvents_MetroArea metroArea { get; set; }
        public string displayName { get; set; }
    }

    public class UpcomingVenueEvents_Event
    {
        public string type { get; set; }
        public string ageRestriction { get; set; }
        public string status { get; set; }
        public double popularity { get; set; }
        public UpcomingVenueEvents_Start start { get; set; }
        public UpcomingVenueEvents_Location location { get; set; }
        public string uri { get; set; }
        public List<UpcomingVenueEvents_Performance> performance { get; set; }
        public int id { get; set; }
        public UpcomingVenueEvents_Venue venue { get; set; }
        public string displayName { get; set; }
    }

    public class UpcomingVenueEvents_Results
    {
        [JsonProperty("event")]
        public List<UpcomingVenueEvents_Event> UpcomingVenueEvents_Event { get; set; }
    }

    public class UpcomingVenueEvents_ResultsPage
    {
        public string status { get; set; }
        public UpcomingVenueEvents_Results results { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int totalEntries { get; set; }
    }

    public class UpcomingVenueEvents
    {
        public UpcomingVenueEvents_ResultsPage resultsPage { get; set; }
    }
}
