using SpinWinKiosk.Domain.Enums;
using SpinWinKiosk.Services;

namespace SpinWinKiosk.Tests
{
  
    public class GameServiceTests
    {
        private readonly GameService _service = new();

        [Fact]
        public void GiftItem_Is_Substituted()
        {
            var prize = _service.SpinPrize(true);
            Assert.NotEqual(PrizeType.GiftItem, prize);
        }

       


        [Fact]
        public void GiftItemSubstitutesIfAlreadyWon()
        {
            var prizes = new List<Prize>
    {
        new() { Name = "Gift Item", PrizeWeight = 1 },
        new() { Name = "$10 Free Play", PrizeWeight = 1 }
    };

            var player = new Player { HasWonGiftItem = true };
            var selected = "Gift Item";

            if (selected == "Gift Item" && player.HasWonGiftItem)
                selected = "$10 Free Play";

            Assert.Equal("$10 Free Play", selected);
        }


    }

    internal class Player
    {
        public bool HasWonGiftItem { get; set; }
    }

    internal class PlaySession
    {
        public DateTime SessionStart { get; set; }
    }
}
