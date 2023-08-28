using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace STIVE_API.Controllers.Ressources
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamServices _teamServices;
        public TeamController(ITeamServices teamServices)
        {
            _teamServices = teamServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var result = await _teamServices.GetTeams();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamById(int teamId)
        {
            var result = await _teamServices.GetTeamById(teamId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<Team> CreateTeam(Team team)
        {
            try
            {
                var result = await _teamServices.AddTeam(team);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [HttpPut]
        public async Task<Team> UpdateTeam(Team team)
        {
            try
            {
                if (team.Id > 0)
                {
                    var result = await _teamServices.UpdateTeam(team);
                    return result;
                }
                else
                {
                    throw new Exception($"L'objet de type {nameof(Team)} n'existe pas");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
            var result = await _teamServices.RemoveTeam(teamId);
            return Ok(result);
        }

    }
}
