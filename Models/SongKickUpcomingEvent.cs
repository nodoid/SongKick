using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace mvvmframework
{
    public class UpcomingEvent_Start
    {
        public string time { get; set; }
        public string date { get; set; }
        public string datetime { get; set; }
    }

    public class UpcomingEvent_Identifier
    {
        public string href { get; set; }
        public string mbid { get; set; }
    }

    public class UpcomingEvent_Artist
    {
        public List<UpcomingEvent_Identifier> identifier { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public string displayName { get; set; }
    }

    public class UpcomingEvent_Performance
    {
        public string billing { get; set; }
        public int billingIndex { get; set; }
        public int id { get; set; }
        public UpcomingEvent_Artist artist { get; set; }
        public string displayName { get; set; }
    }

    public class UpcomingEvent_Country
    {
        public string displayName { get; set; }
    }

    public class UpcomingEvent_City
    {
        public string displayName { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public UpcomingEvent_Country country { get; set; }
    }

    public class UpcomingEvent_Country2
    {
        public string displayName { get; set; }
    }

    public class UpcomingEvent_MetroArea
    {
        public string displayName { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public UpcomingEvent_Country2 country { get; set; }
    }

    public class UpcomingEvent_Venue
    {
        public double lng { get; set; }
        public int capacity { get; set; }
        public string zip { get; set; }
        public string description { get; set; }
        public string street { get; set; }
        public string displayName { get; set; }
        public string website { get; set; }
        public UpcomingEvent_City city { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public UpcomingEvent_MetroArea metroArea { get; set; }
        public string phone { get; set; }
        public double lat { get; set; }
    }

    public class UpcomingEvent_Location
    {
        public string city { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class UpcomingEvent_Event
    {
        public string type { get; set; }
        public object ageRestriction { get; set; }
        public string status { get; set; }
        public UpcomingEvent_Start start { get; set; }
        public List<UpcomingEvent_Performance> performance { get; set; }
        public UpcomingEvent_Venue venue { get; set; }
        public UpcomingEvent_Location location { get; set; }
        public string uri { get; set; }
        public double popularity { get; set; }
        public int id { get; set; }
        public string displayName { get; set; }
    }

    public class UpcomingEvent_Results
    {
        [JsonProperty("event")]
        public UpcomingEvent_Event UpcomingEvent_Event { get; set; }
    }

    public class UpcomingEvent_ResultsPage
    {
        public string status { get; set; }
        public UpcomingEvent_Results results { get; set; }
    }

    public class UpcomingEvent
    {
        public UpcomingEvent_ResultsPage resultsPage { get; set; }
    }
}
