using System.Collections.Generic;

namespace DotnetDB_MovieLibraryAb_HeilAdam
{
    public class Show : Media
    {
        public int season { get; set; }
        public int episode { get; set; }
        public List<string> writers { get; set; }
        public Show() {
            writers = new List<string>();
        }
        public string toString() {
            return $"ShowID: {mediaId} Title: {title} Season: {season} Episode: {episode} Writer(s): {string.Join(", ", writers)}\n";
        }
    }
}