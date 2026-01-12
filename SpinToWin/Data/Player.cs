namespace SpinWinKiosk.API.Data
{
    public class Player
    {
        public Guid Id { get; set; }
        public string PlayerCode { get; set; } = null!;
        public bool HasWonGiftItem { get; set; }
    }
}