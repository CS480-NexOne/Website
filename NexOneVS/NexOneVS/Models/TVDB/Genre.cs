﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexOneVS.Models.TV
{

    public class TVDB_Genre
    {
        public Genre[] genres { get; set; }

        
    }
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}