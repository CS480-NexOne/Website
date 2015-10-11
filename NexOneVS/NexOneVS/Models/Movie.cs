using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexOneVS.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public Genre [] Genre { get; set; }
        public int Year { get; set; }

    }
}