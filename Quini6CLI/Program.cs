using System.Collections.Generic;
using Quini6CLI.Core;

namespace Quini6CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> Players = new List<Player>();
            Players.Add(new Player("John Doe", 18, "Santa Fe", "Rosario", "Belgrano 123", "3414455667", new List<int> { 01, 32, 44, 15, 35, 17 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Paul Gibson", 19, "Santa Fe", "Coronda", "Alvear 123", "3424455667", new List<int> { 05, 33, 24, 13, 14, 01 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("Jane Doe", 20, "Santa Fe", "Arroyo Seco", "San Lorenzo 123", "3402445566", new List<int> { 09, 35, 41, 13, 22, 26 }, Player.GameParticipation.TradicionalAndRevancha));
            Players.Add(new Player("Janet Tucker", 21, "Santa Fe", "San Lorenzo", "Salta 123", "3414555667", new List<int> { 01, 07, 08, 09, 10, 11 }, Player.GameParticipation.TradicionalAndSiempreSale));
            Players.Add(new Player("John Smith", 22, "Santa Fe", "Villa Gobernador Galvez", "Galvez 123", "3414456667", new List<int> { 01, 02, 03, 05, 10, 20 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Terry Stewart", 23, "Santa Fe", "General Lagos", "Juarez Celman 123", "3402455667", new List<int> { 01, 32, 44, 15, 35, 17 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Quini6Game Q6G = new Quini6Game(Players);
            Q6G.ExecuteQuini6Game();
        }
    }
}