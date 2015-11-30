using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexOneVS.Models.Game
{
    public class Video
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
            public string api_detail_url { get; set; }
            public string deck { get; set; }
            public string high_url { get; set; }
            public string low_url { get; set; }
            public string embed_player { get; set; }
            public int id { get; set; }
            public int length_seconds { get; set; }
            public string name { get; set; }
            public string publish_date { get; set; }
            public string site_detail_url { get; set; }
            public string url { get; set; }
            public Image image { get; set; }
            public string user { get; set; }
            public string video_type { get; set; }
            public string youtube_id { get; set; }
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