using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace mvvmframework
{
    public class ArtistSearch_Artist
    {
        public string displayName { get; set; }
        public string onTourUntil { get; set; }
        public string uri { get; set; }
        public int id { get; set; }
        public List<object> identifier { get; set; }
    }

    public class ArtistSearch_Results
    {
        public List<ArtistSearch_Artist> artist { get; set; }
    }

    public class ArtistSearch_ResultsPage
    {
        public string status { get; set; }
        public ArtistSearch_Results results { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int totalEntries { get; set; }
    }

    public class ArtistSearch
    {
        public ArtistSearch_ResultsPage resultsPage { get; set; }
    }
}
