using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerTradicionalPrimera : IPrizeChecker
    {
        private GameTypeResult Results;
        private decimal TradicionalPrimeraFirstPrize { get; set; }
        private decimal TradicionalPrimeraSecondPrize { get; set; }
        private decimal TradicionalPrimeraThirdPrize { get; set; }

        public PrizeCheckerTradicionalPrimera(
            GameTypeResult Results,
            decimal TradicionalPrimeraFirstPrize,
            decimal TradicionalPrimeraSecondPrize,
            decimal TradicionalPrimeraThirdPrize
            )
        {
            this.Results = Results;
            this.TradicionalPrimeraFirstPrize = TradicionalPrimeraFirstPrize;
            this.TradicionalPrimeraSecondPrize = TradicionalPrimeraSecondPrize;
            this.TradicionalPrimeraThirdPrize = TradicionalPrimeraThirdPrize;
        }

        public void CheckPrizes()
        {
            List<Player> TradicionalPrimeraFirstPrizeWinners = new List<Player>();
            List<Player> TradicionalPrimeraSecondPrizeWinners = new List<Player>();
            List<Player> TradicionalPrimeraThirdPrizeWinners = new List<Player>();
            List<Player> NoPrizeTradicionalPrimera = new List<Player>();
            List<Player> NoPrize = new List<Player>();

            //Tradicional Primera First Prize
            foreach (Player p in Results.Players)
            {
                
            }

            //Tradicional Primera Second Prize
            foreach (Player p in NoPrizeTradicionalPrimera)
            {

            }

            //Tradicional Primera Third Prize
            foreach (Player p in NoPrizeTradicionalPrimera)
            {
                
            }

        }

    }
}
