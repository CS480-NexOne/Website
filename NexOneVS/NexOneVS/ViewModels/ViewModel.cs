using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NexOneVS.Models;

namespace NexOneVS.ViewModels
{
    public class ViewModel
    {
        public MovieDB Movies { get; set; }
        public MovieDB_Genre Genres { get; set; }
    }
}