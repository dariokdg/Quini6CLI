using Quini6CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quini6CLI
{
    class PrizeProvider : IPrizeProvider
    {

        public PrizeProvider()
        {

        }

        public IPrizeProvider.Matches CheckMatches(int MatchingNumbers)
        {
            switch (MatchingNumbers)
            {
                case 6:
                    return IPrizeProvider.Matches.SixMatches;
                case 5:
                    return IPrizeProvider.Matches.FiveMatches;
                case 4:
                    return IPrizeProvider.Matches.FourMatches;
                case 3:
                    return IPrizeProvider.Matches.ThreeMatches;
                case 2:
                    return IPrizeProvider.Matches.TwoMatches;
                case 1:
                    return IPrizeProvider.Matches.OneMatch;
                case 0:
                    return IPrizeProvider.Matches.NoMatches;
                default:
                    return IPrizeProvider.Matches.NoMatches;
            }
        }

        public IPrizeProvider.PrizeTypeTradicionalPrimera CheckMatchesTradicionalPrimera(IPrizeProvider.Matches TradicionalPrimeraMatches)
        {
            switch (TradicionalPrimeraMatches)
            {
                case IPrizeProvider.Matches.SixMatches:
                    return IPrizeProvider.PrizeTypeTradicionalPrimera.FirstPrize;
                case IPrizeProvider.Matches.FiveMatches:
                    return IPrizeProvider.PrizeTypeTradicionalPrimera.SecondPrize;
                case IPrizeProvider.Matches.FourMatches:
                    return IPrizeProvider.PrizeTypeTradicionalPrimera.ThirdPrize;
                case IPrizeProvider.Matches.ThreeMatches:
                case IPrizeProvider.Matches.TwoMatches:
                case IPrizeProvider.Matches.OneMatch:
                case IPrizeProvider.Matches.NoMatches:
                    return IPrizeProvider.PrizeTypeTradicionalPrimera.NoPrize;
                default:
                    return IPrizeProvider.PrizeTypeTradicionalPrimera.NoPrize;
            }
        }

        public IPrizeProvider.PrizeTypeTradicionalSegunda CheckMatchesTradicionalSegunda(IPrizeProvider.Matches TradicionalSegundaMatches)
        {
            switch (TradicionalSegundaMatches)
            {
                case IPrizeProvider.Matches.SixMatches:
                    return IPrizeProvider.PrizeTypeTradicionalSegunda.FirstPrize;
                case IPrizeProvider.Matches.FiveMatches:
                    return IPrizeProvider.PrizeTypeTradicionalSegunda.SecondPrize;
                case IPrizeProvider.Matches.FourMatches:
                    return IPrizeProvider.PrizeTypeTradicionalSegunda.ThirdPrize;
                case IPrizeProvider.Matches.ThreeMatches:
                case IPrizeProvider.Matches.TwoMatches:
                case IPrizeProvider.Matches.OneMatch:
                case IPrizeProvider.Matches.NoMatches:
                    return IPrizeProvider.PrizeTypeTradicionalSegunda.NoPrize;
                default:
                    return IPrizeProvider.PrizeTypeTradicionalSegunda.NoPrize;
            }
        }

        public IPrizeProvider.PrizeTypeRevancha CheckMatchesRevancha(IPrizeProvider.Matches RevanchaMatches)
        {
            switch (RevanchaMatches)
            {
                case IPrizeProvider.Matches.SixMatches:
                    return IPrizeProvider.PrizeTypeRevancha.FirstPrize;
                case IPrizeProvider.Matches.FiveMatches:
                case IPrizeProvider.Matches.FourMatches:
                case IPrizeProvider.Matches.ThreeMatches:
                case IPrizeProvider.Matches.TwoMatches:
                case IPrizeProvider.Matches.OneMatch:
                case IPrizeProvider.Matches.NoMatches:
                    return IPrizeProvider.PrizeTypeRevancha.NoPrize;
                default:
                    return IPrizeProvider.PrizeTypeRevancha.NoPrize;
            }
        }

        public IPrizeProvider.PrizeTypeSiempreSale CheckMatchesSiempreSale(IPrizeProvider.Matches SiempreSaleMatches)
        {
            switch (SiempreSaleMatches)
            {
                case IPrizeProvider.Matches.SixMatches:
                    return IPrizeProvider.PrizeTypeSiempreSale.PotentialWinnerSixMatches;
                case IPrizeProvider.Matches.FiveMatches:
                    return IPrizeProvider.PrizeTypeSiempreSale.PotentialWinnerFiveMatches;
                case IPrizeProvider.Matches.FourMatches:
                    return IPrizeProvider.PrizeTypeSiempreSale.PotentialWinnerFourMatches;
                case IPrizeProvider.Matches.ThreeMatches:
                    return IPrizeProvider.PrizeTypeSiempreSale.PotentialWinnerThreeMatches;
                case IPrizeProvider.Matches.TwoMatches:
                    return IPrizeProvider.PrizeTypeSiempreSale.PotentialWinnerTwoMatches;
                case IPrizeProvider.Matches.OneMatch:
                    return IPrizeProvider.PrizeTypeSiempreSale.PotentialWinnerOneMatch;
                case IPrizeProvider.Matches.NoMatches:
                    return IPrizeProvider.PrizeTypeSiempreSale.NoPrize;
                default:
                    return IPrizeProvider.PrizeTypeSiempreSale.NoPrize;
            }
        }

        public IPrizeProvider.PrizeTypePozoExtra CheckMatchesPozoExtra(IPrizeProvider.Matches PozoExtraMatches)
        {
            switch (PozoExtraMatches)
            {
                case IPrizeProvider.Matches.SixMatches:
                    return IPrizeProvider.PrizeTypePozoExtra.FirstPrize;
                case IPrizeProvider.Matches.FiveMatches:
                case IPrizeProvider.Matches.FourMatches:
                case IPrizeProvider.Matches.ThreeMatches:
                case IPrizeProvider.Matches.TwoMatches:
                case IPrizeProvider.Matches.OneMatch:
                case IPrizeProvider.Matches.NoMatches:
                    return IPrizeProvider.PrizeTypePozoExtra.NoPrize;
                default:
                    return IPrizeProvider.PrizeTypePozoExtra.NoPrize;
            }
        }
    }
}
