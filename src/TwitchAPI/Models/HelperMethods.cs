using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace TwitchAPI.Models
{
    public class HelperMethods
    {
        public static async Task<string> HttpGet(Uri uri)
        {
            using (HttpClient cli = new HttpClient())
            {
                string responseString;
                var r = await cli.GetAsync(uri);

                if (r.StatusCode == HttpStatusCode.OK)
                {
                    responseString = await r.Content.ReadAsStringAsync();
                    return responseString;
                }
                else
                {
                    responseString = "HTTP GET Failure";
                }
                return responseString;
            }
        }
    }
}
