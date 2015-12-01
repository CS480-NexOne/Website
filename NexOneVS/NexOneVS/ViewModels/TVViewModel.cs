using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NexOneVS.Models.TV;

namespace NexOneVS.ViewModels
{
    public class TVViewModel
    {
        public TVDB TV { get; set; }
        public TVDB_Genre Genres { get; set; }
        public Title Title { get; set; }
        public Credit Credit { get; set; }
        public Video Video { get; set; }
        public Image Image { get; set; }
        public Similar Similar { get; set; }
        public Review Review { get; set; }

    }
}