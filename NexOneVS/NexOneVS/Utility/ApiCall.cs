using System;
using System.IO;
using System.Net;
using System.Text;

namespace NexOneVS.Utility
{
    public class ApiCall
    {
        public static string ApiGET (string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response;

            try
            {
                response = request.GetResponse() as HttpWebResponse;

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }

            catch (WebException ex)
            {
                return "";
            }
        }
    }
}