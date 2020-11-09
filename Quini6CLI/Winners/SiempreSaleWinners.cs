using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class SiempreSaleWinners
    {
        private decimal SiempreSalePrizeTotalAmount { get; set; }
        public List<Player> SiempreSalePrizeWinners { get; set; }
        public int SiempreSaleWinnersNumberofMatches { get; set; }
        public decimal SiempreSalePrizeAmountPerWinner { get; set; }
        public SiempreSaleWinners(
            decimal SiempreSalePrizeTotalAmount,
            List<Player> SiempreSalePrizeWinners,
            int SiempreSaleWinnersNumberofMatches
            )
        {
            this.SiempreSalePrizeTotalAmount = SiempreSalePrizeTotalAmount;
            this.SiempreSalePrizeWinners = SiempreSalePrizeWinners;
            this.SiempreSaleWinnersNumberofMatches = SiempreSaleWinnersNumberofMatches;
            if (SiempreSalePrizeWinners.Count > 0)
            {
                this.SiempreSalePrizeAmountPerWinner = SiempreSalePrizeTotalAmount / SiempreSalePrizeWinners.Count;
            }
            else
            {
                this.SiempreSalePrizeAmountPerWinner = 0;
            }
        }
    }
}