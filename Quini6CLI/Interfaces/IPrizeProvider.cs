using System;
using System.Collections.Generic;
using System.Text;

namespace Quini6CLI.Interfaces
{
    interface IPrizeProvider
    {
        public enum Matches
        {
            NoMatches,
            OneMatch,
            TwoMatches,
            ThreeMatches,
            FourMatches,
            FiveMatches,
            SixMatches
        }

        public enum PrizeTypeTradicionalPrimera
        {
            FirstPrize,
            SecondPrize,
            ThirdPrize,
            NoPrize
        }

        public enum PrizeTypeTradicionalSegunda
        {
            FirstPrize,
            SecondPrize,
            ThirdPrize,
            NoPrize
        }

        public enum PrizeTypeRevancha
        {
            FirstPrize,
            NoPrize
        }

        public enum PrizeTypeSiempreSale
        {
            PotentialWinnerSixMatches,
            PotentialWinnerFiveMatches,
            PotentialWinnerFourMatches,
            PotentialWinnerThreeMatches,
            PotentialWinnerTwoMatches,
            PotentialWinnerOneMatch,
            NoPrize
        }

        public enum PrizeTypePozoExtra
        {
            FirstPrize,
            NoPrize
        }

        public Matches CheckMatches(int MatchingNumbers);
        public PrizeTypeTradicionalPrimera CheckMatchesTradicionalPrimera(Matches TradicionalPrimeraMatches);
        public PrizeTypeTradicionalSegunda CheckMatchesTradicionalSegunda(Matches TradicionalSegundaMatches);
        public PrizeTypeRevancha CheckMatchesRevancha(Matches RevanchaMatches);
        public PrizeTypeSiempreSale CheckMatchesSiempreSale(Matches SiempreSaleMatches);
        public PrizeTypePozoExtra CheckMatchesPozoExtra(Matches PozoExtraMatches);

    }
}
