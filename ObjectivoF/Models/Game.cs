using System;
namespace ObjectivoF
{
    public class Game
    {
        public string GameId { get; set; }
        public string FirstPlayerId { get; set; }
        public string SecondPlayerId { get; set; }
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }

        public Game()
        { }
    }
}

