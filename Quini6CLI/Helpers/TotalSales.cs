namespace Quini6CLI.Helpers
{
    class TotalSales
    {

        public decimal TotalTradicionalSales { get; set; }
        public int TotalTradicionalPlayers { get; set; }
        public decimal TotalRevanchaSales { get; set; }
        public int TotalRevanchaPlayers { get; set; }
        public decimal TotalSiempreSaleSales { get; set; }
        public int TotalSiempreSalePlayers { get; set; }

        public TotalSales(decimal TotalTradicionalSales, int TotalTradicionalPlayers, decimal TotalRevanchaSales, int TotalRevanchaPlayers, decimal TotalSiempreSaleSales, int TotalSiempreSalePlayers)
        {
            this.TotalTradicionalSales = TotalTradicionalSales;
            this.TotalTradicionalPlayers = TotalTradicionalPlayers;
            this.TotalRevanchaSales = TotalRevanchaSales;
            this.TotalRevanchaPlayers = TotalRevanchaPlayers;
            this.TotalSiempreSaleSales = TotalSiempreSaleSales;
            this.TotalSiempreSalePlayers = TotalSiempreSalePlayers;
        }

        public decimal GetTotalGameSales()
        {
            return TotalTradicionalSales + TotalRevanchaSales + TotalSiempreSaleSales;
        }

        public int GetTotalGamePlayers()
        {
            return TotalTradicionalPlayers + TotalRevanchaPlayers + TotalSiempreSalePlayers;
        }
    }
}
