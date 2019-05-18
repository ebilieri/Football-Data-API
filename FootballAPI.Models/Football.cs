using Newtonsoft.Json;
using System.Collections.Generic;


namespace FootballAPI.Models
{
    public class Football
    {
        [JsonProperty("filters")]
        public Filters Filters { get; set; }

        [JsonProperty("competition")]
        public Competition Competition { get; set; }

        [JsonProperty("season")]
        public Season Season { get; set; }

        [JsonProperty("standings")]
        public List<Standing> Standings { get; set; }
    }
}
