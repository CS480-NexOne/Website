using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexOneVS.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Index()
        {
            return View();
        }

        //Please delete this when implementing this class.
        //This is for homework purpose only
        public string GetDetail()
        {
            return "wyan homework #3 api";
        }
    }
}