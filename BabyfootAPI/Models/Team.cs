using System.Text.Json.Serialization;

namespace BabyfootAPI.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Elo { get; set; }

        public int FirstPlayerId { get; set; }
        public virtual Player? FirstPlayer { get; set; }

        public int SecondPlayerId { get; set; }
        public virtual Player? SecondPlayer { get; set; }

        [JsonIgnore]
        public ICollection<TeamGame>? FirstTeamGames { get; set; }
        [JsonIgnore]
        public ICollection<TeamGame>? SecondTeamGames { get; set; }
    }
}
