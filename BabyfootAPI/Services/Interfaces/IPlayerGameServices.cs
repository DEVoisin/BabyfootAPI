using BabyfootAPI.Models;

namespace BabyfootAPI.Services.Interfaces
{
    public interface IPlayerGameServices
    {
        Task<PlayerGame> AddPlayerGame(PlayerGame playerGame);
        Task<PlayerGame> UpdatePlayerGame(PlayerGame playerGame);
        Task<PlayerGame> RemovePlayerGame(int playerGameId);
        Task<List<PlayerGame>> GetPlayerGames();
        Task<PlayerGame?> GetPlayerGameById(int playerGameId);
    }
}
