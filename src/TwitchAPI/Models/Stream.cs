using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchAPI.Models
{
    public class Stream : TwitchBase
    {
        [JsonProperty("stream")]
        public Dictionary<string, object> SStream { get; set; }

        public Stream(Dictionary<string,object> s)
        {
            this.SStream = s;
        }
        
        public Stream()
        {

        }

        public async Task<Stream> getStream(string n)
        {
            var u = await HelperMethods.HttpGet(new Uri(TwitchConstants.baseStreamUrl + n));
            return JsonConvert.DeserializeObject<Stream>(u);
        }


    }
}
