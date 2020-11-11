using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using static Quini6CLI.Enumerators.Enumerators;

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

        public TradicionalSegundaWinners CheckPrizes()
        {
            List<Player> TradicionalSegundaFirstPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaSecondPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaThirdPrizeWinners = new List<Player>();
            List<Player> NoPrizeTradicionalSegundaFP = new List<Player>();
            List<Player> NoPrizeTradicionalSegundaSP = new List<Player>();
            List<Player> NoPrizeTradicionalSegundaTP = new List<Player>();

            //Tradicional Segunda First Prize
            foreach (Player TSPlayer in Results.Players)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalSegunda(RC.GetMatchingNumbers(TSPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalSegunda.FirstPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalSegundaFirstPrizeWinners.Add(TSPlayer);
                }
                else
                {
                    NoPrizeTradicionalSegundaFP.Add(TSPlayer);
                }
            }

            //Tradicional Segunda Second Prize
            foreach (Player TSPlayer in NoPrizeTradicionalSegundaFP)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalSegunda(RC.GetMatchingNumbers(TSPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalSegunda.SecondPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalSegundaSecondPrizeWinners.Add(TSPlayer);
                }
                else
                {
                    NoPrizeTradicionalSegundaSP.Add(TSPlayer);
                }
            }

            //Tradicional Segunda Third Prize
            foreach (Player TSPlayer in NoPrizeTradicionalSegundaSP)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalSegunda(RC.GetMatchingNumbers(TSPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalSegunda.ThirdPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalSegundaThirdPrizeWinners.Add(TSPlayer);
                }
                else
                {
                    NoPrizeTradicionalSegundaTP.Add(TSPlayer);
                }
            }

            TradicionalSegundaWinners TSW = new TradicionalSegundaWinners(
                TradicionalSegundaFirstPrize,
                TradicionalSegundaFirstPrizeWinners,
                TradicionalSegundaSecondPrize,
                TradicionalSegundaSecondPrizeWinners,
                TradicionalSegundaThirdPrize,
                TradicionalSegundaThirdPrizeWinners
                );

            return TSW;

        }
    }
}
