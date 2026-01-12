using SpinWinKiosk.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinWinKiosk.Domain.Entities
{
    internal class PlayHistory
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public PrizeType Prize { get; set; }
        public DateTime PlayedAt { get; set; }
    }
}
