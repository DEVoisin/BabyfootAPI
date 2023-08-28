using BabyfootAPI.Context;
using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BabyfootAPI.Services
{
    public class PlayerServices : IPlayerServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IRankServices _rankServices;
        public PlayerServices(ApplicationDbContext context, IRankServices rankServices)
        {
            _context = context;
            _rankServices = rankServices;
        }

        public async Task<Player> AddPlayer(Player player)
        {
            try
            {
                player.Elo = 1000;
                _context.Players.Add(player);
                await _context.SaveChangesAsync();
                return player;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Player> UpdatePlayer(Player player)
        {
            try
            {
                _context.Players.Update(player);
                await _context.SaveChangesAsync();
                return player;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Player> RemovePlayer(int playerId)
        {
            try
            {
                var player = await _context.Players.FindAsync(playerId);
                if (player == null)
                {
                    throw new Exception($"le joueur id #{playerId} n'existe pas");
                }

                _context.Entry(player).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return player;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }
        public async Task<Player?> GetPlayerById(int playerId)
        {
            return await _context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
        }

        public async Task<string> UpdatePlayerElo(int playerId, decimal elo)
        {
            try
            {
                var player = await GetPlayerById(playerId);
                var rank = await _rankServices.GetRankByElo(elo);

                if (player == null)
                    throw new Exception($"Le joueur #{playerId} n'existe pas.");

                player.Elo = elo;

                if (rank != null)
                    player.RankId = rank.Id;

                await _context.SaveChangesAsync();

                return $"L'elo du joueur #{playerId} à bien été modifié";
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
