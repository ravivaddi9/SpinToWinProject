using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinWinKiosk.Domain.Entities
{
    internal class PlaySession
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }

        public DateTime SessionStart { get; set; }
        public int PlaysUsed { get; set; }
        public DateOnly PlayDate { get; set; }
    }
}
