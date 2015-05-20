using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;

namespace TwitchAPI
{
    public class TwitchController : ApiController
    {
        // GET api/<controller>
        public async Task<StreamResponse> GetStreamer(int id)
        {
            using (HttpClient cli = new HttpClient())
                return await cli.GetAsync(
            {

            } 
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
    }
}