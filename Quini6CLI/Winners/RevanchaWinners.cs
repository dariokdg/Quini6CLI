using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Winners
{
    class RevanchaWinners : IWinner
    {
        public List<Player> PrizeWinnerList { get; set; }
        public decimal PrizeAmountPerWinner { get; set; }
        public RevanchaWinners(decimal RevanchaPrizeTotalAmount, List<Player> RevanchaPrizeWinnerList)
        {
            PrizeWinnerList = RevanchaPrizeWinnerList;
            if (RevanchaPrizeWinnerList.Count > 0)
            {
                PrizeAmountPerWinner = RevanchaPrizeTotalAmount / RevanchaPrizeWinnerList.Count;
            }
            else
            {
                PrizeAmountPerWinner = 0;
            }
        }
    }
}