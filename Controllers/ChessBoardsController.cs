using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChessBoardApi.Models;

using System.Collections;

namespace chess_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChessBoardsController : ControllerBase
    {
        private readonly ChessBoardContext _context;

        public ChessBoardsController(ChessBoardContext context)
        {
            _context = context;
        }

        // GET: api/ChessBoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChessBoard>>> GetChessBoards()
        {

            var chessBoards = await _context.ChessBoards.ToListAsync();

            return chessBoards;
        }

        // GET: api/ChessBoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChessBoard>> GetChessBoard(long id)
        {
            var chessBoard = await _context.ChessBoards.FindAsync(id);

            if (chessBoard == null)
            {
                return NotFound();
            }

            return chessBoard;
        }

        // PUT: api/ChessBoards/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChessBoard(long id, ChessBoard chessBoard)
        {
            if (id != chessBoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(chessBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ChessBoardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ChessBoards
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ChessBoard>> PostChessBoard(ChessBoard chessBoard)
        {
            _context.ChessBoards.Add(chessBoard);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetChessBoard", new { id = chessBoard.Id }, chessBoard);
            return CreatedAtAction(nameof(GetChessBoard), new { id = chessBoard.Id }, chessBoard);
        }

        // DELETE: api/ChessBoards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChessBoard>> DeleteChessBoard(long id)
        {
            var chessBoard = await _context.ChessBoards.FindAsync(id);
            if (chessBoard == null)
            {
                return NotFound();
            }

            _context.ChessBoards.Remove(chessBoard);
            await _context.SaveChangesAsync();

            return chessBoard;
        }

        private bool ChessBoardExists(long id)
        {
            return _context.ChessBoards.Any(e => e.Id == id);
        }
    }
}
