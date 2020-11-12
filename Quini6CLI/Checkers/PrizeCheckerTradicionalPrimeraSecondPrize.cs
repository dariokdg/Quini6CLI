using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using Quini6CLI.Helpers;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerTradicionalPrimeraSecondPrize : IPrizeChecker
    {
        public GameTypeResult Results { get; set; }
        public decimal Prize { get; set; }

        public PrizeCheckerTradicionalPrimeraSecondPrize(GameTypeResult Results, decimal TradicionalPrimeraSecondPrize)
        {
            this.Results = Results;
            Prize = TradicionalPrimeraSecondPrize;
        }

        public IWinner CheckPrizes()
        {
            List<Player> TradicionalPrimeraSecondPrizeWinners = new List<Player>();
            ResultChecker RC = new ResultChecker();
            PrizeProvider PP = new PrizeProvider();
            foreach (Player TPPlayer in Results.Players)
            {
                int MatchingNumbers = RC.GetMatchingNumbers(TPPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults);
                PrizeTypeTradicionalPrimera PTTP = PP.CheckMatchesTradicionalPrimera(MatchingNumbers);
                if (PTTP == PrizeTypeTradicionalPrimera.SecondPrize)
                {
                    TradicionalPrimeraSecondPrizeWinners.Add(TPPlayer);
                }
            }
            return new TradicionalPrimeraSecondPrizeWinners(Prize, TradicionalPrimeraSecondPrizeWinners);
        }

    }
}