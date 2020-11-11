using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerPozoExtra : IPrizeChecker
    {
        private GameTypeResult Results;
        private decimal PozoExtraPrize { get; set; }

        public PrizeCheckerPozoExtra(
            GameTypeResult Results,
            decimal PozoExtraPrize
            )
        {
            this.Results = Results;
            this.PozoExtraPrize = PozoExtraPrize;
        }

        public PozoExtraWinners CheckPrizes(TradicionalPrimeraWinners TPW, TradicionalSegundaWinners TSW, RevanchaWinners RW)
        {
            List<Player> PozoExtraPlayers = new List<Player>();
            List<Player> PozoExtraPrizeWinners = new List<Player>();
            List<Player> NoPrize = new List<Player>();

            //Pozo extra: to participate here the player must not have any 6 hits in any of the other drawings (excluding 'Siempre Sale')
            foreach (Player PotentialPozoExtraPlayer in Results.Players)
            {
                if (TPW.TradicionalPrimeraFirstPrizeWinners.Contains(PotentialPozoExtraPlayer) 
                    || TSW.TradicionalSegundaFirstPrizeWinners.Contains(PotentialPozoExtraPlayer) 
                    || RW.RevanchaPrizeWinners.Contains(PotentialPozoExtraPlayer)
                    )
                {
                    continue;
                }
                else
                {
                    PozoExtraPlayers.Add(PotentialPozoExtraPlayer);
                }
            }

            foreach (Player PEPlayer in PozoExtraPlayers)
            {
                ResultChecker RC = new ResultChecker();
                PrizeProvider PP = new PrizeProvider();
                if (PP.CheckMatchesPozoExtra(RC.GetMatchingNumbers(PEPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults)) == PrizeTypePozoExtra.Prize)
                {
                    //Winner winner chicken dinner
                    PozoExtraPrizeWinners.Add(PEPlayer);
                }
                else
                {
                    NoPrize.Add(PEPlayer);
                }
            }

            PozoExtraWinners PE = new PozoExtraWinners(
                PozoExtraPrize,
                PozoExtraPrizeWinners
                );

            return PE;
        }
    }
}