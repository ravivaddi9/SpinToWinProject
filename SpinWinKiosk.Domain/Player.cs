using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpinWinKiosk.Domain.Entities
{
    internal class Player
    {
        public Guid Id { get; set; }
        public string PlayerCode { get; set; } = null!;
        public bool HasWonGiftItem { get; set; }

    }
}
