using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using Quini6CLI.Helpers;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerTradicionalSegundaThirdPrize : IPrizeChecker
    {
        public GameTypeResult Results { get; set; }
        public decimal Prize { get; set; }

        public PrizeCheckerTradicionalSegundaThirdPrize(GameTypeResult Results, decimal TradicionalSegundaThirdPrize)
        {
            this.Results = Results;
            Prize = TradicionalSegundaThirdPrize;
        }

        public IWinner CheckPrizes()
        {
            List<Player> TradicionalSegundaThirdPrizeWinners = new List<Player>();
            IResultChecker RC = new ResultChecker();
            IPrizeProvider PP = new PrizeProvider();
            foreach (Player TSPlayer in Results.Players)
            {
                int MatchingNumbers = RC.GetMatchingNumbers(TSPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults);
                PrizeTypeTradicionalSegunda PTTS = PP.CheckMatchesTradicionalSegunda(MatchingNumbers);
                if (PTTS == PrizeTypeTradicionalSegunda.ThirdPrize)
                {
                    TradicionalSegundaThirdPrizeWinners.Add(TSPlayer);
                }
            }
            return new TradicionalSegundaThirdPrizeWinners(Prize, TradicionalSegundaThirdPrizeWinners);
        }

    }
}