using System.Collections.Generic;
using Quini6CLI.Interfaces;
using Quini6CLI.Core;
using Quini6CLI.Providers;
using Quini6CLI.Winners;
using Quini6CLI.Helpers;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Checkers
{
    class PrizeCheckerPozoExtra : IPrizeChecker
    {
        public GameTypeResult Results { get; set; }
        public decimal Prize { get; set; }
        private IWinner TPFPW { get; set; }
        private IWinner TSFPW { get; set; }
        private IWinner RW { get; set; }

        public PrizeCheckerPozoExtra(GameTypeResult Results, decimal PozoExtraPrize, IWinner TPFPW, IWinner TSFPW, IWinner RW)
        {
            this.Results = Results;
            Prize = PozoExtraPrize;
            this.TPFPW = TPFPW;
            this.TSFPW = TSFPW;
            this.RW = RW;
        }

        public IWinner CheckPrizes()
        {
            List<Player> PozoExtraPlayers = new List<Player>();
            List<Player> PozoExtraPrizeWinners = new List<Player>();
            ResultChecker RC = new ResultChecker();
            PrizeProvider PP = new PrizeProvider();

            //Pozo extra: to participate here the player must not have any 6 hits in any of the other drawings (excluding 'Siempre Sale')
            foreach (Player PotentialPozoExtraPlayer in Results.Players)
            {
                if (TPFPW.PrizeWinnerList.Contains(PotentialPozoExtraPlayer) 
                    || TSFPW.PrizeWinnerList.Contains(PotentialPozoExtraPlayer) 
                    || RW.PrizeWinnerList.Contains(PotentialPozoExtraPlayer)
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
                int MatchingNumbers = RC.GetMatchingNumbers(PEPlayer.Quini6Ticket.SelectedNumbers, Results.DrawingResults);
                PrizeTypePozoExtra PTPE = PP.CheckMatchesPozoExtra(MatchingNumbers);
                if (PTPE == PrizeTypePozoExtra.Prize)
                {
                    //Winner winner chicken dinner
                    PozoExtraPrizeWinners.Add(PEPlayer);
                }
            }

            return new PozoExtraWinners(Prize,PozoExtraPrizeWinners);
        }
    }
}