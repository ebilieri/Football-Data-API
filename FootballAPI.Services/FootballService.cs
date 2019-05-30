using FootballAPI.Models;
using FootballAPI.Services.Helpers;
using FootballAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public class FootballService : IFootballService
    {
        private Standing GetStanding(Football football)
        {
            var standing = (from tab in football.Standings
                            where tab.Type == "TOTAL"
                            select tab).FirstOrDefault();

            return standing;
        }

        private string GetUriEndpoint(string idCompeticao)
        {
            if (!string.IsNullOrWhiteSpace(idCompeticao))
                return string.Format(ConfigHelper.CompetitionsStandings(), idCompeticao);
            else
                return ConfigHelper.DefaultCompetition();
        }
       
        private List<Table> GetTableTeams(Football football)
        {
            return GetStanding(football).Table;
        }


        public async Task<Football> GetFootball(string idCompeticao)
        {            
            var token = ConfigHelper.GetToken();
            var uriEndpoint = GetUriEndpoint(idCompeticao);

            Football football = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Auth-Token", token);

                using (var response = await client.GetAsync(uriEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        football = await response.Content.ReadAsAsync<Football>();
                    }
                    else
                    {
                        var msgRetorno = await response.Content.ReadAsAsync<Messagem>();
                        throw new Exception(msgRetorno.Message);
                    }
                }
            }

            return football;
        }

        public async Task<Competition> GetTableTeams(string idCompeticao)
        {
            Competition competition = new Competition();
            var football = await GetFootball(idCompeticao);

            if (football != null)
            {
                football.Competition.Tables = GetTableTeams(football);
                competition = football.Competition;
            }

            return competition;
        }
    }
}