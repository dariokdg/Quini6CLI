using Quini6CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quini6CLI.Checkers
{
    class ResultChecker : IResultChecker
    {
        public ResultChecker()
        {

        }

        public int GetMatchingNumbers(List<int> UserSelectedNumbers, List<int> Quini6Results)
        {
            int MatchingNumbers = 0;
            foreach (int UserSelectedNumber in UserSelectedNumbers)
            {
                if (Quini6Results.Contains(UserSelectedNumber))
                {
                    MatchingNumbers++;
                }
            }
            return MatchingNumbers;
        }
    }
}
