using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace STIVE_API.Controllers.Ressources
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PlayerGameController : ControllerBase
    {
        private readonly IPlayerGameServices _playerGameServices;
        public PlayerGameController(IPlayerGameServices playerGameServices)
        {
            _playerGameServices = playerGameServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayerGames()
        {
            var result = await _playerGameServices.GetPlayerGames();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayerGameById(int playerGameId)
        {
            var result = await _playerGameServices.GetPlayerGameById(playerGameId);
            return Ok(result);
        }


        [HttpPost]
        public async Task<PlayerGame> CreatePlayerGame(PlayerGame playerGame)
        {
            try
            {
                var result = await _playerGameServices.AddPlayerGame(playerGame);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [HttpPut]
        public async Task<PlayerGame> UpdatePlayerGame(PlayerGame playerGame)
        {
            try
            {
                if (playerGame.Id > 0)
                {
                    var result = await _playerGameServices.UpdatePlayerGame(playerGame);
                    return result;
                }
                else
                {
                    throw new Exception($"L'objet de type {nameof(PlayerGame)} n'existe pas");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePlayerGame(int playerGameId)
        {
            var result = await _playerGameServices.RemovePlayerGame(playerGameId);
            return Ok(result);
        }

    }
}
