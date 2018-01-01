using System;
using System.Collections.Generic;

namespace mvvmframework
{
    public class Location_Country
    {
        public string displayName { get; set; }
    }

    public class Location_MetroArea
    {
        public Location_Country country { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }
        public string displayName { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
    }

    public class Location_Country2
    {
        public string displayName { get; set; }
    }

    public class Location_City
    {
        public Location_Country2 country { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }
        public string displayName { get; set; }
    }

    public class Location_Location
    {
        public Location_MetroArea metroArea { get; set; }
        public Location_City city { get; set; }
    }

    public class Location_Results
    {
        public List<Location_Location> location { get; set; }
    }

    public class Location_ResultsPage
    {
        public string status { get; set; }
        public Location_Results results { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int totalEntries { get; set; }
    }

    public class Location
    {
        public Location_ResultsPage resultsPage { get; set; }
    }
}
