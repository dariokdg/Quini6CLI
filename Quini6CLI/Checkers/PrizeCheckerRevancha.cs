using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using Quini6CLI.Helpers;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerRevancha : IPrizeChecker
    {
        public GameTypeResult Results { get; set; }
        public decimal Prize { get; set; }

        public PrizeCheckerRevancha(GameTypeResult Results, decimal RevanchaPrize)
        {
            this.Results = Results;
            Prize = RevanchaPrize;
        }

        public IWinner CheckPrizes()
        {
            List<Player> RevanchaPrizeWinners = new List<Player>();
            IResultChecker RC = new ResultChecker();
            IPrizeProvider PP = new PrizeProvider();
            foreach (Player RPlayer in Results.Players)
            {
                int MatchingNumbers = RC.GetMatchingNumbers(RPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults);
                PrizeTypeRevancha PTR = PP.CheckMatchesRevancha(MatchingNumbers);
                if (PTR == PrizeTypeRevancha.Prize)
                {
                    //Winner winner chicken dinner
                    RevanchaPrizeWinners.Add(RPlayer);
                }
            }
            return new RevanchaWinners(Prize, RevanchaPrizeWinners);
        }
    }
}