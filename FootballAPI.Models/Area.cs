using Newtonsoft.Json;

namespace FootballAPI.Models
{
    public class Area
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
