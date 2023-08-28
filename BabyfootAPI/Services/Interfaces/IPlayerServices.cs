using BabyfootAPI.Models;

namespace BabyfootAPI.Services.Interfaces
{
    public interface IPlayerServices
    {
        Task<Player> AddPlayer(Player player);
        Task<Player> UpdatePlayer(Player player);
        Task<Player> RemovePlayer(int playerId);
        Task<List<Player>> GetPlayers();
        Task<Player?> GetPlayerById(int playerId);
        Task<string> UpdatePlayerElo(int playerId, decimal elo);
    }
}
