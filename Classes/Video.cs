using System.Collections.Generic;

namespace DotnetDB_MovieLibraryAb_HeilAdam
{
    public class Video : Media
    {
        public List<string> format { get; set; }
        public int length { get; set; }
        public List<string> regions { get; set; }
        public Video() {
            format = new List<string>();
            regions = new List<string>();
        }
        public string toString() {
            return $"VideoID: {mediaId} Title: {title} Format(s): {string.Join(", ", format)} Length: {length} minute(s) Region(s): {string.Join(", ", regions)}\n";
        }
    }
}