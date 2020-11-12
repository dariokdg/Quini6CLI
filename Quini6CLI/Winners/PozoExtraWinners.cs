using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class PozoExtraWinners : IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }
        public PozoExtraWinners(decimal PozoExtraPrizeTotalAmount, List<Player> PozoExtraPrizeWinners)
        {
            PrizeWinnerList = PozoExtraPrizeWinners;
            if (PozoExtraPrizeWinners.Count > 0)
            {
                PrizeAmountPerWinner = PozoExtraPrizeTotalAmount / PozoExtraPrizeWinners.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}