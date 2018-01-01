using System.Collections.Generic;

namespace mvvmframework
{
    public class Artists_Details
    {
        public string displayName { get; set; }
        public string uri { get; set; }
        public List<object> identifier { get; set; }
        public int id { get; set; }
        public object onTourUntil { get; set; }
    }

    public class Artists_Results
    {
        public List<Artists_Details> artist { get; set; }
    }

    public class Artists_ResultsPage
    {
        public string status { get; set; }
        public Artists_Results results { get; set; }
        public int perPage { get; set; }
        public int page { get; set; }
        public int totalEntries { get; set; }
    }

    public class Artists
    {
        public Artists_ResultsPage resultsPage { get; set; }
    }
}
