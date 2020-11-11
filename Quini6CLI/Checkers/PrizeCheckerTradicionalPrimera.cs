using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using Quini6CLI.Helpers;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerTradicionalPrimera : IPrizeChecker
    {
        private GameTypeResult Results;
        private decimal TradicionalPrimeraFirstPrize { get; set; }
        private decimal TradicionalPrimeraSecondPrize { get; set; }
        private decimal TradicionalPrimeraThirdPrize { get; set; }

        public PrizeCheckerTradicionalPrimera(
            GameTypeResult Results,
            decimal TradicionalPrimeraFirstPrize,
            decimal TradicionalPrimeraSecondPrize,
            decimal TradicionalPrimeraThirdPrize
            )
        {
            this.Results = Results;
            this.TradicionalPrimeraFirstPrize = TradicionalPrimeraFirstPrize;
            this.TradicionalPrimeraSecondPrize = TradicionalPrimeraSecondPrize;
            this.TradicionalPrimeraThirdPrize = TradicionalPrimeraThirdPrize;
        }

        public TradicionalPrimeraWinners CheckPrizes()
        {
            List<Player> TradicionalPrimeraFirstPrizeWinners = new List<Player>();
            List<Player> TradicionalPrimeraSecondPrizeWinners = new List<Player>();
            List<Player> TradicionalPrimeraThirdPrizeWinners = new List<Player>();
            List<Player> NoPrizeTradicionalPrimeraFP = new List<Player>();
            List<Player> NoPrizeTradicionalPrimeraSP = new List<Player>();
            List<Player> NoPrizeTradicionalPrimeraTP = new List<Player>();

            //Tradicional Primera First Prize
            foreach (Player TPPlayer in Results.Players)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalPrimera(RC.GetMatchingNumbers(TPPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalPrimera.FirstPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalPrimeraFirstPrizeWinners.Add(TPPlayer);
                }
                else
                {
                    NoPrizeTradicionalPrimeraFP.Add(TPPlayer);
                }
            }

            //Tradicional Primera Second Prize
            foreach (Player TPPlayer in NoPrizeTradicionalPrimeraFP)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalPrimera(RC.GetMatchingNumbers(TPPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalPrimera.SecondPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalPrimeraSecondPrizeWinners.Add(TPPlayer);
                }
                else
                {
                    NoPrizeTradicionalPrimeraSP.Add(TPPlayer);
                }
            }

            //Tradicional Primera Third Prize
            foreach (Player TPPlayer in NoPrizeTradicionalPrimeraSP)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalPrimera(RC.GetMatchingNumbers(TPPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalPrimera.ThirdPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalPrimeraThirdPrizeWinners.Add(TPPlayer);
                }
                else
                {
                    NoPrizeTradicionalPrimeraTP.Add(TPPlayer);
                }
            }

            TradicionalPrimeraWinners TPW = new TradicionalPrimeraWinners(
                TradicionalPrimeraFirstPrize, 
                TradicionalPrimeraFirstPrizeWinners, 
                TradicionalPrimeraSecondPrize, 
                TradicionalPrimeraSecondPrizeWinners, 
                TradicionalPrimeraThirdPrize, 
                TradicionalPrimeraThirdPrizeWinners
                );

            return TPW;
        }

    }
}
