using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexOneVS.Models;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;

namespace NexOneVS.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            Movie movie = new Movie()
            {
                Name = "The Godfather",
                Genre = new[] {
                    new Genre { Name = "Crime"}, 
                    new Genre { Name = "Drama"}},
                Year = 1989,
                Rating = 9.2
            };
            //return Json(movie, JsonRequestBehavior.AllowGet);
            MovieDB x = getNew();
            return View(x);
        }

        private MovieDB getNew()
        {
            string apikey = System.Configuration.ConfigurationManager.AppSettings["MovieDB_API_Key"].ToString();
            string url = string.Format("http://api.themoviedb.org/3/movie/now_playing?&api_key={0}", apikey);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response;

            try
            {
                response = request.GetResponse() as HttpWebResponse;

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    String json = reader.ReadToEnd();
                    JObject jobj = (JObject)JsonConvert.DeserializeObject(json);

                    MovieDB mdb = new MovieDB();

                    mdb = JsonConvert.DeserializeObject<MovieDB>(json);

                    return mdb;
                  


                }
                
            }

            catch (WebException ex)
            {
                return null;

                //HttpWebResponse webResponse = (HttpWebResponse)ex.Response;
                //if (webResponse.StatusCode == HttpStatusCode.NotFound)
                //{
                //    Label1.Text = "Summoner not found.";
                //    return;
                //}
                //else
                //{
                //    Label1.Text = "An error has occured.";
                //    return;
                //}

            }
        }
    }
}