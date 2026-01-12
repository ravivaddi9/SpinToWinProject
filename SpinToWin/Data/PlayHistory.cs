
using SpinWinKiosk.Domain.Enums;

namespace SpinWinKiosk.API.Data
{
    public class PlayHistory
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public PrizeType Prize { get; set; }
        public DateTime PlayedAt { get; set; }
    }
}