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
using NexOneVS.Models.Game;

namespace NexOneVS.Controllers
{
    public class GamesController : Controller
    {
        //private string apikey = System.Configuration.ConfigurationManager.AppSettings["MovieDB_API_Key"].ToString();
        private string apikey = "5195eec3fb1e59945f162c69ea935220a616fd95";

        // GET: Movies
        public ActionResult Index()
        {
            GameModel gameModel = new GameModel();

            gameModel.SearchDB = getNew();

            return View(gameModel);
        }

        public SearchGameDB getNew()
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

                    SearchGameDB gdb = new SearchGameDB();

                    gdb = JsonConvert.DeserializeObject<SearchGameDB>(json);

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