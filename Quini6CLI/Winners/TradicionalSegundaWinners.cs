using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class TradicionalSegundaWinners
    {
        private decimal TradicionalSegundaFirstPrizeTotalAmount { get; set; }
        public List<Player> TradicionalSegundaFirstPrizeWinners { get; set; }
        public decimal TradicionalSegundaFirstPrizeAmountPerWinner { get; set; }
        private decimal TradicionalSegundaSecondPrizeTotalAmount { get; set; }
        public List<Player> TradicionalSegundaSecondPrizeWinners { get; set; }
        public decimal TradicionalSegundaSecondPrizeAmountPerWinner { get; set; }
        private decimal TradicionalSegundaThirdPrizeTotalAmount { get; set; }
        public List<Player> TradicionalSegundaThirdPrizeWinners { get; set; }
        public decimal TradicionalSegundaThirdPrizeAmountPerWinner { get; set; }

        public TradicionalSegundaWinners(
            decimal TradicionalSegundaFirstPrizeTotalAmount,
            List<Player> TradicionalSegundaFirstPrizeWinners,
            decimal TradicionalSegundaSecondPrizeTotalAmount,
            List<Player> TradicionalSegundaSecondPrizeWinners,
            decimal TradicionalSegundaThirdPrizeTotalAmount,
            List<Player> TradicionalSegundaThirdPrizeWinners
            )
        {
            this.TradicionalSegundaFirstPrizeTotalAmount = TradicionalSegundaFirstPrizeTotalAmount;
            this.TradicionalSegundaFirstPrizeWinners = TradicionalSegundaFirstPrizeWinners;
            if (TradicionalSegundaFirstPrizeWinners.Count > 0)
            {
                this.TradicionalSegundaFirstPrizeAmountPerWinner = TradicionalSegundaFirstPrizeTotalAmount / TradicionalSegundaFirstPrizeWinners.Count;
            }
            else
            {
                this.TradicionalSegundaFirstPrizeAmountPerWinner = 0;
            }
            this.TradicionalSegundaSecondPrizeTotalAmount = TradicionalSegundaSecondPrizeTotalAmount;
            this.TradicionalSegundaSecondPrizeWinners = TradicionalSegundaSecondPrizeWinners;
            if (TradicionalSegundaSecondPrizeWinners.Count > 0)
            {
                this.TradicionalSegundaSecondPrizeAmountPerWinner = TradicionalSegundaSecondPrizeTotalAmount / TradicionalSegundaSecondPrizeWinners.Count;
            }
            else
            {
                this.TradicionalSegundaSecondPrizeAmountPerWinner = 0;
            }
            this.TradicionalSegundaThirdPrizeTotalAmount = TradicionalSegundaThirdPrizeTotalAmount;
            this.TradicionalSegundaThirdPrizeWinners = TradicionalSegundaThirdPrizeWinners;
            if (TradicionalSegundaThirdPrizeWinners.Count > 0)
            {
                this.TradicionalSegundaThirdPrizeAmountPerWinner = TradicionalSegundaThirdPrizeTotalAmount / TradicionalSegundaThirdPrizeWinners.Count;
            }
            else
            {
                this.TradicionalSegundaThirdPrizeAmountPerWinner = 0;
            }
        }
    }
}
