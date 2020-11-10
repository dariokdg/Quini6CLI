using System.Collections.Generic;
using Quini6CLI.Core;

namespace Quini6CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> Players = new List<Player>();
            Players.Add(new Player("Oscar Doe", 18, "Santa Fe", "Rosario", "Belgrano 123", "3414455667", new List<int> { 01, 32, 44, 15, 35, 17 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Paul Gibson", 19, "Santa Fe", "Coronda", "Alvear 123", "3424455667", new List<int> { 05, 33, 24, 13, 14, 01 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("Jane Doe", 20, "Santa Fe", "Arroyo Seco", "San Lorenzo 123", "3402445566", new List<int> { 09, 35, 41, 13, 22, 26 }, Player.GameParticipation.TradicionalAndRevancha));
            Players.Add(new Player("Janet Tucker", 21, "Santa Fe", "San Lorenzo", "Salta 123", "3414555667", new List<int> { 01, 07, 08, 09, 10, 11 }, Player.GameParticipation.TradicionalAndSiempreSale));
            Players.Add(new Player("John Smith", 22, "Santa Fe", "Villa Gobernador Galvez", "Galvez 123", "3414456667", new List<int> { 01, 02, 03, 05, 10, 20 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Terry Stewart", 23, "Santa Fe", "General Lagos", "Juarez Celman 123", "3402455667", new List<int> { 01, 32, 44, 15, 35, 17 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("John Tucker", 18, "Santa Fe", "Rosario", "Belgrano 123", "3414455667", new List<int> { 02, 31, 45, 16, 33, 17 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Paul Stewart", 19, "Santa Fe", "Coronda", "Alvear 123", "3424455667", new List<int> { 03, 30, 20, 10, 11, 02 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("Jane Smith", 20, "Santa Fe", "Arroyo Seco", "San Lorenzo 123", "3402445566", new List<int> { 01, 02, 03, 04, 05, 06 }, Player.GameParticipation.TradicionalAndRevancha));
            Players.Add(new Player("Janet Gibson", 21, "Santa Fe", "San Lorenzo", "Salta 123", "3414555667", new List<int> { 07, 08, 09, 10, 11, 12 }, Player.GameParticipation.TradicionalAndSiempreSale));
            Players.Add(new Player("Thomas Martin", 22, "Santa Fe", "Villa Gobernador Galvez", "Galvez 123", "3414456667", new List<int> { 13, 14, 15, 16, 17, 18 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Terry Doe", 23, "Santa Fe", "General Lagos", "Juarez Celman 123", "3402455667", new List<int> { 19, 20, 21, 22, 23, 24 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("Janet Doe", 18, "Santa Fe", "Rosario", "Belgrano 123", "3414455667", new List<int> { 01, 12, 22, 32, 42, 43 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Terry Gibson", 19, "Santa Fe", "Coronda", "Alvear 123", "3424455667", new List<int> { 05, 06, 15, 12, 13, 44 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("Jane Brown", 20, "Santa Fe", "Arroyo Seco", "San Lorenzo 123", "3402445566", new List<int> { 01, 08, 09, 10, 11, 15 }, Player.GameParticipation.TradicionalAndRevancha));
            Players.Add(new Player("Charlie Tucker", 21, "Santa Fe", "San Lorenzo", "Salta 123", "3414555667", new List<int> { 07, 09, 11, 20, 32, 43 }, Player.GameParticipation.TradicionalAndSiempreSale));
            Players.Add(new Player("John Smith", 22, "Santa Fe", "Villa Gobernador Galvez", "Galvez 123", "3414456667", new List<int> { 01, 02, 06, 05, 19, 29 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Terry Stewart", 23, "Santa Fe", "General Lagos", "Juarez Celman 123", "3402455667", new List<int> { 14, 32, 44, 01, 02, 03 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("John Tucker", 18, "Santa Fe", "Rosario", "Belgrano 123", "3414455667", new List<int> { 03, 30, 04, 40, 02, 20 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Paul Stewart", 19, "Santa Fe", "Coronda", "Alvear 123", "3424455667", new List<int> { 01, 04, 07, 10, 13, 16 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("Jacob Smith", 20, "Santa Fe", "Arroyo Seco", "San Lorenzo 123", "3402445566", new List<int> { 01, 08, 15, 22, 29, 35 }, Player.GameParticipation.TradicionalAndRevancha));
            Players.Add(new Player("Jane Gibson", 21, "Santa Fe", "San Lorenzo", "Salta 123", "3414555667", new List<int> { 06, 38, 29, 10, 11, 12 }, Player.GameParticipation.TradicionalAndSiempreSale));
            Players.Add(new Player("John Gomez", 22, "Santa Fe", "Villa Gobernador Galvez", "Galvez 123", "3414456667", new List<int> { 23, 34, 45, 06, 17, 18 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Paul Williamson", 23, "Santa Fe", "General Lagos", "Juarez Celman 123", "3402455667", new List<int> { 19, 00, 21, 12, 23, 14 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("John Gonzalez", 18, "Santa Fe", "Rosario", "Belgrano 123", "3414455667", new List<int> { 01, 32, 44, 15, 35, 17 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Harry Gibson", 19, "Santa Fe", "Coronda", "Alvear 123", "3424455667", new List<int> { 15, 13, 14, 23, 24, 01 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("Jane Williams", 20, "Santa Fe", "Arroyo Seco", "San Lorenzo 123", "3402445566", new List<int> { 09, 35, 41, 13, 22, 26 }, Player.GameParticipation.TradicionalAndRevancha));
            Players.Add(new Player("Janet Tucker", 21, "Santa Fe", "San Lorenzo", "Salta 123", "3414555667", new List<int> { 05, 09, 28, 29, 40, 11 }, Player.GameParticipation.TradicionalAndSiempreSale));
            Players.Add(new Player("Martha Smith", 22, "Santa Fe", "Villa Gobernador Galvez", "Galvez 123", "3414456667", new List<int> { 01, 02, 03, 05, 10, 20 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Terry O'Connor", 23, "Santa Fe", "General Lagos", "Juarez Celman 123", "3402455667", new List<int> { 02, 32, 24, 45, 00, 01 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("John Tucker", 18, "Santa Fe", "Rosario", "Belgrano 123", "3414455667", new List<int> { 00, 11, 44, 33, 22, 01 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("George Stewart", 19, "Santa Fe", "Coronda", "Alvear 123", "3424455667", new List<int> { 04, 40, 20, 10, 00, 09 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Players.Add(new Player("Jane Jones", 20, "Santa Fe", "Arroyo Seco", "San Lorenzo 123", "3402445566", new List<int> { 03, 04, 09, 14, 25, 36 }, Player.GameParticipation.TradicionalAndRevancha));
            Players.Add(new Player("Janet Gibson", 21, "Santa Fe", "San Lorenzo", "Salta 123", "3414555667", new List<int> { 37, 38, 39, 40, 01, 12 }, Player.GameParticipation.TradicionalAndSiempreSale));
            Players.Add(new Player("John Garcia", 22, "Santa Fe", "Villa Gobernador Galvez", "Galvez 123", "3414456667", new List<int> { 13, 24, 35, 06, 17, 18 }, Player.GameParticipation.TradicionalOnly));
            Players.Add(new Player("Terry Davis", 23, "Santa Fe", "General Lagos", "Juarez Celman 123", "3402455667", new List<int> { 09, 30, 31, 32, 13, 44 }, Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale));
            Quini6Game Q6G = new Quini6Game(Players);
            Q6G.ExecuteQuini6Game();
        }
    }
}