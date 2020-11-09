using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerTradicionalSegunda : IPrizeChecker
    {
        private GameTypeResult Results;
        private decimal TradicionalSegundaFirstPrize { get; set; }
        private decimal TradicionalSegundaSecondPrize { get; set; }
        private decimal TradicionalSegundaThirdPrize { get; set; }

        public PrizeCheckerTradicionalSegunda(
            GameTypeResult Results,
            decimal TradicionalSegundaFirstPrize,
            decimal TradicionalSegundaSecondPrize,
            decimal TradicionalSegundaThirdPrize
            )
        {
            this.Results = Results;
            this.TradicionalSegundaFirstPrize = TradicionalSegundaFirstPrize;
            this.TradicionalSegundaSecondPrize = TradicionalSegundaSecondPrize;
            this.TradicionalSegundaThirdPrize = TradicionalSegundaThirdPrize;
        }

        public void CheckPrizes()
        {
            List<Player> TradicionalSegundaFirstPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaSecondPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaThirdPrizeWinners = new List<Player>();
            List<Player> NoPrizeTradicionalSegunda = new List<Player>();
            List<Player> NoPrize = new List<Player>();

            //Tradicional Segunda First Prize
            foreach (Player p in Results.Players)
            {

            }

            //Tradicional Segunda Second Prize
            foreach (Player p in NoPrizeTradicionalSegunda)
            {

            }

            //Tradicional Segunda Third Prize
            foreach (Player p in NoPrizeTradicionalSegunda)
            {

            }

        }
    }
}
