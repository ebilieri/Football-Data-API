using FootballAPI.Services;
using FootballAPI.Services.Interfaces;
using Xunit;

namespace FootballAPI.Tests
{
    public class FootballTest
    {
        private readonly IFootballService _footballService;

        string uriEndpoint = "https://api.football-data.org/v2/competitions/2021/standings";
        string token = "a195355bc9284463b01a4c1ab3ee029d";

        public FootballTest()
        {            
            _footballService = new FootballService();
        }

        [Fact]
        public async void GetValueCompetitionID2021()
        {            
            var footbal = await _footballService.GetFootball("2021");

            Assert.Equal(2021, footbal.Competition.Id);
        }

        [Fact]
        public async void GetCountTeamsCompetitionID2021()
        {
            //var footbal = await _footballService.GetFootball("2021");
            var listTeams = await _footballService.GetTableTeams("2021");
            int valorEsperado = 20;

            Assert.Equal(valorEsperado, listTeams.Tables.Count);
        }
    }
}
