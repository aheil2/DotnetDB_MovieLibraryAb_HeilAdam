using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotnetDB_MovieLibraryAb_HeilAdam
{
    public class MovieList
    {
        public string path { get; set; }
        public List<Movie> movieList { get; set; }
        public MovieList(string path) {
            movieList = new List<Movie>();
            this.path = path;
            StreamReader sr = new StreamReader(path);
            sr.ReadLine();
            while (!sr.EndOfStream) {
                Movie movie = new Movie();
                string line = sr.ReadLine();
                int lineIndex = line.IndexOf('"');
                if (lineIndex == -1) {
                    string[] movieSplit = line.Split(',');
                    movie.mediaId = Int32.Parse(movieSplit[0]);
                    movie.title = movieSplit[1];
                    movie.genres = movieSplit[2].Split('|').ToList();
                }
                else {
                    movie.mediaId = Int32.Parse(line.Substring(0, lineIndex - 1));
                    line = line.Substring(lineIndex + 1);
                    lineIndex = line.IndexOf('"');
                    movie.title = line.Substring(0, lineIndex);
                    line = line.Substring(lineIndex + 2);
                    movie.genres = line.Split('|').ToList();
                }
                movieList.Add(movie);
            }
            sr.Close();
        }
    }
}