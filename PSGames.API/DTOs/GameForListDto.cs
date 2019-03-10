namespace PSGames.API.DTOs
{
    public class GameForListDto
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public PlatformForGameDto Platform { get; set; }
    }
}