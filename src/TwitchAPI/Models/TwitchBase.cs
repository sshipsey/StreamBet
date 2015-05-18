using Newtonsoft.Json;

namespace TwitchAPI.Models
{
    public abstract class TwitchBase
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }            
    }
}
