using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class TradicionalPrimeraThirdPrizeWinners : IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }

        public TradicionalPrimeraThirdPrizeWinners(
            decimal TradicionalPrimeraThirdPrizeTotalAmount,
            List<Player> TradicionalPrimeraThirdPrizeWinnerList
            )
        {
            PrizeWinnerList = TradicionalPrimeraThirdPrizeWinnerList;
            if (TradicionalPrimeraThirdPrizeWinnerList.Count > 0)
            {
                PrizeAmountPerWinner = TradicionalPrimeraThirdPrizeTotalAmount / TradicionalPrimeraThirdPrizeWinnerList.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}