using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class TradicionalSegundaFirstPrizeWinners : IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }

        public TradicionalSegundaFirstPrizeWinners(decimal TradicionalSegundaFirstPrizeTotalAmount, List<Player> TradicionalSegundaFirstPrizeWinnerList)
        {
            PrizeWinnerList = TradicionalSegundaFirstPrizeWinnerList;
            if (TradicionalSegundaFirstPrizeWinnerList.Count > 0)
            {
                PrizeAmountPerWinner = TradicionalSegundaFirstPrizeTotalAmount / TradicionalSegundaFirstPrizeWinnerList.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}