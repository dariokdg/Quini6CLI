using Quini6CLI.Generators;
using System.Collections.Generic;
using System.Linq;

namespace Quini6CLI
{
    class Quini6Game
    {
        private List<Player> Players { get; set; }

        public Quini6Game(List<Player> Players)
        {
            this.Players = Players;
        }

        public void Execute()
        {
            ResultGenerator Quini6ResultGenerator = new ResultGenerator();
            List<int> TradicionalPrimeraNumbers = Quini6ResultGenerator.GetQuini6Results();
            List<int> TradicionalSegundaNumbers = Quini6ResultGenerator.GetQuini6Results();
            List<int> RevanchaNumbers = Quini6ResultGenerator.GetQuini6Results();
            List<int> SiempreSaleNumbers = Quini6ResultGenerator.GetQuini6Results();
            List<int> PozoExtraNumbers = TradicionalPrimeraNumbers.Concat(TradicionalSegundaNumbers).Concat(RevanchaNumbers).ToList().Distinct().ToList();

        }
    }
}