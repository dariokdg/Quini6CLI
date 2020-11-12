using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Interfaces
{
    interface IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }
    }
}
