namespace Quini6CLI.Generators
{
    class PrizeGenerator
    {
        public decimal TotalTradicionalSales = 0;
        public decimal TotalRevanchaSales = 0;
        public decimal TotalSiempreSaleSales = 0;
        public decimal TradicionalPrimeraFirstPrize = 0;
        public decimal TradicionalPrimeraSecondPrize = 0;
        public decimal TradicionalPrimeraThirdPrize = 0;
        public decimal TradicionalSegundaFirstPrize = 0;
        public decimal TradicionalSegundaSecondPrize = 0;
        public decimal TradicionalSegundaThirdPrize = 0;
        public decimal RevanchaPrize = 0;
        public decimal SiempreSalePrize = 0;
        public decimal PozoExtraPrize = 0;

        public PrizeGenerator(decimal TotalTradicionalSales, decimal TotalRevanchaSales, decimal TotalSiempreSaleSales)
        {
            this.TotalTradicionalSales = TotalTradicionalSales;
            this.TotalRevanchaSales = TotalRevanchaSales;
            this.TotalSiempreSaleSales = TotalSiempreSaleSales;
            CalculatePrizes();
        }

        private void CalculatePrizes()
        {
            TradicionalPrimeraFirstPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.7m;
            TradicionalPrimeraSecondPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.1m;
            TradicionalPrimeraThirdPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.03m;
            TradicionalSegundaFirstPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.7m;
            TradicionalSegundaSecondPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.1m;
            TradicionalSegundaThirdPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.03m;
            RevanchaPrize = TotalRevanchaSales * 0.9m * 0.6m * 0.8m;
            SiempreSalePrize = TotalSiempreSaleSales * 0.9m * 0.6m * 0.6m;
            PozoExtraPrize = (TotalTradicionalSales * 0.5m * 0.4m * 0.163m) + (TotalTradicionalSales * 0.5m * 0.4m * 0.163m) + (TotalRevanchaSales * 0.9m * 0.6m * 0.192m) + (TotalSiempreSaleSales * 0.9m * 0.6m * 0.4m);
        }
    }
}