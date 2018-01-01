using System;
namespace mvvmframework
{
    public class StudioSchedule
    {
        public DateTime Brodacast { get; set; }
        public string Artist { get; set; }
        public string Track { get; set; }
        public bool UpVote { get; set; }
        public bool DownVote { get; set; }
        public bool CanBeVotedOn { get; set; }
        public int Programme { get; set; }
    }
}
