using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexOneVS.Models.Game
{
    public class GameDetail
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
            public string deck { get; set; }
            public int id { get; set; }
            public Image image { get; set; }
            public string name { get; set; }
            public Original_Game_Rating[] original_game_rating { get; set; }
            public string original_release_date { get; set; }
            public Platform[] platforms { get; set; }
            public string site_detail_url { get; set; }
            public Image1[] images { get; set; }
            public Video[] videos { get; set; }
            public Genre[] genres { get; set; }
            public Similar_Games[] similar_games { get; set; }
            public Theme[] themes { get; set; }
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

        public class Original_Game_Rating
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }

        public class Platform
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string site_detail_url { get; set; }
            public string abbreviation { get; set; }
        }

        public class Image1
        {
            public string icon_url { get; set; }
            public string medium_url { get; set; }
            public string screen_url { get; set; }
            public string small_url { get; set; }
            public string super_url { get; set; }
            public string thumb_url { get; set; }
            public string tiny_url { get; set; }
            public string tags { get; set; }
        }

        public class Video
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string site_detail_url { get; set; }
        }

        public class Genre
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string site_detail_url { get; set; }
        }

        public class Similar_Games
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string site_detail_url { get; set; }
        }

        public class Theme
        {
            public string api_detail_url { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string site_detail_url { get; set; }
        }
    }
}