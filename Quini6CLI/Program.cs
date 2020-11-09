using System.Collections.Generic;

namespace Quini6CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> Players = new List<Player>();
            Player JohnDoe1 = new Player("John Doe1", 18, "Santa Fe", "Rosario", "Belgrano 123", "3414455667", new List<int> { 01, 32, 44, 15, 35, 17 }, Player.GameParticipation.TradicionalOnly);
            Player JohnDoe2 = new Player("John Doe2", 19, "Santa Fe", "Coronda", "Alvear 123", "3424455667", new List<int> { 05, 33, 24, 13, 14, 01 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale);
            Player JohnDoe3 = new Player("John Doe3", 20, "Santa Fe", "Arroyo Seco", "San Lorenzo 123", "3402445566", new List<int> { 09, 35, 47, 13, 22, 26 }, Player.GameParticipation.TradicionalAndRevancha);
            Player JohnDoe4 = new Player("John Doe4", 21, "Santa Fe", "San Lorenzo", "Salta 123", "3414555667", new List<int> { 01, 07, 08, 09, 10, 11 }, Player.GameParticipation.TradicionalAndSiempreSale);
            Player JohnDoe5 = new Player("John Doe5", 22, "Santa Fe", "Villa Gobernador Galvez", "Galvez 123", "3414456667", new List<int> { 01, 02, 03, 05, 10, 20 }, Player.GameParticipation.TradicionalOnly);
            Player JohnDoe6 = new Player("John Doe6", 23, "Santa Fe", "General Lagos", "Juarez Celman 123", "3402455667", new List<int> { 01, 32, 44, 15, 35, 17 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale);
            Players.Add(JohnDoe1);
            Players.Add(JohnDoe2);
            Players.Add(JohnDoe3);
            Players.Add(JohnDoe4);
            Players.Add(JohnDoe5);
            Players.Add(JohnDoe6);
            Quini6Game Q6G = new Quini6Game(Players);
            Q6G.Execute();
        }
    }
}