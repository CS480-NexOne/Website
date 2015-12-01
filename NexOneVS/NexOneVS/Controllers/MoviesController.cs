using System;
using System.Web.Mvc;
using NexOneVS.Models.Movie;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;
using NexOneVS.ViewModels;
using NexOneVS.Models;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using NexOneVS.Utility;

namespace NexOneVS.Controllers
{
    public class MoviesController : Controller
    {
        //private string apikey = System.Configuration.ConfigurationManager.AppSettings["MovieDB_API_Key"].ToString();
        private string apikey = "becd4a5c2dc9c687bd6727ff81c7ad2e";
        private QueueContext db = new QueueContext();
        MovieDB mdb = MovieDB.Instance;
        // GET: Movies
        public ActionResult Index()
        {
            ViewModel mymodel = new ViewModel();  //to add more than 1 models in view
            mymodel.Movies = getNew();
            mymodel.Genres = getGenreList();

            return View(mymodel);
        }
        public ActionResult Title()
        {
            string movieID;
            try
            {
                movieID = Url.RequestContext.RouteData.Values["id"].ToString();
                ViewModel mymodel = new ViewModel();  //to add more than 1 models in view
                mymodel.Title = getTitle(movieID);
                mymodel.Credit = getCredit(movieID);
                mymodel.Video = getVideo(movieID);
                mymodel.Image = getImage(movieID);
                mymodel.Similar = getSimilar(movieID);
                mymodel.Review = getReview(movieID);
                return View(mymodel);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Search(string query)
        {
            ViewBag.Query = query;
            string url = string.Format("http://api.themoviedb.org/3/search/movie?&api_key={0}&query={1}", apikey, query);

            SearchViewModel svm = new SearchViewModel();
            svm.Movies = JsonConvert.DeserializeObject<MovieDB>(ApiCall.ApiGET(url));
            svm.Query = query;

            return View(svm);
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
                Type = "Movie",
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
            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/reviews?api_key={1}", id, apikey);

            Review review = new Review();
            review = JsonConvert.DeserializeObject<Review>(ApiCall.ApiGET(url));
            return review;
        }

        public Title getTitle(string id)
        {
            string url = string.Format("http://api.themoviedb.org/3/movie/{0}?api_key={1}", id, apikey);

            Title title = new Title();
            title = JsonConvert.DeserializeObject<Title>(ApiCall.ApiGET(url));
            return title;
        }

        public Video getVideo(string id)
        {
            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/videos?api_key={1}", id, apikey);

            Video vid = new Video();
            vid = JsonConvert.DeserializeObject<Video>(ApiCall.ApiGET(url));
            return vid;
        }

        public Similar getSimilar(string id)
        {
            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/similar?api_key={1}", id, apikey);

            Similar sim = new Similar();
            sim = JsonConvert.DeserializeObject<Similar>(ApiCall.ApiGET(url));
            return sim;

        }

        public Image getImage(string id)
        {
            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/images?api_key={1}", id, apikey);

            Image img = new Image();
            img = JsonConvert.DeserializeObject<Image>(ApiCall.ApiGET(url));
            return img;
        }


        public Credit getCredit(string id)
        {
            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/credits?api_key={1}", id, apikey);

            Credit credit = new Credit();
            credit = JsonConvert.DeserializeObject<Credit>(ApiCall.ApiGET(url));
            return credit;

        }

        public MovieDB getNew()
        {
            string url = string.Format("http://api.themoviedb.org/3/movie/now_playing?&api_key={0}", apikey);

            mdb = JsonConvert.DeserializeObject<MovieDB>(ApiCall.ApiGET(url));
            return mdb;
        }

        private MovieDB_Genre getGenreList()
        {
            string url = string.Format("http://api.themoviedb.org/3/genre/movie/list?&api_key={0}", apikey);

            MovieDB_Genre genrelist = new MovieDB_Genre();
            genrelist = JsonConvert.DeserializeObject<MovieDB_Genre>(ApiCall.ApiGET(url));
            return genrelist;
        }
    }
}