using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class TradicionalSegundaSecondPrizeWinners : IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }

        public TradicionalSegundaSecondPrizeWinners(decimal TradicionalSegundaSecondPrizeTotalAmount, List<Player> TradicionalSegundaSecondPrizeWinnerList)
        {
            PrizeWinnerList = TradicionalSegundaSecondPrizeWinnerList;
            if (TradicionalSegundaSecondPrizeWinnerList.Count > 0)
            {
                PrizeAmountPerWinner = TradicionalSegundaSecondPrizeTotalAmount / TradicionalSegundaSecondPrizeWinnerList.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}