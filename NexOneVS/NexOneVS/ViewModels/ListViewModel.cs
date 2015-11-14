using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NexOneVS.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<NexOneVS.Models.Queue> Queue { get; set; }
        public IEnumerable<NexOneVS.Models.Queue> WatchedQueue { get; set; }
    }
}