namespace BabyfootAPI.Models
{
    public class TeamGame
    {
        public int Id { get; set; }
        public int FirstTeamScore { get; set; }
        public int FirstTeamId { get; set; }
        public virtual Team? FirstTeam { get; set; }
        public int SecondTeamScore { get; set; }
        public int SecondTeamId { get; set; }
        public virtual Team? SecondTeam { get; set; }
    }
}
