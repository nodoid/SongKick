using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace mvvmframework
{
    public class Video
    {
        public int? upload_date { get; set; }
        public string playlist { get; set; }
        public string description { get; set; }
        public string view_count { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string thumbnail { get; set; }
        public string webpage_url { get; set; }
        [Ignore]
        public List<Format> formats { get; set; }
        public int duration { get; set; }
        public string uploader { get; set; }
        public int playlist_index { get; set; }
    }
}
