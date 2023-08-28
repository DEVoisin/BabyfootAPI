using BabyfootAPI.Models;

namespace BabyfootAPI.Services.Interfaces
{
    public interface ITeamGameServices
    {
        Task<TeamGame> AddTeamGame(TeamGame teamGame);
        Task<TeamGame> UpdateTeamGame(TeamGame teamGame);
        Task<TeamGame> RemoveTeamGame(int teamGameId);
        Task<List<TeamGame>> GetTeamGames();
        Task<TeamGame?> GetTeamGameById(int teamGameId);
    }
}
