using Newtonsoft.Json;
using System.Collections.Generic;

namespace FootballAPI.Models
{
    public class Standing
    {
        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("group")]
        public object Group { get; set; }

        [JsonProperty("table")]
        public List<Table> Table { get; set; }
    }
}
