using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace mvvmframework
{
    public class MetroAreaEvents_Country
    {
        public string displayName { get; set; }
    }

    public class MetroAreaEvents_MetroArea
    {
        public MetroAreaEvents_Country country { get; set; }
        public string displayName { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
    }

    public class MetroAreaEvents_Venue
    {
        public MetroAreaEvents_MetroArea metroArea { get; set; }
        public double? lat { get; set; }
        public string displayName { get; set; }
        public string uri { get; set; }
        public double? lng { get; set; }
        public int? id { get; set; }
        public string type { get; set; }
    }

    public class MetroAreaEvents_Start
    {
        public string time { get; set; }
        public string datetime { get; set; }
        public string date { get; set; }
    }

    public class MetroAreaEvents_Location
    {
        public string city { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }
    }

    public class MetroAreaEvents_Artist
    {
        public string displayName { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public List<object> identifier { get; set; }
    }

    public class MetroAreaEvents_Performance
    {
        public MetroAreaEvents_Artist artist { get; set; }
        public string displayName { get; set; }
        public int billingIndex { get; set; }
        public string billing { get; set; }
        public int id { get; set; }
    }

    public class MetroAreaEvents_End
    {
        public object time { get; set; }
        public object datetime { get; set; }
        public string date { get; set; }
    }

    public class Series
    {
        public string displayName { get; set; }
    }

    public class MetroAreaEvents_Event
    {
        public MetroAreaEvents_Venue venue { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public MetroAreaEvents_Start start { get; set; }
        public double popularity { get; set; }
        public MetroAreaEvents_Location location { get; set; }
        public string displayName { get; set; }
        public string ageRestriction { get; set; }
        public string uri { get; set; }
        public List<MetroAreaEvents_Performance> performance { get; set; }
        public int id { get; set; }
    }

    public class MetroAreaEvents_Results
    {
        [JsonProperty("event")]
        public List<MetroAreaEvents_Event> MetroAreaEvents_Event { get; set; }
    }

    public class MetroAreaEvents_ResultsPage
    {
        public string status { get; set; }
        public MetroAreaEvents_Results results { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int totalEntries { get; set; }
    }

    public class MetroAreaEvents
    {
        public MetroAreaEvents_ResultsPage resultsPage { get; set; }
    }
}
