using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class TradicionalPrimeraSecondPrizeWinners : IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }

        public TradicionalPrimeraSecondPrizeWinners(
            decimal TradicionalPrimeraSecondPrizeTotalAmount,
            List<Player> TradicionalPrimeraSecondPrizeWinnerList
            )
        {
            PrizeWinnerList = TradicionalPrimeraSecondPrizeWinnerList;
            if (TradicionalPrimeraSecondPrizeWinnerList.Count > 0)
            {
                PrizeAmountPerWinner = TradicionalPrimeraSecondPrizeTotalAmount / TradicionalPrimeraSecondPrizeWinnerList.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}