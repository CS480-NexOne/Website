using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexOneVS.Models.Game
{
    public class SimilarGame
    {
        public string error { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int number_of_page_results { get; set; }
        public int number_of_total_results { get; set; }
        public int status_code { get; set; }
        public Results results { get; set; }
        public string version { get; set; }

        public class Results
        {
            public int id { get; set; }
            public Image image { get; set; }
        }

        public class Image
        {
            public string icon_url { get; set; }
            public string medium_url { get; set; }
            public string screen_url { get; set; }
            public string small_url { get; set; }
            public string super_url { get; set; }
            public string thumb_url { get; set; }
            public string tiny_url { get; set; }
        }
    }
}