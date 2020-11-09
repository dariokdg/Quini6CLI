using System;
using System.Collections.Generic;
using System.Text;

namespace Quini6CLI.Enumerators
{
    static class Enumerators
    {
        public enum GameType
        {
            TradicionalPrimera,
            TradicionalSegunda,
            Revancha,
            SiempreSale,
            PozoExtra
        }
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
            Prize,
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
            Prize,
            NoPrize
        }
    }
}
