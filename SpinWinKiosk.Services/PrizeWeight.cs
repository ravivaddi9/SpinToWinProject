using SpinWinKiosk.Domain.Enums;

namespace SpinWinKiosk.Services
{
    //public record PrizeWeight(PrizeType Prize, int Weight);

    public class PrizeWeight
    {
        private readonly Random _random = new();
        internal int Weight;
        internal PrizeType Prize;

        public PrizeWeight(PrizeType noPrize, int v)
        {
        }

        public Prize SelectPrize(IEnumerable<Prize> prizes)
        {
            var totalWeight = prizes.Sum(p => p.Weight);
            var roll = _random.Next(1, totalWeight + 1);

            int cumulative = 0;
            foreach (var prize in prizes)
            {
                cumulative += prize.Weight;
                if (roll <= cumulative)
                    return prize;
            }

            return prizes.First();
        }

       
    }

    public class Prize
    {
        public string Name;
        internal int Weight;

        public int PrizeWeight { get; set; }
    }
}
