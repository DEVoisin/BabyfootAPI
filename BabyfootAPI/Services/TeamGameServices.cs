using BabyfootAPI.Context;
using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BabyfootAPI.Services
{
    public class TeamGameServices : ITeamGameServices
    {
        private readonly ApplicationDbContext _context;
        public TeamGameServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TeamGame> AddTeamGame(TeamGame teamGame)
        {
            try
            {
                _context.TeamGames.Add(teamGame);
                await _context.SaveChangesAsync();
                return teamGame;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<TeamGame> UpdateTeamGame(TeamGame teamGame)
        {
            try
            {
                _context.TeamGames.Update(teamGame);
                await _context.SaveChangesAsync();
                return teamGame;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<TeamGame> RemoveTeamGame(int teamGameId)
        {
            try
            {
                var teamGame = await _context.TeamGames.FindAsync(teamGameId);
                if (teamGame == null)
                {
                    throw new Exception($"La partie 2vs2 id #{teamGameId} n'existe pas");
                }

                _context.Entry(teamGame).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return teamGame;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<TeamGame>> GetTeamGames()
        {
            return await _context.TeamGames.ToListAsync();
        }
        public async Task<TeamGame?> GetTeamGameById(int teamGameId)
        {
            return await _context.TeamGames.FirstOrDefaultAsync(p => p.Id == teamGameId);
        }
    }
}
