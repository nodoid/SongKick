using System;
using System.Collections.Generic;

namespace mvvmframework
{
    public class Venues_VenueCountry
    {
        public string displayName { get; set; }
    }

    public class Venues_State
    {
        public string displayName { get; set; }
    }

    public class Venues_VenueMetroArea
    {
        public string displayName { get; set; }
        public string uri { get; set; }
        public Venues_VenueCountry country { get; set; }
        public int id { get; set; }
        public Venues_State state { get; set; }
    }

    public class Venues_VenueCountry2
    {
        public string displayName { get; set; }
    }

    public class Venues_State2
    {
        public string displayName { get; set; }
    }

    public class Venues_VenueCity
    {
        public string displayName { get; set; }
        public string uri { get; set; }
        public Venues_VenueCountry2 country { get; set; }
        public int id { get; set; }
        public Venues_State2 state { get; set; }
    }

    public class Venues_Venue
    {
        public Venues_VenueMetroArea metroArea { get; set; }
        public string phone { get; set; }
        public int? capacity { get; set; }
        public string displayName { get; set; }
        public string zip { get; set; }
        public string description { get; set; }
        public Venues_VenueCity city { get; set; }
        public double? lat { get; set; }
        public string website { get; set; }
        public string uri { get; set; }
        public double? lng { get; set; }
        public string street { get; set; }
        public int id { get; set; }
    }

    public class Venues_VenueResults
    {
        public List<Venues_Venue> venue { get; set; }
    }

    public class Venues_ResultsPage
    {
        public string status { get; set; }
        public Venues_VenueResults results { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int totalEntries { get; set; }
    }

    public class Venues
    {
        public Venues_ResultsPage resultsPage { get; set; }
    }
}
