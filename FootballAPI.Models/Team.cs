using Newtonsoft.Json;
using System;

namespace FootballAPI.Models
{
    public class Team
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("crestUrl")]
        public Uri CrestUrl { get; set; }
    }
}
