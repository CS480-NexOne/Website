﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexOneVS.Models.Movie;
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
        //private string apikey = System.Configuration.ConfigurationManager.AppSettings["MovieDB_API_Key"].ToString();
        private string apikey = "becd4a5c2dc9c687bd6727ff81c7ad2e";
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
                return View(mymodel);
            }
            catch (Exception)
            {
                return View();
            }

            

        }

        public Title getTitle(string id)
        {

            string url = string.Format("http://api.themoviedb.org/3/movie/{0}?api_key={1}", id, apikey);

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

                    Title title = new Title();

                    title = JsonConvert.DeserializeObject<Title>(json);

                    return title;
                }
            }

            catch (WebException ex)
            {
                return null;
            }

            //return View(Url.RequestContext.RouteData.Values["id"]);
        }

        public Video getVideo(string id)
        {

            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/videos?api_key={1}", id, apikey);

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

                    Video vid = new Video();

                    vid = JsonConvert.DeserializeObject<Video>(json);

                    return vid;
                }
            }

            catch (WebException ex)
            {
                return null;
            }

            //return View(Url.RequestContext.RouteData.Values["id"]);
        }

        public Similar getSimilar(string id)
        {

            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/similar?api_key={1}", id, apikey);

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

                    Similar sim = new Similar();

                    sim = JsonConvert.DeserializeObject<Similar>(json);

                    return sim;
                }
            }

            catch (WebException ex)
            {
                return null;
            }

            //return View(Url.RequestContext.RouteData.Values["id"]);
        }

        public Image getImage(string id)
        {

            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/images?api_key={1}", id, apikey);

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

                    Image img = new Image();

                    img = JsonConvert.DeserializeObject<Image>(json);

                    return img;
                }
            }

            catch (WebException ex)
            {
                return null;
            }

            //return View(Url.RequestContext.RouteData.Values["id"]);
        }


        public Credit getCredit(string id)  
        {

            string url = string.Format("http://api.themoviedb.org/3/movie/{0}/credits?api_key={1}", id, apikey);

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

                    Credit credit = new Credit();

                    credit = JsonConvert.DeserializeObject<Credit>(json);

                    return credit;
                }
            }

            catch (WebException ex)
            {
                return null;
            }

        }

        public MovieDB getNew()
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

        public MovieDB getMoviesWithCategory()
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