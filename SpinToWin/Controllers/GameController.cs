using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpinWinKiosk.API.Data;
using Microsoft.EntityFrameworkCore;
using SpinWinKiosk.Domain.Enums;
using SpinWinKiosk.Services;


namespace SpinWinKiosk.API.Controllers
{
    //[ApiController]
    //[Route("api/game")]
    //public class GameController : ControllerBase
    //{
    //    private readonly AppDbContext _db;
    //    private readonly PrizeWeight _prizeWeight;
    //    private readonly PrizeWeight _prizeService;

    //    public GameController(AppDbContext db, PrizeWeight prizeService)
    //    {
    //        _db = db;
    //        _prizeWeight = prizeService;
    //    }

    //    [HttpPost("play")]
    //    public IActionResult Play(int playerId)
    //    {
    //        var player = _db.Players.Find(playerId)!;
    //        var prizes = _db.Prizes.ToList();

    //        var prize = _prizeService.SelectPrize(prizes);

    //        // One-time Gift rule
    //        if (prize.Name == "Gift Item" && player.HasWonGiftItem)
    //        {
    //            prize = prizes.First(p => p.Name == "$10 Free Play");
    //        }

    //        if (prize.Name == "Gift Item")
    //            player.HasWonGiftItem = true;

    //        _ = _db.PlayHistories.Add(new PlayHistory
    //        {
    //            PlayerId = playerId.,
    //            Prize = prize.Name,
    //            PlayedAt = DateTime.UtcNow
    //        });

    //        _ = _db.SaveChanges();
    //        return Ok(prize.Name);
    //    }
    //}





    /// <summary>
    /// ///////
    /// </summary>

    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly GameService _game;

        //public GameController(AppDbContext db, GameService game)
        //{
        //    _db = db;
        //    _game = game;
        //}
        public GameController(AppDbContext db)
        {
            _db = db;

        }
        private GameController(GameService game)
        {
            _game = game;
        }

        [HttpPost("play")]
        public async Task<IActionResult> Play(Guid playerId)
        {
            var player = await _db.Players.FindAsync(playerId);
            if (player == null) return NotFound();

            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var session = await _db.PlaySessions
                .FirstOrDefaultAsync(s => s.PlayerId == playerId && s.PlayDate == today);

            if (session == null)
            {
                session = new PlaySession
                {
                    Id = Guid.NewGuid(),
                    PlayerId = playerId,
                    SessionStart = DateTime.UtcNow,
                    PlaysUsed = 0,
                    PlayDate = today
                };
                _db.PlaySessions.Add(session);
            }

            if (_game.IsSessionExpired(session.SessionStart) || session.PlaysUsed >= 3)
                return BadRequest("Session expired or no plays left");

            var prize = _game.SpinPrize(player.HasWonGiftItem);

            if (prize == PrizeType.GiftItem)
                player.HasWonGiftItem = true;

            session.PlaysUsed++;

            _db.PlayHistories.Add(new PlayHistory
            {
                Id = Guid.NewGuid(),
                PlayerId = playerId,
                Prize = prize,
                PlayedAt = DateTime.UtcNow
            });

            await _db.SaveChangesAsync();

            return Ok(prize);
        }
    }


}
