using System;
using Newtonsoft.Json;
using System.Collections.Generic;

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
    }
}
