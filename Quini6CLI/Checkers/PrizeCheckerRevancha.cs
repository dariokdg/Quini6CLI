using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using System.Collections.Generic;
using System.Linq;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerRevancha : IPrizeChecker
    {
        private GameTypeResult Results;
        private decimal RevanchaPrize { get; set; }

        public PrizeCheckerRevancha(
            GameTypeResult Results,
            decimal RevanchaPrize
            )
        {
            this.Results = Results;
            this.RevanchaPrize = RevanchaPrize;
        }

        public void CheckPrizes()
        {
            List<Player> RevanchaPrizeWinners = new List<Player>();
            List<Player> NoPrize = new List<Player>();

            //Revancha
            foreach (Player p in Results.Players)
            {

            }

        }
    }
}