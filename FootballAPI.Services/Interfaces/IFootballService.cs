using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballAPI.Services.Interfaces
{
    public interface IFootballService
    {        
        Task<Football> GetFootball(string idCompeticao);                
        Task<Competition> GetTableTeams(string idCompeticao);
    }
}
