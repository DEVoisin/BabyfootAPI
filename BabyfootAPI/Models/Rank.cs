using System.Text.Json.Serialization;

namespace BabyfootAPI.Models
{
    public class Rank
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int EloMin { get; set; }
        public int EloMax { get; set; }

        [JsonIgnore]
        public ICollection<Player>? Players { get; set; }
    }
}
