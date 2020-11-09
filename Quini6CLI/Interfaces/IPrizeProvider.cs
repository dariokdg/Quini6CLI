using System;
using System.Collections.Generic;
using System.Text;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Interfaces
{
    interface IPrizeProvider
    {
        public Matches CheckMatches(int NumberOfMatches);
        public PrizeTypeTradicionalPrimera CheckMatchesTradicionalPrimera(int NumberOfMatches);
        public PrizeTypeTradicionalSegunda CheckMatchesTradicionalSegunda(int NumberOfMatches);
        public PrizeTypeRevancha CheckMatchesRevancha(int NumberOfMatches);
        public PrizeTypeSiempreSale CheckMatchesSiempreSale(int NumberOfMatches);
        public PrizeTypePozoExtra CheckMatchesPozoExtra(int NumberOfMatches);

    }
}
