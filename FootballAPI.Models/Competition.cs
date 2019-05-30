using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FootballAPI.Models
{
    public class Competition
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("area")]
        public Area Area { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("plan")]
        public string Plan { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        public List<Table> Tables { get; set; }
    }
}
