namespace steam.Models
{
    public class Game_Publisher
    {
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}
