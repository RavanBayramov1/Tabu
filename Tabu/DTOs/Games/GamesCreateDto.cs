using Tabu.Enums;

namespace Tabu.DTOs.Games
{
    public class GamesCreateDto
    {
        public GameLevel GameLevel { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public TimeSpan Time { get; set; }
        public string Language { get; set; }
    }
}
