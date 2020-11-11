using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Helpers
{
    class GameSpends
    {
        public decimal TradicionalSpends { get; set; }
        public decimal RevanchaSpends { get; set; }
        public decimal SiempreSaleSpends { get; set; }
        public GameSpends(decimal TotalSpends, GameParticipation Games)
        {
            if (Games == GameParticipation.TradicionalOnly)
            {
                TradicionalSpends = TotalSpends;
                RevanchaSpends = 0;
                SiempreSaleSpends = 0;
            }
            else if (Games == GameParticipation.TradicionalAndRevancha)
            {
                TradicionalSpends = TotalSpends / 6 * 5;
                RevanchaSpends = TotalSpends / 6;
                SiempreSaleSpends = 0;
            }
            else if (Games == GameParticipation.TradicionalAndRevanchaAndSiempreSale)
            {
                TradicionalSpends = TotalSpends / 8 * 5;
                RevanchaSpends = TotalSpends / 8;
                SiempreSaleSpends = TotalSpends / 4;
            }
        }
    }
}
