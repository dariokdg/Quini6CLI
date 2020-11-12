using Quini6CLI.Helpers;

namespace Quini6CLI.Interfaces
{
    interface IPrizeChecker
    {
        public GameTypeResult Results { get; set; }
        public decimal Prize { get; set; }
        public IWinner CheckPrizes();
    }
}
