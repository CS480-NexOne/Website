using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NexOneVS.Models.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using NexOneVS.GameModels;
using NexOneVS.Utility;
using NexOneVS.Models;
using Microsoft.AspNet.Identity;

namespace NexOneVS.Controllers
{
    public class GamesController : Controller
    {
        private string apikey = "5195eec3fb1e59945f162c69ea935220a616fd95";
        private QueueContext db = new QueueContext();

        // GET: Movies
        public ActionResult Index()
        {
            GameModel gameModel = new GameModel();

            gameModel.SearchDB = getNew();

            return View(gameModel);
        }

        public ActionResult Title()
        {
            try
            {
                string gameID = Url.RequestContext.RouteData.Values["id"].ToString();
                GameModel gameModel = new GameModel();
                gameModel.gd = getDetail(gameID);
                // Getting Video Links
                if(gameModel.gd.results.videos != null)
                {
                    gameModel.Videos = new List<Video>();
                    foreach(GameDetail.Video video in gameModel.gd.results.videos)
                    {
                        string url = string.Format("http://www.giantbomb.com/api/video/2300-{0}/?api_key={1}&format=json", video.id, apikey);

                        gameModel.Videos.Add((Video)JsonConvert.DeserializeObject<Video>(ApiCall.ApiGET(url)));
                    }
                }

                if (gameModel.gd.results.similar_games != null)
                {
                    gameModel.sg = new List<SimilarGame>();
                    foreach (GameDetail.Similar_Games sg in gameModel.gd.results.similar_games)
                    {
                        string url = string.Format("http://www.giantbomb.com/api/game/3030-{0}/?api_key={1}&format=json&field_list=image,id", sg.id, apikey);
                        gameModel.sg.Add((SimilarGame)JsonConvert.DeserializeObject<SimilarGame>(ApiCall.ApiGET(url)));
                    }
                }

                return View(gameModel);
            }
            catch (Exception ex)
            {
                GameModel gameModel = new GameModel();
                gameModel.gd = new GameDetail();
                return View(gameModel);
            }
        }

        public ActionResult Search(string query)
        {
            ViewBag.Query = query;
            string url = string.Format("http://www.giantbomb.com/api/search?api_key={0}&format=json&query={1}&resources=game", apikey, query);

            GameModel searchList = new GameModel();
            searchList.SearchDB = JsonConvert.DeserializeObject<SearchGameDB>(ApiCall.ApiGET(url));

            return View(searchList);
        }

        public SearchGameDB getNew()
        {
            string url = string.Format("http://www.giantbomb.com/api/games/?api_key={0}&sort=original_release_date:desc&format=json&limit=50&filter=original_release_date:1990-1-1|2015-10-1", apikey);

            SearchGameDB gdb = new SearchGameDB();
            gdb = JsonConvert.DeserializeObject<SearchGameDB>(ApiCall.ApiGET(url));
            return gdb;
        }

        public GameDetail getDetail(string id)
        {
            string url = string.Format("http://www.giantbomb.com/api/game/3030-{0}/?api_key={1}&format=json&field_list=deck,genres,id,image,images,name,original_game_rating,original_release_date,similar_games,site_detail_url,themes,videos,platforms", id, apikey);

            GameDetail temp = new GameDetail();
            temp = JsonConvert.DeserializeObject<GameDetail>(ApiCall.ApiGET(url));
            return temp;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToList(int id, string name, string image)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/Movies/Title/" + id.ToString() });

            }

            Queue item = new Queue()
            {
                IDforAPI = id.ToString(),
                Type = "Game",
                CreatedDate = DateTime.Now,
                UserID = User.Identity.GetUserId(),
                ImagePath = image,
                ItemName = name,
                Watched = false
            };


            db.Queues.Add(item);
            db.SaveChanges();
            //return RedirectToAction("Index");

            //ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", queue.UserID);
            return RedirectToAction("MyList", "Manage");
        }
    }
}