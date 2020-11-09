using Quini6CLI.Interfaces;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Providers
{
    class PrizeProvider : IPrizeProvider
    {

        public PrizeProvider()
        {

        }

        public Matches CheckMatches(int NumberOfMatches)
        {
            switch (NumberOfMatches)
            {
                case 6:
                    return Matches.SixMatches;
                case 5:
                    return Matches.FiveMatches;
                case 4:
                    return Matches.FourMatches;
                case 3:
                    return Matches.ThreeMatches;
                case 2:
                    return Matches.TwoMatches;
                case 1:
                    return Matches.OneMatch;
                case 0:
                    return Matches.NoMatches;
                default:
                    return Matches.NoMatches;
            }
        }

        public PrizeTypeTradicionalPrimera CheckMatchesTradicionalPrimera(int NumberOfMatches)
        {
            Matches TradicionalPrimeraMatches = CheckMatches(NumberOfMatches);
            switch (TradicionalPrimeraMatches)
            {
                case Matches.SixMatches:
                    return PrizeTypeTradicionalPrimera.FirstPrize;
                case Matches.FiveMatches:
                    return PrizeTypeTradicionalPrimera.SecondPrize;
                case Matches.FourMatches:
                    return PrizeTypeTradicionalPrimera.ThirdPrize;
                case Matches.ThreeMatches:
                case Matches.TwoMatches:
                case Matches.OneMatch:
                case Matches.NoMatches:
                    return PrizeTypeTradicionalPrimera.NoPrize;
                default:
                    return PrizeTypeTradicionalPrimera.NoPrize;
            }
        }

        public PrizeTypeTradicionalSegunda CheckMatchesTradicionalSegunda(int NumberOfMatches)
        {
            Matches TradicionalSegundaMatches = CheckMatches(NumberOfMatches);
            switch (TradicionalSegundaMatches)
            {
                case Matches.SixMatches:
                    return PrizeTypeTradicionalSegunda.FirstPrize;
                case Matches.FiveMatches:
                    return PrizeTypeTradicionalSegunda.SecondPrize;
                case Matches.FourMatches:
                    return PrizeTypeTradicionalSegunda.ThirdPrize;
                case Matches.ThreeMatches:
                case Matches.TwoMatches:
                case Matches.OneMatch:
                case Matches.NoMatches:
                    return PrizeTypeTradicionalSegunda.NoPrize;
                default:
                    return PrizeTypeTradicionalSegunda.NoPrize;
            }
        }

        public PrizeTypeRevancha CheckMatchesRevancha(int NumberOfMatches)
        {
            Matches RevanchaMatches = CheckMatches(NumberOfMatches);
            switch (RevanchaMatches)
            {
                case Matches.SixMatches:
                    return PrizeTypeRevancha.Prize;
                case Matches.FiveMatches:
                case Matches.FourMatches:
                case Matches.ThreeMatches:
                case Matches.TwoMatches:
                case Matches.OneMatch:
                case Matches.NoMatches:
                    return PrizeTypeRevancha.NoPrize;
                default:
                    return PrizeTypeRevancha.NoPrize;
            }
        }

        public PrizeTypeSiempreSale CheckMatchesSiempreSale(int NumberOfMatches)
        {
            Matches SiempreSaleMatches = CheckMatches(NumberOfMatches);
            switch (SiempreSaleMatches)
            {
                case Matches.SixMatches:
                    return PrizeTypeSiempreSale.PotentialWinnerSixMatches;
                case Matches.FiveMatches:
                    return PrizeTypeSiempreSale.PotentialWinnerFiveMatches;
                case Matches.FourMatches:
                    return PrizeTypeSiempreSale.PotentialWinnerFourMatches;
                case Matches.ThreeMatches:
                    return PrizeTypeSiempreSale.PotentialWinnerThreeMatches;
                case Matches.TwoMatches:
                    return PrizeTypeSiempreSale.PotentialWinnerTwoMatches;
                case Matches.OneMatch:
                    return PrizeTypeSiempreSale.PotentialWinnerOneMatch;
                case Matches.NoMatches:
                    return PrizeTypeSiempreSale.NoPrize;
                default:
                    return PrizeTypeSiempreSale.NoPrize;
            }
        }

        public PrizeTypePozoExtra CheckMatchesPozoExtra(int NumberOfMatches)
        {
            Matches PozoExtraMatches = CheckMatches(NumberOfMatches);
            switch (PozoExtraMatches)
            {
                case Matches.SixMatches:
                    return PrizeTypePozoExtra.Prize;
                case Matches.FiveMatches:
                case Matches.FourMatches:
                case Matches.ThreeMatches:
                case Matches.TwoMatches:
                case Matches.OneMatch:
                case Matches.NoMatches:
                    return PrizeTypePozoExtra.NoPrize;
                default:
                    return PrizeTypePozoExtra.NoPrize;
            }
        }
    }
}
