using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotnetDB_MovieLibraryAb_HeilAdam
{
    public class ShowList
    {
        public string path { get; set; }
        public List<Show> showList { get; set; }
        public ShowList(string path) {
            showList = new List<Show>();
            this.path = path;
            StreamReader sr = new StreamReader(path);
            sr.ReadLine();
            while (!sr.EndOfStream) {
                Show show = new Show();
                string line = sr.ReadLine();
                int lineIndex = line.IndexOf('"');
                if (lineIndex == -1) {
                    string[] showSplit = line.Split(',');
                    show.mediaId = Int32.Parse(showSplit[0]);
                    show.title = showSplit[1];
                    show.season = Int32.Parse(showSplit[2]);
                    show.episode = Int32.Parse(showSplit[3]);
                    show.writers = showSplit[4].Split('|').ToList();
                }
                else {
                    show.mediaId = Int32.Parse(line.Substring(0, lineIndex - 1));
                    line = line.Substring(lineIndex + 1);
                    lineIndex = line.IndexOf('"');
                    show.title = line.Substring(0, lineIndex);
                    line = line.Substring(lineIndex + 2);
                    show.season = Int32.Parse(line.Substring(0, lineIndex + 1));
                    line = line.Substring(lineIndex + 3);
                    show.episode = Int32.Parse(line.Substring(0, lineIndex + 2));
                    line = line.Substring(lineIndex + 4);
                    show.writers = line.Split('|').ToList();

                }
                showList.Add(show);
            }
            sr.Close();
        }
    }
}