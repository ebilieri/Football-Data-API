using FootballAPI.Models;
using FootballAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public class FootballService : IFootballService
    {                     
        public async Task<Football> GetFootball(string IdCompeticao , string uriEndpoint, string token)
        {
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

        public Standing GetStanding(Football football)
        {
            var standing = (from tab in football.Standings
                            where tab.Type == "TOTAL"
                            select tab).FirstOrDefault();

            return standing;
        }

        public List<Table> GetTableTeams(Football football)
        {
            return GetStanding(football).Table;
        }
    }
}