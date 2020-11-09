﻿using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using System.Collections.Generic;
using Quini6CLI.Providers;
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

        public void CheckPrizes()
        {
            List<Player> TradicionalSegundaFirstPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaSecondPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaThirdPrizeWinners = new List<Player>();
            List<Player> NoPrizeTradicionalSegunda = new List<Player>();

            //Tradicional Segunda First Prize
            foreach (Player TSPlayer in Results.Players)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalSegunda(RC.GetMatchingNumbers(TSPlayer.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalSegunda.FirstPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalSegundaFirstPrizeWinners.Add(TSPlayer);
                }
                else
                {
                    NoPrizeTradicionalSegunda.Add(TSPlayer);
                }
            }

            //Tradicional Segunda Second Prize
            foreach (Player TSPlayer in NoPrizeTradicionalSegunda)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalSegunda(RC.GetMatchingNumbers(TSPlayer.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalSegunda.SecondPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalSegundaSecondPrizeWinners.Add(TSPlayer);
                    NoPrizeTradicionalSegunda.Remove(TSPlayer);
                }
            }

            //Tradicional Segunda Third Prize
            foreach (Player TSPlayer in NoPrizeTradicionalSegunda)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesTradicionalSegunda(RC.GetMatchingNumbers(TSPlayer.SelectedNumbers, Results.DrawingResults)) == PrizeTypeTradicionalSegunda.ThirdPrize)
                {
                    //Winner winner chicken dinner
                    TradicionalSegundaThirdPrizeWinners.Add(TSPlayer);
                    NoPrizeTradicionalSegunda.Remove(TSPlayer);
                }
            }

        }
    }
}
