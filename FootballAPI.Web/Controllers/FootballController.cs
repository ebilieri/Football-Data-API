using FootballAPI.Models;
using FootballAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FootballAPI.Web.Controllers
{
    public class FootballController : Controller
    {
        private readonly IFootballService _footballService;

        public FootballController(IFootballService footballService)
        {
            _footballService = footballService;
        }

        public async Task<IActionResult> Index(string idCompeticao)
        {
            var competition = new Competition();

            try
            {
                competition = await _footballService.GetTableTeams(idCompeticao);
            }
            catch (Exception ex)
            {
                string message = string.Format("Atenção: {0}", ex.Message);
                ModelState.AddModelError(string.Empty, message);
            }

            return View(competition);
        }
    }
}