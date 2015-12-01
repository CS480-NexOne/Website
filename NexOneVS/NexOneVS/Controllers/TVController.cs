using System;
using System.Web.Mvc;
using NexOneVS.Models.TV;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;
using NexOneVS.ViewModels;
//using NexOneVS.Models;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using NexOneVS.Utility;

namespace NexOneVS.Controllers
{
    public class TVController : Controller
    {
        private string apikey = "becd4a5c2dc9c687bd6727ff81c7ad2e";
        private Models.QueueContext db = new Models.QueueContext();
        TVDB tvdb = TVDB.Instance;
        // GET: TV
        public ActionResult Index()
        {
            TVViewModel mymodel = new TVViewModel();  //to add more than 1 models in view
            mymodel.TV = getNew();
            mymodel.Genres = getGenreList();

            return View(mymodel);
        }
        public ActionResult Title()
        {
            string TVID;
            try
            {
                TVID = Url.RequestContext.RouteData.Values["id"].ToString();
                TVViewModel mymodel = new TVViewModel();  //to add more than 1 models in view
                mymodel.Title = getTitle(TVID);
                mymodel.Credit = getCredit(TVID);
                mymodel.Video = getVideo(TVID);
                mymodel.Image = getImage(TVID);
                mymodel.Similar = getSimilar(TVID);
                mymodel.Review = getReview(TVID);
                return View(mymodel);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Search(string query)
        {
            ViewBag.Query = query;
            string url = string.Format("https://api.themoviedb.org/3/search/tv?&api_key={0}&query={1}", apikey, query);

            TVSearchViewModel svm = new TVSearchViewModel();
            svm.TV = JsonConvert.DeserializeObject<TVDB>(ApiCall.ApiGET(url));
            svm.Query = query;

            return View(svm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToList(int id, string name, string image)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "/TV/Title/" + id.ToString() });

            }

            Models.Queue item = new Models.Queue()
            {
                IDforAPI = id.ToString(),
                Type = "TV",
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





        public Review getReview(string id)
        {
            string url = string.Format("https://api.themoviedb.org/3/tv/{0}/reviews?api_key={1}", id, apikey);

            Review review = new Review();
            review = JsonConvert.DeserializeObject<Review>(ApiCall.ApiGET(url));
            return review;
        }

        public Title getTitle(string id)
        {
            string url = string.Format("https://api.themoviedb.org/3/tv/{0}?api_key={1}", id, apikey);

            Title title = new Title();
            title = JsonConvert.DeserializeObject<Title>(ApiCall.ApiGET(url));
            return title;
        }

        public Video getVideo(string id)
        {
            string url = string.Format("https://api.themoviedb.org/3/tv/{0}/videos?api_key={1}", id, apikey);

            Video vid = new Video();
            vid = JsonConvert.DeserializeObject<Video>(ApiCall.ApiGET(url));
            return vid;
        }

        public Similar getSimilar(string id)
        {
            string url = string.Format("https://api.themoviedb.org/3/tv/{0}/similar?api_key={1}", id, apikey);

            Similar sim = new Similar();
            sim = JsonConvert.DeserializeObject<Similar>(ApiCall.ApiGET(url));
            return sim;

        }

        public Image getImage(string id)
        {
            string url = string.Format("https://api.themoviedb.org/3/tv/{0}/images?api_key={1}", id, apikey);

            Image img = new Image();
            img = JsonConvert.DeserializeObject<Image>(ApiCall.ApiGET(url));
            return img;
        }


        public Credit getCredit(string id)
        {
            string url = string.Format("https://api.themoviedb.org/3/tv/{0}/credits?api_key={1}", id, apikey);

            Credit credit = new Credit();
            credit = JsonConvert.DeserializeObject<Credit>(ApiCall.ApiGET(url));
            return credit;

        }

        public TVDB getNew()
        {
            string url = string.Format("https://api.themoviedb.org/3/tv/airing_today?&api_key={0}", apikey);

            tvdb = JsonConvert.DeserializeObject<TVDB>(ApiCall.ApiGET(url));
            return tvdb;
        }

        private TVDB_Genre getGenreList()
        {
            string url = string.Format("https://api.themoviedb.org/3/genre/tv/list?&api_key={0}", apikey);

            TVDB_Genre genrelist = new TVDB_Genre();
            genrelist = JsonConvert.DeserializeObject<TVDB_Genre>(ApiCall.ApiGET(url));
            return genrelist;
        }
    }
}