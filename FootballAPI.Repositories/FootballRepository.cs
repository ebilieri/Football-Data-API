using FootballAPI.Models;
using FootballAPI.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
//using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http;

namespace FootballAPI.Repositories
{
    public class FootballRepository : IFootballRepository
    {


        //public string JsonString { get; set; }

        //public FootballRepository()
        //{
        //    JsonString = string.Empty;
        //}

        //public async void GetJson()
        //{

        //}

        private async Task<string> GetFootballJson(string uriCompetitionsStandings)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                client.DefaultRequestHeaders.Add("X-Auth-Token", "a195355bc9284463b01a4c1ab3ee029d");
                //client.DefaultRequestHeaders.Add("Content-Type","application /json"); 
                using (var response = await client.GetAsync(uriCompetitionsStandings))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new Exception(response.ToString());
                    }
                }
            }
        }

        public async Task<Football> FromJson(string uriCompetitionsStandings)
        {
            string json = await GetFootballJson(uriCompetitionsStandings);
            return  JsonConvert.DeserializeObject<Football>(json, Converter.Settings);
        }

        public async Task<List<Standing>> GetListStandings(string json)
        {
            return  FromJson(json).;
        }

        public Standing GetStanding(string json)
        {
            List<Standing> list = GetListStandings(json);

            Standing standing = (from tab in list
                                 where tab.Type == "TOTAL"
                                 select tab).FirstOrDefault();

            return standing;
        }

        public List<Table> GetTableTeams(string json)
        {
            return GetStanding(json).Table;
        }
    }
}
