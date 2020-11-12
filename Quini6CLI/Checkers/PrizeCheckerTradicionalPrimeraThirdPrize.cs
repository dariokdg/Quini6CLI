using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using Quini6CLI.Helpers;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerTradicionalPrimeraThirdPrize : IPrizeChecker
    {
        public GameTypeResult Results { get; set; }
        public decimal Prize { get; set; }

        public PrizeCheckerTradicionalPrimeraThirdPrize(GameTypeResult Results, decimal TradicionalPrimeraThirdPrize)
        {
            this.Results = Results;
            Prize = TradicionalPrimeraThirdPrize;
        }

        public IWinner CheckPrizes()
        {
            List<Player> TradicionalPrimeraThirdPrizeWinners = new List<Player>();
            IResultChecker RC = new ResultChecker();
            IPrizeProvider PP = new PrizeProvider();
            foreach (Player TPPlayer in Results.Players)
            {
                int MatchingNumbers = RC.GetMatchingNumbers(TPPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults);
                PrizeTypeTradicionalPrimera PTTP = PP.CheckMatchesTradicionalPrimera(MatchingNumbers);
                if (PTTP == PrizeTypeTradicionalPrimera.ThirdPrize)
                {
                    TradicionalPrimeraThirdPrizeWinners.Add(TPPlayer);
                }
            }
            return new TradicionalPrimeraThirdPrizeWinners(Prize, TradicionalPrimeraThirdPrizeWinners);
        }

    }
}