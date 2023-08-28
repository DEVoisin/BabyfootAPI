using BabyfootAPI.Models;

namespace BabyfootAPI.Services.Interfaces
{
    public interface ITeamServices
    {
        Task<Team> AddTeam(Team team);
        Task<Team> RemoveTeam(int teamId);
        Task<List<Team>> GetTeams();
        Task<Team?> GetTeamById(int teamId);
        Task<string> UpdateTeamName(int teamId, string name);
        Task<string> UpdateTeamElo(int teamId, decimal elo);
        Task<bool> TeamExist(int firstPlayerId, int secondPlayerId);
    }
}
