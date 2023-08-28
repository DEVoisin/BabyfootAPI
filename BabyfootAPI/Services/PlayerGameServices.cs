using BabyfootAPI.Context;
using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BabyfootAPI.Services
{
    public class PlayerGameServices : IPlayerGameServices
    {
        private readonly ApplicationDbContext _context;
        public PlayerGameServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PlayerGame> AddPlayerGame(PlayerGame playerGame)
        {
            try
            {
                _context.PlayerGames.Add(playerGame);
                await _context.SaveChangesAsync();
                return playerGame;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PlayerGame> UpdatePlayerGame(PlayerGame playerGame)
        {
            try
            {
                _context.PlayerGames.Update(playerGame);
                await _context.SaveChangesAsync();
                return playerGame;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PlayerGame> RemovePlayerGame(int playerGameId)
        {
            try
            {
                var playerGame = await _context.PlayerGames.FindAsync(playerGameId);
                if (playerGame == null)
                {
                    throw new Exception($"la partie 1vs1 id #{playerGameId} n'existe pas");
                }

                _context.Entry(playerGame).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return playerGame;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<PlayerGame>> GetPlayerGames()
        {
            return await _context.PlayerGames.ToListAsync();
        }
        public async Task<PlayerGame?> GetPlayerGameById(int playerGameId)
        {
            return await _context.PlayerGames.FirstOrDefaultAsync(p => p.Id == playerGameId);
        }
    }
}
