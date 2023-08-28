using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace STIVE_API.Controllers.Ressources
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TeamGameController : ControllerBase
    {
        private readonly ITeamGameServices _teamGameServices;
        public TeamGameController(ITeamGameServices teamGameServices)
        {
            _teamGameServices = teamGameServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamGames()
        {
            var result = await _teamGameServices.GetTeamGames();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamGameById(int teamGameId)
        {
            var result = await _teamGameServices.GetTeamGameById(teamGameId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<TeamGame> CreateTeamGame(TeamGame teamGame)
        {
            try
            {
                var result = await _teamGameServices.AddTeamGame(teamGame);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [HttpPut]
        public async Task<TeamGame> UpdateTeamGame(TeamGame teamGame)
        {
            try
            {
                if (teamGame.Id > 0)
                {
                    var result = await _teamGameServices.UpdateTeamGame(teamGame);
                    return result;
                }
                else
                {
                    throw new Exception($"L'objet de type {nameof(TeamGame)} n'existe pas");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTeamGame(int teamGameId)
        {
            var result = await _teamGameServices.RemoveTeamGame(teamGameId);
            return Ok(result);
        }

    }
}
