using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NexOneVS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NexOneVS.Controllers
{
    public class GamesController : Controller
    {
        //private string apikey = System.Configuration.ConfigurationManager.AppSettings["MovieDB_API_Key"].ToString();
        private string apikey = "5195eec3fb1e59945f162c69ea935220a616fd95";

        // GET: Movies
        public ActionResult Index()
        {
            GameDB mygames = getNew();
            //GameDB.Rootobject myGames = getNew();

            return View(mygames);
        }

        public GameDB getNew()
        {
            string url = "http://www.giantbomb.com/api/search/?api_key=5195eec3fb1e59945f162c69ea935220a616fd95&resources=game&format=json&query=%22fallout%22";

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

                    GameDB gdb = new GameDB();

                    gdb = JsonConvert.DeserializeObject<GameDB>(json);

                    return gdb;
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }
    }
}