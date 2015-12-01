using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexOneVS.Models.TV
{

    public class Image
    {
        public int id { get; set; }
        public Backdrop[] backdrops { get; set; }
        public Poster[] posters { get; set; }
    }

    public class Backdrop
    {
        public string file_path { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public object iso_639_1 { get; set; }
        public float aspect_ratio { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class Poster
    {
        public string file_path { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string iso_639_1 { get; set; }
        public float aspect_ratio { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }

}