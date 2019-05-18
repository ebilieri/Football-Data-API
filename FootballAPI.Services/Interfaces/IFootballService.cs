using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballAPI.Services.Interfaces
{
    public interface IFootballService
    {        
        Task<Football> GetFootball(string IdCompeticao, string uriEndpoint, string token);
        Standing GetStanding(Football football);
        List<Table> GetTableTeams(Football football);

    }
}
