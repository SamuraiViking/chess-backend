namespace ChessBoardApi.Models
{
    public class ChessBoard
    {
        public long Id { get; set; }
        public string AsciiBoard { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool WhiteTurn { get; set; }
        public bool creatorIsWhite { get; set; }
    }
}

