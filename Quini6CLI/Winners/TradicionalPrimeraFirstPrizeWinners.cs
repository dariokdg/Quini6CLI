using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class TradicionalPrimeraFirstPrizeWinners : IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }

        public TradicionalPrimeraFirstPrizeWinners(decimal TradicionalPrimeraFirstPrizeTotalAmount, List<Player> TradicionalPrimeraFirstPrizeWinnerList)
        {
            PrizeWinnerList = TradicionalPrimeraFirstPrizeWinnerList;
            if (TradicionalPrimeraFirstPrizeWinnerList.Count > 0)
            {
                PrizeAmountPerWinner = TradicionalPrimeraFirstPrizeTotalAmount / TradicionalPrimeraFirstPrizeWinnerList.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}