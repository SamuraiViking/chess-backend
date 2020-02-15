using Microsoft.EntityFrameworkCore;

namespace ChessBoardApi.Models
{
    public class ChessBoardContext : DbContext
    {
        public ChessBoardContext(DbContextOptions<ChessBoardContext> options)
        : base(options)
        {
        }

        public DbSet<ChessBoard> ChessBoards { get; set; }
    }
}