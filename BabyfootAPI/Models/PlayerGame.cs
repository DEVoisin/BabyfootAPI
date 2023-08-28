namespace BabyfootAPI.Models
{
    public class PlayerGame
    {
        public int Id { get; set; }

        public int FirstPlayerId { get; set; }
        public virtual Player? FirstPlayer { get; set; }
        public int FirstPlayerScore { get; set; }

        public int SecondPlayerId { get; set; }
        public virtual Player? SecondPlayer { get; set; }
        public int SecondPlayerScore { get; set; }
    }
}
