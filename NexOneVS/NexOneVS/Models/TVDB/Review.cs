using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexOneVS.Models.TV
{

    public class Review
    {
        public int id { get; set; }
        public int page { get; set; }
        public Result[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }

        public class Result
        {
            public string id { get; set; }
            public string author { get; set; }
            public string content { get; set; }
            public string url { get; set; }
        }
    }

    

}