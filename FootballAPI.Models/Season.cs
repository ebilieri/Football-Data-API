using Newtonsoft.Json;
using System;

namespace FootballAPI.Models
{
    public class Season
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("currentMatchday")]
        public long CurrentMatchday { get; set; }

        [JsonProperty("winner")]
        public object Winner { get; set; }
    }
}
