using System.Collections.Generic;

namespace DotnetDB_MovieLibraryAb_HeilAdam
{
    public class Movie : Media
    {
        public List<string> genres { get; set; }
        public Movie() {
            genres = new List<string>();
        }
        public string toString() {
            return $"MovieID: {mediaId} Title: {title} Genre(s): {string.Join(", ", genres)}\n";
        }
    }
}