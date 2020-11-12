using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class SiempreSaleWinners : IWinner
    {
        public int SiempreSaleWinnersNumberofMatches { get; set; }
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }
        public SiempreSaleWinners(
            decimal SiempreSalePrizeTotalAmount,
            List<Player> SiempreSalePrizeWinners,
            int SiempreSaleWinnersNumberofMatches
            )
        {
            PrizeWinnerList = SiempreSalePrizeWinners;
            this.SiempreSaleWinnersNumberofMatches = SiempreSaleWinnersNumberofMatches;
            if (SiempreSalePrizeWinners.Count > 0)
            {
                PrizeAmountPerWinner = SiempreSalePrizeTotalAmount / SiempreSalePrizeWinners.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}