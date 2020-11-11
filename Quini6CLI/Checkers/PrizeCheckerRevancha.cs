using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using static Quini6CLI.Enumerators.Enumerators;

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

        public RevanchaWinners CheckPrizes()
        {
            List<Player> RevanchaPrizeWinners = new List<Player>();
            List<Player> NoPrize = new List<Player>();
            foreach (Player RPlayer in Results.Players)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesRevancha(RC.GetMatchingNumbers(RPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults)) == PrizeTypeRevancha.Prize)
                {
                    //Winner winner chicken dinner
                    RevanchaPrizeWinners.Add(RPlayer);
                }
                else
                {
                    NoPrize.Add(RPlayer);
                }
            }

            RevanchaWinners RW = new RevanchaWinners(
                RevanchaPrize,
                RevanchaPrizeWinners
                );

            return RW;
        }
    }
}