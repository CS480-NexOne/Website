using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexOneVS.Models;

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
                Genre = new [] {
                    new Genre { Name = "Crime"}, 
                    new Genre { Name = "Drama"}},                    
                Year = 1989, 
                Rating = 9.2 
            };            
            return Json(movie, JsonRequestBehavior.AllowGet);
        } 
    }
}