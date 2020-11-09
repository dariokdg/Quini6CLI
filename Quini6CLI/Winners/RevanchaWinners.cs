using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class RevanchaWinners
    {
        private decimal RevanchaPrizeTotalAmount { get; set; }
        public List<Player> RevanchaPrizeWinners { get; set; }
        public decimal RevanchaPrizeAmountPerWinner { get; set; }
        public RevanchaWinners(
            decimal RevanchaPrizeTotalAmount,
            List<Player> RevanchaPrizeWinners
            )
        {
            this.RevanchaPrizeTotalAmount = RevanchaPrizeTotalAmount;
            this.RevanchaPrizeWinners = RevanchaPrizeWinners;
            if (RevanchaPrizeWinners.Count > 0)
            {
                this.RevanchaPrizeAmountPerWinner = RevanchaPrizeTotalAmount / RevanchaPrizeWinners.Count;
            }
            else
            {
                this.RevanchaPrizeAmountPerWinner = 0;
            }
        }
    }
}