using BabyfootAPI.Context;
using BabyfootAPI.Models;
using BabyfootAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace BabyfootAPI.Services
{
    public class TeamServices : ITeamServices
    {
        private readonly ApplicationDbContext _context;
        public TeamServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Team> AddTeam(Team team)
        {
            try
            {
                if(!await TeamExist(team.FirstPlayerId, team.SecondPlayerId))
                {
                    _context.Teams.Add(team);
                    await _context.SaveChangesAsync();
                    return team;
                }
                else
                {
                    throw new Exception("L'équipe existe déjà");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Team> RemoveTeam(int teamId)
        {
            try
            {
                var team = await _context.Teams.FindAsync(teamId);
                if (team == null)
                {
                    throw new Exception($"la team id #{teamId} n'existe pas");
                }

                _context.Entry(team).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return team;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Team>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }
        public async Task<Team?> GetTeamById(int teamId)
        {
            return await _context.Teams.FirstOrDefaultAsync(p => p.Id == teamId);
        }

        public async Task<bool> TeamExist(int firstPlayerId, int secondPlayerId)
        {
            var teams = await GetTeams();

            foreach (var team in teams)
            {
                if (team.FirstPlayerId == firstPlayerId && team.SecondPlayerId == secondPlayerId || team.FirstPlayerId == secondPlayerId && team.SecondPlayerId == firstPlayerId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
