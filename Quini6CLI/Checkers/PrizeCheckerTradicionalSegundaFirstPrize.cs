using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using Quini6CLI.Helpers;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerTradicionalSegundaFirstPrize : IPrizeChecker
    {
        public GameTypeResult Results { get; set; }
        public decimal Prize { get; set; }

        public PrizeCheckerTradicionalSegundaFirstPrize(GameTypeResult Results, decimal TradicionalSegundaFirstPrize)
        {
            this.Results = Results;
            Prize = TradicionalSegundaFirstPrize;
        }

        public IWinner CheckPrizes()
        {
            List<Player> TradicionalSegundaFirstPrizeWinners = new List<Player>();
            ResultChecker RC = new ResultChecker();
            PrizeProvider PP = new PrizeProvider();
            foreach (Player TSPlayer in Results.Players)
            {
                int MatchingNumbers = RC.GetMatchingNumbers(TSPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults);
                PrizeTypeTradicionalSegunda PTTS = PP.CheckMatchesTradicionalSegunda(MatchingNumbers);
                if (PTTS == PrizeTypeTradicionalSegunda.FirstPrize)
                {
                    TradicionalSegundaFirstPrizeWinners.Add(TSPlayer);
                }
            }
            return new TradicionalSegundaFirstPrizeWinners(Prize, TradicionalSegundaFirstPrizeWinners);
        }

    }
}