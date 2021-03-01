using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotnetDB_MovieLibraryAb_HeilAdam
{
    public class VideoList
    {
        public string path { get; set; }
        public List<Video> videoList { get; set; }
        public VideoList(string path) {
            videoList = new List<Video>();
            this.path = path;
            StreamReader sr = new StreamReader(path);
            sr.ReadLine();
            while (!sr.EndOfStream) {
                Video video = new Video();
                string line = sr.ReadLine();
                int lineIndex = line.IndexOf('"');
                if (lineIndex == -1) {
                    string[] videoSplit = line.Split(',');
                    video.mediaId = Int32.Parse(videoSplit[0]);
                    video.title = videoSplit[1];
                    video.format = videoSplit[2].Split('|').ToList();
                    video.length = Int32.Parse(videoSplit[3]);
                    video.regions = videoSplit[4].Split('|').ToList();
                }
                else {
                    video.mediaId = Int32.Parse(line.Substring(0, lineIndex - 1));
                    line = line.Substring(lineIndex + 1);
                    lineIndex = line.IndexOf('"');
                    video.title = line.Substring(0, lineIndex);
                    line = line.Substring(lineIndex + 2);
                    video.format = line.Split('|').ToList();
                    line = line.Substring(lineIndex + 3);
                    video.length = Int32.Parse(line.Substring(0, lineIndex + 2));
                    line = line.Substring(lineIndex + 4);
                    video.regions = line.Split('|').ToList();

                }
                videoList.Add(video);
            }
            sr.Close();
        }
    }
}