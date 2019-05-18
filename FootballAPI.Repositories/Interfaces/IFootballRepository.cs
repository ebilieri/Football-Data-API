using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballAPI.Repositories.Interfaces
{
    public interface IFootballRepository
    {
        Football FromJson(string json);

        List<Standing> GetListStandings(string json);

        Standing GetStanding(string json);

        List<Table> GetTableTeams(string json);

    }
}
