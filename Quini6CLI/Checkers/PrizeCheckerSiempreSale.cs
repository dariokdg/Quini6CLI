using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using System.Collections.Generic;
using System.Linq;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerSiempreSale : IPrizeChecker
    {
        private GameTypeResult Results;
        private decimal SiempreSalePrize { get; set; }

        public PrizeCheckerSiempreSale(
            GameTypeResult Results,
            decimal SiempreSalePrize
            )
        {
            this.Results = Results;
            this.SiempreSalePrize = SiempreSalePrize;
        }

        public void CheckPrizes()
        {
            List<Player> SiempreSalePrizeWinners = new List<Player>();
            List<Player> NoPrize = new List<Player>();

            //Siempre Sale
            foreach (Player p in Results.Players)
            {

            }

        }
    }
}