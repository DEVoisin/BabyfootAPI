using BabyfootAPI.Models;

namespace BabyfootAPI.Services.Interfaces
{
    public interface IRankServices
    {
        Task<Rank> AddRank(Rank rank);
        Task<Rank> UpdateRank(Rank rank);
        Task<Rank> RemoveRank(int rankId);
        Task<List<Rank>> GetRanks();
        Task<Rank?> GetRankById(int rankId);
        Task<Rank?> GetRankByElo(decimal elo);
    }
}
