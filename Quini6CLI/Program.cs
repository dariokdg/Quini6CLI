using System;
using System.Collections.Generic;
using System.Diagnostics;
using Quini6CLI.Core;
using Quini6CLI.Generators;
using Quini6CLI.Winners;

namespace Quini6CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                string TestFirstArgument = args[0];
                bool IsFirstArgumentANumber = long.TryParse(TestFirstArgument, out long TestFirstNumber);
                if (IsFirstArgumentANumber && (args.Length == 1 || args.Length == 2))
                {
                    List<Player> Players = new RandomPlayerGenerator().GenerateListOfRandomPlayers(TestFirstNumber);
                    Quini6Game Q6G = new Quini6Game(Players);
                    if (args.Length == 2 && !string.IsNullOrWhiteSpace(args[1]) && args[1].ToLower() == "--jackpot")
                    {
                        Quini6Winners Q6W = Q6G.ExecuteQuini6Game();
                        TestMultipleQuini6Games(Q6G, Q6W);
                    }
                    else
                    {
                        Q6G.ExecuteQuini6Game();
                    }
                }
                else
                {
                    PrintErrorAndUsageMessage();
                }
            }
            else
            {
                List<Player> Players = new RandomPlayerGenerator().GenerateListOfRandomPlayers(1);
                Quini6Game Q6G = new Quini6Game(Players);
                Q6G.ExecuteQuini6Game();
            }
        }

        private static void TestMultipleQuini6Games(Quini6Game Q6G, Quini6Winners Q6W)
        {
            Stopwatch SW = new Stopwatch();
            SW.Start();
            int Counter = 0;
            while (Q6W.TPFPW.PrizeWinnerList.Count == 0 && Q6W.TSFPW.PrizeWinnerList.Count == 0 && Q6W.RW.PrizeWinnerList.Count == 0)
            {
                Counter++;
                Q6W = Q6G.ExecuteQuini6Game();
                if (Q6W.TPFPW.PrizeWinnerList.Count == 0 && Q6W.TSFPW.PrizeWinnerList.Count == 0 && Q6W.RW.PrizeWinnerList.Count == 0)
                {
                    Console.Clear();
                }
            }
            SW.Stop();
            Console.WriteLine($"NUMBER OF GAMES PLAYED: {Counter} | TIME ELAPSED: {SW.Elapsed}");
        }

        private static void PrintErrorAndUsageMessage()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("ERROR WHILE TRYING TO EXECUTE Quini6CLI: INVALID PARAMETER(S)");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Quini6CLI USAGE: Quini6CLI.exe [NUMBER OF PLAYERS AS INTEGER (OPTIONAL)] [ITERATE UNTIL JACKPOT COMMAND '--jackpot' (OPTIONAL)]");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("NUMBER OF PLAYERS: OPTIONAL PARAMETER");
            Console.WriteLine("    DETERMINE HOW MANY RANDOM-GENERATED PLAYERS THERE WILL BE IN THE QUINI 6 GAME BEING EXECUTED");
            Console.WriteLine("    IF THIS IS NOT PROVIDED THERE WILL ONLY BE ONE PLAYER ");
            Console.WriteLine("ITERATE UNTIL JACKPOT: OPTIONAL PARAMETER");
            Console.WriteLine("    DETERMINE IF THE GAME SHOULD BE EXECUTED REPEATEDLY UNTIL THERE IS A JACKPOT (A.K.A. FIRST PRIZE) WINNER");
            Console.WriteLine("    IF THIS IS NOT PROVIDED THE GAME WILL ONLY RUN ONCE");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(">> EXAMPLES:");
            Console.WriteLine(">>   Quini6CLI.exe 1000 --jackpot");
            Console.WriteLine(">>   Quini6CLI.exe 300000");
            Console.WriteLine(">>   Quini6CLI.exe");
            Console.WriteLine(">>   Quini6CLI.exe 25 --jackpot");
            Console.WriteLine("-------------------------------------------------------------");
        }
    }
}