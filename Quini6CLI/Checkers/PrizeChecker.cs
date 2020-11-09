using Quini6CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quini6CLI.Checkers
{
    class PrizeChecker : IPrizeChecker
    {
        private List<Player> Players;
        private decimal TradicionalPrimeraFirstPrize { get; set; }
        private decimal TradicionalPrimeraSecondPrize { get; set; }
        private decimal TradicionalPrimeraThirdPrize { get; set; }
        private decimal TradicionalSegundaFirstPrize { get; set; }
        private decimal TradicionalSegundaSecondPrize { get; set; }
        private decimal TradicionalSegundaThirdPrize { get; set; }
        private decimal RevanchaPrize { get; set; }
        private decimal SiempreSalePrize { get; set; }
        private decimal PozoExtraPrize { get; set; }

        public PrizeChecker(
            List<Player> Players,
            decimal TradicionalPrimeraFirstPrize,
            decimal TradicionalPrimeraSecondPrize,
            decimal TradicionalPrimeraThirdPrize,
            decimal TradicionalSegundaFirstPrize,
            decimal TradicionalSegundaSecondPrize,
            decimal TradicionalSegundaThirdPrize,
            decimal RevanchaPrize,
            decimal SiempreSalePrize,
            decimal PozoExtraPrize
            )
        {
            this.Players = Players;
            this.TradicionalPrimeraFirstPrize = TradicionalPrimeraFirstPrize;
            this.TradicionalPrimeraSecondPrize = TradicionalPrimeraSecondPrize;
            this.TradicionalPrimeraThirdPrize = TradicionalPrimeraThirdPrize;
            this.TradicionalSegundaFirstPrize = TradicionalSegundaFirstPrize;
            this.TradicionalSegundaSecondPrize = TradicionalSegundaSecondPrize;
            this.TradicionalSegundaThirdPrize = TradicionalSegundaThirdPrize;
            this.RevanchaPrize = RevanchaPrize;
            this.SiempreSalePrize = SiempreSalePrize;
            this.PozoExtraPrize = PozoExtraPrize;
        }

        public void CheckPrizes()
        {
            List<Player> TradicionalPrimeraFirstPrizeWinners = new List<Player>();
            List<Player> TradicionalPrimeraSecondPrizeWinners = new List<Player>();
            List<Player> TradicionalPrimeraThirdPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaFirstPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaSecondPrizeWinners = new List<Player>();
            List<Player> TradicionalSegundaThirdPrizeWinners = new List<Player>();
            List<Player> RevanchaPrizeWinners = new List<Player>();
            List<Player> SiempreSalePrizeWinners = new List<Player>();
            List<Player> PozoExtraPrizeWinners = new List<Player>();
            List<Player> NoPrizeTradicionalPrimera = new List<Player>();
            List<Player> NoPrizeTradicionalSegunda = new List<Player>();
            List<Player> NoPrize = new List<Player>();

            //Tradicional Primera First Prize
            foreach (Player p in Players)
            {
                
            }

            //Tradicional Primera Second Prize
            foreach (Player p in NoPrizeTradicionalPrimera)
            {

            }

            //Tradicional Primera Third Prize
            foreach (Player p in NoPrizeTradicionalPrimera)
            {
                
            }

            //Tradicional Segunda First Prize
            foreach (Player p in Players)
            {

            }

            //Tradicional Segunda Second Prize
            foreach (Player p in NoPrizeTradicionalSegunda)
            {

            }

            //Tradicional Segunda Third Prize
            foreach (Player p in NoPrizeTradicionalSegunda)
            {

            }

            //Revancha
            foreach (Player p in Players.Where(pl => pl.Games == Player.GameParticipation.TradicionalAndRevancha || pl.Games == Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale))
            {

            }

            //Siempre Sale
            foreach (Player p in Players.Where(pl => pl.Games == Player.GameParticipation.TradicionalAndSiempreSale || pl.Games == Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale))
            {

            }

            //Pozo extra: to participate here the player must not have any 6 hits in any of the other drawings
            foreach (Player p in Players.Where(pl => !TradicionalPrimeraFirstPrizeWinners.Contains(pl) && !TradicionalSegundaFirstPrizeWinners.Contains(pl) && !RevanchaPrizeWinners.Contains(pl)))
            {
                //TBD - check that if this person won Siempre Sale, they didn't do it with 6 hits.

            }

        }

    }
}
