using NexOneVS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NexOneVS.Models.Game;

namespace NexOneVS.GameModels
{
    public class GameModel
    {
        public SearchGameDB SearchDB { get; set; }
        public GameDetail gd { get; set; }

        public List<Video> Videos;

        public List<SimilarGame> sg;
        
        public GameModel()
        {
            Videos = new List<Video>();
            sg = new List<SimilarGame>();

        }
    }
}