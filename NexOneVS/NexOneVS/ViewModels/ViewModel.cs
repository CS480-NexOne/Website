using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NexOneVS.Models.Movie;

namespace NexOneVS.ViewModels
{
    public class ViewModel
    {
        public MovieDB Movies { get; set; }
        public MovieDB_Genre Genres { get; set; }
        public Title Title { get; set; }
        public Credit Credit { get; set; }
        public Video Video { get; set; }
        public Image Image { get; set; }
        public Similar Similar { get; set; }
        public Review Review { get; set; }

    }
}