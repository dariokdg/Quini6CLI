using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class TradicionalSegundaThirdPrizeWinners : IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }

        public TradicionalSegundaThirdPrizeWinners(
            decimal TradicionalSegundaThirdPrizeTotalAmount,
            List<Player> TradicionalSegundaThirdPrizeWinnerList
            )
        {
            PrizeWinnerList = TradicionalSegundaThirdPrizeWinnerList;
            if (TradicionalSegundaThirdPrizeWinnerList.Count > 0)
            {
                PrizeAmountPerWinner = TradicionalSegundaThirdPrizeTotalAmount / TradicionalSegundaThirdPrizeWinnerList.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}