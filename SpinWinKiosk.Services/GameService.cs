using SpinWinKiosk.Domain.Entities;
using SpinWinKiosk.Domain.Enums;

namespace SpinWinKiosk.Services;

public class GameService
{
    private readonly List<PrizeWeight> _weights = new()
    {
        new(PrizeType.NoPrize, 50),
        new(PrizeType.FreePlay5, 25),
        new(PrizeType.FreePlay10, 15),
        new(PrizeType.FoodVoucher, 7),
        new(PrizeType.GiftItem, 3)
    };

    public PrizeType SpinPrize(bool alreadyWonGift)
    {
        var prize = GetWeightedPrize();

        if (prize == PrizeType.GiftItem && alreadyWonGift)
            return PrizeType.FreePlay10;

        return prize;
    }

    private PrizeType GetWeightedPrize()
    {
        int total = _weights.Sum(w => w.Weight);
        int roll = Random.Shared.Next(1, total + 1);

        int current = 0;
        foreach (var w in _weights)
        {
            current += w.Weight;
            if (roll <= current)
                return w.Prize;
        }
        return PrizeType.NoPrize;
    }

    
}
