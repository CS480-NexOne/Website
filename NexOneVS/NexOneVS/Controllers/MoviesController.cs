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
using System.Dynamic;
using NexOneVS.ViewModels;

namespace NexOneVS.Controllers
{
    public class MoviesController : Controller
    {
        private string apikey = System.Configuration.ConfigurationManager.AppSettings["MovieDB_API_Key"].ToString();
        // GET: Movies
        public ActionResult Index()
        {
            ViewModel mymodel = new ViewModel();  //to add more than 1 models in view
            mymodel.Movies = getNew();
            mymodel.Genres = getGenreList();
            
            return View(mymodel);
        }

        private MovieDB getNew()
        {
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
            }
        }

        private MovieDB getMoviesWithCategory()
        {

            return null;
        }

        private MovieDB_Genre getGenreList()
        {
            string url = string.Format("http://api.themoviedb.org/3/genre/movie/list?&api_key={0}", apikey);

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

                    MovieDB_Genre genrelist = new MovieDB_Genre();

                    genrelist = JsonConvert.DeserializeObject<MovieDB_Genre>(json);

                    return genrelist;
                }

            }

            catch (WebException ex)
            {
                return null;
            }
        }
    }
}