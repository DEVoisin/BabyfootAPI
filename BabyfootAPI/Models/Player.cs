using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BabyfootAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Elo { get; set; }

        [Required]
        public int RankId { get; set; }
        public virtual Rank? Rank { get; set; }

        [JsonIgnore]
        public ICollection<PlayerGame>? FirstPlayerGames { get; set; }
        [JsonIgnore]
        public ICollection<PlayerGame>? SecondPlayerGames { get; set; }
        [JsonIgnore]
        public ICollection<Team>? FirstPlayerTeams { get; set; }
        [JsonIgnore]
        public ICollection<Team>? SecondPlayerTeams { get; set; }
    }
}
