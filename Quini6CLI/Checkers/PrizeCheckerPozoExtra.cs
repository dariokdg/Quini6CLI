using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerPozoExtra : IPrizeChecker
    {
        private GameTypeResult Results;
        private decimal PozoExtraPrize { get; set; }

        public PrizeCheckerPozoExtra(
            GameTypeResult Results,
            decimal PozoExtraPrize
            )
        {
            this.Results = Results;
            this.PozoExtraPrize = PozoExtraPrize;
        }

        public void CheckPrizes()
        {
            List<Player> PozoExtraPrizeWinners = new List<Player>();
            List<Player> NoPrize = new List<Player>();

            //Pozo extra: to participate here the player must not have any 6 hits in any of the other drawings
            //foreach (Player p in Players.Where(pl => !TradicionalPrimeraFirstPrizeWinners.Contains(pl) && !TradicionalSegundaFirstPrizeWinners.Contains(pl) && !RevanchaPrizeWinners.Contains(pl)))
            //{
            //    //TBD - check that if this person won Siempre Sale, they didn't do it with 6 hits.

            //}

        }
    }
}