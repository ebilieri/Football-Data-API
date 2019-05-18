using FootballAPI.Models;
using FootballAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballAPI.Web.Controllers
{
    public class FootballController : Controller
    {
        private readonly IFootballService _footballService;
        private IConfiguration _configuration;
        public FootballController(IFootballService footballService, IConfiguration configuration)
        {
            _footballService = footballService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string IdCompeticao)
        {            
            var listTeams = new List<Table>();
            string message;
            try
            {
                var uriEndpoint = string.Empty;

                if (!string.IsNullOrWhiteSpace(IdCompeticao))
                    uriEndpoint = string.Format(_configuration.GetSection("ApiConnections").GetSection("CompetitionsStandings").Value, IdCompeticao);
                else
                    uriEndpoint = _configuration.GetSection("ApiConnections").GetSection("DefautCompetition").Value;

                var token = _configuration.GetSection("HeadersParams").GetSection("X-Auth-Token").Value;

                var football = await _footballService.GetFootball(IdCompeticao, uriEndpoint, token);

                if (football != null)
                {
                    ViewBag.Campeonato = football.Competition.Name;
                    ViewBag.CampeonatoId = football.Competition.Id;
                    listTeams = _footballService.GetTableTeams(football);
                }
            }
            catch (Exception ex)
            {
                message = string.Format("Atenção: {0}", ex.Message);
                ModelState.AddModelError(string.Empty, message);
            }

            return View(listTeams);
        }        
    }
}