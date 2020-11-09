using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class TradicionalPrimeraWinners
    {
        private decimal TradicionalPrimeraFirstPrizeTotalAmount { get; set; }
        public List<Player> TradicionalPrimeraFirstPrizeWinners { get; set; }
        public decimal TradicionalPrimeraFirstPrizeAmountPerWinner { get; set; }
        private decimal TradicionalPrimeraSecondPrizeTotalAmount { get; set; }
        public List<Player> TradicionalPrimeraSecondPrizeWinners { get; set; }
        public decimal TradicionalPrimeraSecondPrizeAmountPerWinner { get; set; }
        private decimal TradicionalPrimeraThirdPrizeTotalAmount { get; set; }
        public List<Player> TradicionalPrimeraThirdPrizeWinners { get; set; }
        public decimal TradicionalPrimeraThirdPrizeAmountPerWinner { get; set; }

        public TradicionalPrimeraWinners(
            decimal TradicionalPrimeraFirstPrizeTotalAmount, 
            List<Player> TradicionalPrimeraFirstPrizeWinners,
            decimal TradicionalPrimeraSecondPrizeTotalAmount, 
            List<Player> TradicionalPrimeraSecondPrizeWinners, 
            decimal TradicionalPrimeraThirdPrizeTotalAmount,
            List<Player> TradicionalPrimeraThirdPrizeWinners
            )
        {
            this.TradicionalPrimeraFirstPrizeTotalAmount = TradicionalPrimeraFirstPrizeTotalAmount;
            this.TradicionalPrimeraFirstPrizeWinners = TradicionalPrimeraFirstPrizeWinners;
            if (TradicionalPrimeraFirstPrizeWinners.Count > 0)
            {
                this.TradicionalPrimeraFirstPrizeAmountPerWinner = TradicionalPrimeraFirstPrizeTotalAmount / TradicionalPrimeraFirstPrizeWinners.Count;
            }
            else
            {
                this.TradicionalPrimeraFirstPrizeAmountPerWinner = 0;
            }
            this.TradicionalPrimeraSecondPrizeTotalAmount = TradicionalPrimeraSecondPrizeTotalAmount;
            this.TradicionalPrimeraSecondPrizeWinners = TradicionalPrimeraSecondPrizeWinners;
            if (TradicionalPrimeraSecondPrizeWinners.Count > 0)
            {
                this.TradicionalPrimeraSecondPrizeAmountPerWinner = TradicionalPrimeraSecondPrizeTotalAmount / TradicionalPrimeraSecondPrizeWinners.Count;
            }
            else
            {
                this.TradicionalPrimeraSecondPrizeAmountPerWinner = 0;
            }
            this.TradicionalPrimeraThirdPrizeTotalAmount = TradicionalPrimeraThirdPrizeTotalAmount;
            this.TradicionalPrimeraThirdPrizeWinners = TradicionalPrimeraThirdPrizeWinners;
            if (TradicionalPrimeraThirdPrizeWinners.Count > 0)
            {
                this.TradicionalPrimeraThirdPrizeAmountPerWinner = TradicionalPrimeraThirdPrizeTotalAmount / TradicionalPrimeraThirdPrizeWinners.Count;
            }
            else
            {
                this.TradicionalPrimeraThirdPrizeAmountPerWinner = 0;
            }
        }
    }
}
