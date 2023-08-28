using BabyfootAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BabyfootAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Rank)
                .WithMany(r => r.Players)
                .HasForeignKey(p => p.RankId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PlayerGame>()
               .HasOne(p => p.FirstPlayer)
               .WithMany(r => r.FirstPlayerGames)
               .HasForeignKey(p => p.FirstPlayerId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlayerGame>()
               .HasOne(p => p.SecondPlayer)
               .WithMany(r => r.SecondPlayerGames)
               .HasForeignKey(p => p.SecondPlayerId)
               .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Team>()
               .HasOne(p => p.FirstPlayer)
               .WithMany(r => r.FirstPlayerTeams)
               .HasForeignKey(p => p.FirstPlayerId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
              .HasOne(p => p.SecondPlayer)
              .WithMany(r => r.SecondPlayerTeams)
              .HasForeignKey(p => p.SecondPlayerId)
              .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<TeamGame>()
               .HasOne(p => p.FirstTeam)
               .WithMany(r => r.FirstTeamGames)
               .HasForeignKey(p => p.FirstTeamId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TeamGame>()
               .HasOne(p => p.SecondTeam)
               .WithMany(r => r.SecondTeamGames)
               .HasForeignKey(p => p.SecondTeamId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Player>()
                .Property(p => p.Elo)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Team>()
               .Property(p => p.Elo)
               .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }

        #region DbSet 

        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamGame> TeamGames { get; set; }
        #endregion
    }
}
