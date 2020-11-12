using System.Collections.Generic;
using System.Linq;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using Quini6CLI.Helpers;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerSiempreSale : IPrizeChecker
    {
        public GameTypeResult Results { get; set; }
        public decimal Prize { get; set; }

        public PrizeCheckerSiempreSale(GameTypeResult Results, decimal SiempreSalePrize)
        {
            this.Results = Results;
            Prize = SiempreSalePrize;
        }

        public IWinner CheckPrizes()
        {
            List<Player> SiempreSalePrizeWinners = new List<Player>();
            List<Player> SiempreSalePotentialWinnersSixMatches = new List<Player>();
            List<Player> SiempreSalePotentialWinnersFiveMatches = new List<Player>();
            List<Player> SiempreSalePotentialWinnersFourMatches = new List<Player>();
            List<Player> SiempreSalePotentialWinnersThreeMatches = new List<Player>();
            List<Player> SiempreSalePotentialWinnersTwoMatches = new List<Player>();
            List<Player> SiempreSalePotentialWinnersOneMatch = new List<Player>();
            List<Player> NoPrize = new List<Player>();
            foreach (Player SSPlayer in Results.Players)
            {
                IResultChecker RC = new ResultChecker();
                IPrizeProvider PP = new PrizeProvider();
                PrizeTypeSiempreSale SiempreSalePlayerResults = PP.CheckMatchesSiempreSale(RC.GetMatchingNumbers(SSPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults));
                if (SiempreSalePlayerResults == PrizeTypeSiempreSale.PotentialWinnerSixMatches)
                {
                    SiempreSalePotentialWinnersSixMatches.Add(SSPlayer);
                }
                else if (SiempreSalePlayerResults == PrizeTypeSiempreSale.PotentialWinnerFiveMatches)
                {
                    SiempreSalePotentialWinnersFiveMatches.Add(SSPlayer);
                }
                else if (SiempreSalePlayerResults == PrizeTypeSiempreSale.PotentialWinnerFourMatches)
                {
                    SiempreSalePotentialWinnersFourMatches.Add(SSPlayer);
                }
                else if (SiempreSalePlayerResults == PrizeTypeSiempreSale.PotentialWinnerThreeMatches)
                {
                    SiempreSalePotentialWinnersThreeMatches.Add(SSPlayer);
                }
                else if (SiempreSalePlayerResults == PrizeTypeSiempreSale.PotentialWinnerTwoMatches)
                {
                    SiempreSalePotentialWinnersTwoMatches.Add(SSPlayer);
                }
                else if (SiempreSalePlayerResults == PrizeTypeSiempreSale.PotentialWinnerOneMatch)
                {
                    SiempreSalePotentialWinnersOneMatch.Add(SSPlayer);
                }
                else
                {
                    NoPrize.Add(SSPlayer);
                }
            }

            int NumberOfMatchesWinners = 0;

            if (SiempreSalePotentialWinnersSixMatches.Any())
            {
                foreach (Player SSPlayer in SiempreSalePotentialWinnersSixMatches)
                {
                    SiempreSalePrizeWinners.Add(SSPlayer);
                }
                NumberOfMatchesWinners = 6;
            }
            else if (SiempreSalePotentialWinnersFiveMatches.Any())
            {
                foreach (Player SSPlayer in SiempreSalePotentialWinnersFiveMatches)
                {
                    SiempreSalePrizeWinners.Add(SSPlayer);
                }
                NumberOfMatchesWinners = 5;
            }
            else if (SiempreSalePotentialWinnersFourMatches.Any())
            {
                foreach (Player SSPlayer in SiempreSalePotentialWinnersFourMatches)
                {
                    SiempreSalePrizeWinners.Add(SSPlayer);
                }
                NumberOfMatchesWinners = 4;
            }
            else if (SiempreSalePotentialWinnersThreeMatches.Any())
            {
                foreach (Player SSPlayer in SiempreSalePotentialWinnersThreeMatches)
                {
                    SiempreSalePrizeWinners.Add(SSPlayer);
                }
                NumberOfMatchesWinners = 3;
            }
            else if (SiempreSalePotentialWinnersTwoMatches.Any())
            {
                foreach (Player SSPlayer in SiempreSalePotentialWinnersTwoMatches)
                {
                    SiempreSalePrizeWinners.Add(SSPlayer);
                }
                NumberOfMatchesWinners = 2;
            }
            else if (SiempreSalePotentialWinnersOneMatch.Any())
            {
                foreach (Player SSPlayer in SiempreSalePotentialWinnersOneMatch)
                {
                    SiempreSalePrizeWinners.Add(SSPlayer);
                }
                NumberOfMatchesWinners = 1;
            }

            foreach (Player SSPlayer in Results.Players)
            {
                if (!SiempreSalePrizeWinners.Contains(SSPlayer))
                {
                    NoPrize.Add(SSPlayer);
                }
            }

            return new SiempreSaleWinners(Prize, SiempreSalePrizeWinners, NumberOfMatchesWinners);
        }
    }
}