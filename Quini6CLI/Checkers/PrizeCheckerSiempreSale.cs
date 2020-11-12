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
            IResultChecker RC = new ResultChecker();
            IPrizeProvider PP = new PrizeProvider();
            foreach (Player SSPlayer in Results.Players)
            {
                PrizeTypeSiempreSale SiempreSalePlayerResults = PP.CheckMatchesSiempreSale(RC.GetMatchingNumbers(SSPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults));
                switch (SiempreSalePlayerResults)
                {
                    case PrizeTypeSiempreSale.PotentialWinnerSixMatches:
                        SiempreSalePotentialWinnersSixMatches.Add(SSPlayer);
                        break;
                    case PrizeTypeSiempreSale.PotentialWinnerFiveMatches:
                        SiempreSalePotentialWinnersFiveMatches.Add(SSPlayer);
                        break;
                    case PrizeTypeSiempreSale.PotentialWinnerFourMatches:
                        SiempreSalePotentialWinnersFourMatches.Add(SSPlayer);
                        break;
                    case PrizeTypeSiempreSale.PotentialWinnerThreeMatches:
                        SiempreSalePotentialWinnersThreeMatches.Add(SSPlayer);
                        break;
                    case PrizeTypeSiempreSale.PotentialWinnerTwoMatches:
                        SiempreSalePotentialWinnersTwoMatches.Add(SSPlayer);
                        break;
                    case PrizeTypeSiempreSale.PotentialWinnerOneMatch:
                        SiempreSalePotentialWinnersOneMatch.Add(SSPlayer);
                        break;
                    default:
                        break;
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

            return new SiempreSaleWinners(Prize, SiempreSalePrizeWinners, NumberOfMatchesWinners);
        }
    }
}