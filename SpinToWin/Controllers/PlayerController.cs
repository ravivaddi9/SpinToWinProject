using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpinWinKiosk.API.Data;

namespace SpinWinKiosk.API.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class PlayerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PlayerController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string playerId)
        {
            var player = await _db.Players
                .FirstOrDefaultAsync(p => p.PlayerCode == playerId);

            if (player == null)
            {
                player = new Player
                {
                    Id = Guid.NewGuid(),
                    PlayerCode = playerId
                };
                _db.Players.Add(player);
                await _db.SaveChangesAsync();
            }

            return Ok(player);
        }

        //public IActionResult Status(int id)
        //{
        //    return Status(id, s);
        //}

        [HttpGet("{id}/status")]
        public IActionResult Status(int id)
        {
            var session = _db.PlaySessions
                .OrderByDescending(s => s.SessionStart)
                .FirstOrDefault(s => s.PlaysUsed == id);

            return Ok(session);
        }
    }
}
