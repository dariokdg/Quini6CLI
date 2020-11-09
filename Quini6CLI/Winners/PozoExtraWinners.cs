using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class PozoExtraWinners
    {
        private decimal PozoExtraPrizeTotalAmount { get; set; }
        public List<Player> PozoExtraPrizeWinners { get; set; }
        public decimal PozoExtraPrizeAmountPerWinner { get; set; }
        public PozoExtraWinners(
            decimal PozoExtraPrizeTotalAmount,
            List<Player> PozoExtraPrizeWinners
            )
        {
            this.PozoExtraPrizeTotalAmount = PozoExtraPrizeTotalAmount;
            this.PozoExtraPrizeWinners = PozoExtraPrizeWinners;
            if (PozoExtraPrizeWinners.Count > 0)
            {
                this.PozoExtraPrizeAmountPerWinner = PozoExtraPrizeTotalAmount / PozoExtraPrizeWinners.Count;
            }
            else
            {
                this.PozoExtraPrizeAmountPerWinner = 0;
            }
        }
    }
}