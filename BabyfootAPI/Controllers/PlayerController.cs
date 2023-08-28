using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace STIVE_API.Controllers.Ressources
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerServices _playerServices;
        public PlayerController(IPlayerServices playerServices)
        {
            _playerServices = playerServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var result = await _playerServices.GetPlayers();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayerById(int playerId)
        {
            var result = await _playerServices.GetPlayerById(playerId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<Player> CreatePlayer(Player player)
        {
            try
            {
                var result = await _playerServices.AddPlayer(player);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [HttpPut]
        public async Task<Player> UpdatePlayer(Player player)
        {
            try
            {
                if (player.Id > 0)
                {
                    var result = await _playerServices.UpdatePlayer(player);
                    return result;
                }
                else
                {
                    throw new Exception($"L'objet de type {nameof(Player)} n'existe pas");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayerElo(int playerId, decimal elo)
        {
            var result = await _playerServices.UpdatePlayerElo(playerId, elo);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(int playerId)
        {
            var result = await _playerServices.RemovePlayer(playerId);
            return Ok(result);
        }

    }
}
