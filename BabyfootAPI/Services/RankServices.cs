using BabyfootAPI.Context;
using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BabyfootAPI.Services
{
    public class RankServices : IRankServices
    {
        private readonly ApplicationDbContext _context;
        public RankServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Rank> AddRank(Rank rank)
        {
            try
            {
                _context.Ranks.Add(rank);
                await _context.SaveChangesAsync();
                return rank;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Rank> UpdateRank(Rank rank)
        {
            try
            {
                _context.Ranks.Update(rank);
                await _context.SaveChangesAsync();
                return rank;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Rank> RemoveRank(int rankId)
        {
            try
            {
                var rank = await _context.Ranks.FindAsync(rankId);
                if (rank == null)
                {
                    throw new Exception($"le rang id #{rankId} n'existe pas");
                }

                _context.Entry(rank).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return rank;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Rank>> GetRanks()
        {
            return await _context.Ranks.ToListAsync();
        }
        public async Task<Rank?> GetRankById(int rankId)
        {
            return await _context.Ranks.FirstOrDefaultAsync(p => p.Id == rankId);
        }

        public async Task<Rank?> GetRankByElo(decimal elo)
        {
            var ranks = await GetRanks();

            foreach (var rank in ranks)
            {
                if(elo <= rank.EloMax && elo >= rank.EloMin)
                {
                    return rank;
                }
            }
            return null;
        }
    }
}
