using Newtonsoft.Json;
using System.Collections.Generic;
using StreamBet.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitchAPI.Models
{
    public class User : TwitchBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, object> Links { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
        
        [JsonProperty("staff")]
        public string Staff { get; set; }

        public User(string name,
            string displayName,
            string id,
            string createdAt,
            string updatedAt,
            Dictionary<string, object> links,
            string logo,
            string staff)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.Id = id;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Links = links;
            this.Logo = logo;
            this.Staff = staff;
        }
        

        public async Task<User> GetUser(Streamer s)
        {
                using (HttpClient cli = new HttpClient())
            {
                var r = await cli.GetAsync("https://api.twitch.tv/kraken/users/" + s.Name);
                User u = JsonConvert.DeserializeObject<User>(r.Content.ToString());
                return u;
            }
        }
    }
}
