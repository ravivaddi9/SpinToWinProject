namespace SpinWinKiosk.API.Data
{
    public class PlaySession
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }

        public DateTime SessionStart { get; set; }
        public int PlaysUsed { get; set; }
        public DateOnly PlayDate { get; set; }
    }
}