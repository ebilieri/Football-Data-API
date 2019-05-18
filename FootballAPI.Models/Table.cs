using Newtonsoft.Json;

namespace FootballAPI.Models
{
    public class Table
    {
        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("team")]
        public Team Team { get; set; }

        [JsonProperty("playedGames")]
        public long PlayedGames { get; set; }

        [JsonProperty("won")]
        public long Won { get; set; }

        [JsonProperty("draw")]
        public long Draw { get; set; }

        [JsonProperty("lost")]
        public long Lost { get; set; }

        [JsonProperty("points")]
        public long Points { get; set; }

        [JsonProperty("goalsFor")]
        public long GoalsFor { get; set; }

        [JsonProperty("goalsAgainst")]
        public long GoalsAgainst { get; set; }

        [JsonProperty("goalDifference")]
        public long GoalDifference { get; set; }
    }
}
