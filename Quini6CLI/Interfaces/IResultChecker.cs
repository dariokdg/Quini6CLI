using System;
using System.Collections.Generic;
using System.Text;

namespace Quini6CLI.Interfaces
{
    interface IResultChecker
    {
        public int GetMatchingNumbers(List<int> UserSelectedNumbers, List<int> Quini6Results);
    }
}
