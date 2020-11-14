using System;
using System.Collections.Generic;
using System.Diagnostics;
using Quini6CLI.Core;
using Quini6CLI.Generators;
using Quini6CLI.Winners;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args != null && args.Length > 0 && args.Length <= 3)
                {
                    List<Player> Players = null;
                    Quini6Game Q6G = null;
                    Quini6Winners Q6W = null;
                    List<string> ListOfArgs = new List<string>();
                    ListOfArgs.AddRange(args);
                    bool Jackpot = ListOfArgs.Contains("--jackpot");
                    bool Custom = ListOfArgs.Contains("--custom");

                    if (args.Length == 1)
                    {
                        string TestFirstArgument = args[0];
                        bool IsFirstArgumentANumber = long.TryParse(TestFirstArgument, out long NumberOfPlayersToGenerateFirstArg);
                        if (IsFirstArgumentANumber)
                        {
                            Players = new RandomPlayerGenerator().GenerateListOfRandomPlayers(NumberOfPlayersToGenerateFirstArg);
                        }
                        else if (Custom)
                        {
                            Players = CreateCustomPlayer();
                        }
                        else if (Jackpot)
                        {
                            Players = new RandomPlayerGenerator().GenerateListOfRandomPlayers(1);
                        }
                        else
                        {
                            PrintErrorAndUsageMessage();
                        }
                        Q6G = new Quini6Game(Players);
                        Q6W = Q6G.ExecuteQuini6Game(); 
                        if (Jackpot)
                        {
                            TestMultipleQuini6Games(Q6G, Q6W);
                        }
                    }
                    else if (args.Length == 2)
                    {
                        string TestFirstArgument = args[0];
                        bool IsFirstArgumentANumber = long.TryParse(TestFirstArgument, out long NumberOfPlayersToGenerateFirstArg);
                        string TestSecondArgument = args[1];
                        bool IsSecondArgumentANumber = long.TryParse(TestSecondArgument, out long NumberOfPlayersToGenerateSecondArg);
                        if ((IsFirstArgumentANumber && Custom) || (Custom && IsSecondArgumentANumber))
                        {
                            Players.AddRange(CreateCustomPlayer());
                            if (IsFirstArgumentANumber)
                            {
                                Players.AddRange(new RandomPlayerGenerator().GenerateListOfRandomPlayers(NumberOfPlayersToGenerateFirstArg));
                            }
                            else if (IsSecondArgumentANumber)
                            {
                                Players.AddRange(new RandomPlayerGenerator().GenerateListOfRandomPlayers(NumberOfPlayersToGenerateSecondArg));
                            }
                        }
                        else if ((IsFirstArgumentANumber && Jackpot) || (Jackpot && IsSecondArgumentANumber))
                        {
                            if (IsFirstArgumentANumber)
                            {
                                Players = new RandomPlayerGenerator().GenerateListOfRandomPlayers(NumberOfPlayersToGenerateFirstArg);
                            }
                            else if (IsSecondArgumentANumber)
                            {
                                Players = new RandomPlayerGenerator().GenerateListOfRandomPlayers(NumberOfPlayersToGenerateSecondArg);
                            }
                        }
                        else if (Jackpot && Custom)
                        {
                            Players = CreateCustomPlayer();
                        }
                        else
                        {
                            PrintErrorAndUsageMessage();
                        }
                        Q6G = new Quini6Game(Players);
                        Q6W = Q6G.ExecuteQuini6Game();
                        if (Jackpot)
                        {
                            TestMultipleQuini6Games(Q6G, Q6W);
                        }
                    }
                    else if (args.Length == 3)
                    {
                        string TestFirstArgument = args[0];
                        bool IsFirstArgumentANumber = long.TryParse(TestFirstArgument, out long NumberOfPlayersToGenerateFirstArg);
                        string TestSecondArgument = args[1];
                        bool IsSecondArgumentANumber = long.TryParse(TestSecondArgument, out long NumberOfPlayersToGenerateSecondArg);
                        string TestThirdArgument = args[2];
                        bool IsThirdArgumentANumber = long.TryParse(TestThirdArgument, out long NumberOfPlayersToGenerateThirdArg);
                        if (Custom && Jackpot && IsFirstArgumentANumber)
                        {
                            Players = CreateCustomPlayer();
                            Players.AddRange(new RandomPlayerGenerator().GenerateListOfRandomPlayers(NumberOfPlayersToGenerateFirstArg));
                        }
                        else if (Custom && Jackpot && IsSecondArgumentANumber)
                        {
                            Players = CreateCustomPlayer();
                            Players.AddRange(new RandomPlayerGenerator().GenerateListOfRandomPlayers(NumberOfPlayersToGenerateSecondArg));
                        }
                        else if (Custom && Jackpot && IsThirdArgumentANumber)
                        {
                            Players = CreateCustomPlayer();
                            Players.AddRange(new RandomPlayerGenerator().GenerateListOfRandomPlayers(NumberOfPlayersToGenerateThirdArg));
                        }
                        else
                        {
                            PrintErrorAndUsageMessage();
                        }
                        Q6G = new Quini6Game(Players);
                        Q6W = Q6G.ExecuteQuini6Game();
                        TestMultipleQuini6Games(Q6G, Q6W);
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
            catch (Exception ex)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("ERROR FOUND WHILE EXECUTING Quini6CLI.exe:");
                Console.WriteLine("EXCEPTION DETAILS:");
                Console.WriteLine($"    >>> {ex.Message}");
                PrintErrorAndUsageMessage();
            }
            finally
            {
                PrintProgramFinishedMessage();
            }
        }

        private static List<Player> CreateCustomPlayer()
        {
            Console.WriteLine("ENTER USER'S NAME AND LAST NAME:");
            string UserName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(UserName))
            {
                throw new ArgumentException("USER'S NAME MUST NOT BE EMPTY!");
            }

            Console.WriteLine("ENTER USER'S AGE (MUST BE OVER 18):");
            string Age = Console.ReadLine();
            bool IsAgeArgumentANumber = int.TryParse(Age, out int UserAge);
            if (!IsAgeArgumentANumber || (IsAgeArgumentANumber && UserAge < 18))
            {
                throw new ArgumentException("USER'S AGE MUST BE A NUMBER (AND THAT NUMBER MUST BE OVER 18)!");
            }

            Console.WriteLine("ENTER USER'S CITY OF RESIDENCE:");
            string UserCity = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(UserCity))
            {
                throw new ArgumentException("USER'S CITY MUST NOT BE EMPTY!");
            }

            Console.WriteLine("ENTER USER'S ADDRESS:");
            string UserAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(UserAddress))
            {
                throw new ArgumentException("USER'S ADDRESS MUST NOT BE EMPTY!");
            }

            Console.WriteLine("ENTER USER'S PHONE NUMBER:");
            string PhoneNumber = Console.ReadLine();
            bool IsPhoneNumberArgumentANumber = long.TryParse(PhoneNumber, out long UserPhoneNumber);
            if (!IsPhoneNumberArgumentANumber || (IsPhoneNumberArgumentANumber && PhoneNumber.Length != 10))
            {
                throw new ArgumentException("USER'S PHONE NUMBER MUST BE A NUMBER (AND THAT NUMBER NEEDS TO HAVE ALL 10 DIGITS)!");
            }

            Console.WriteLine("DEFINE GAMES THE USER WILL BE PLAYING:");
            Console.WriteLine("    >> ENTER 1 FOR 'Tradicional only'");
            Console.WriteLine("    >> ENTER 2 FOR 'Tradicional' + 'Revancha'");
            Console.WriteLine("    >> ENTER 3 FOR 'Tradicional' + 'Revancha' + 'Siempre Sale'");
            string SelectedGameType = Console.ReadLine();
            bool IsSelectedGameTypeArgumentANumber = int.TryParse(SelectedGameType, out int UserGameType);
            GameParticipation UserGP = GameParticipation.TradicionalOnly;
            if (!IsSelectedGameTypeArgumentANumber || (IsSelectedGameTypeArgumentANumber && (UserGameType > 3 || UserGameType < 1)))
            {
                throw new ArgumentException("USER'S GAME OF CHOICE MUST BE SELECTED WITH NUMBERS 1, 2 OR 3!");
            }
            else
            {
                if (UserGameType == 1)
                {
                    UserGP = GameParticipation.TradicionalOnly;
                }
                else if (UserGameType == 2)
                {
                    UserGP = GameParticipation.TradicionalAndRevancha;
                }
                else if (UserGameType == 3)
                {
                    UserGP = GameParticipation.TradicionalAndRevanchaAndSiempreSale;
                }
            }


            Console.WriteLine("DEFINE THE 6 NUMBERS THE USER WILL HAVE IN THEIR TICKET (FROM 00 TO 45):");
            Console.WriteLine("DEFINE THE FIRST NUMBER:");
            string TestFirstNumberArgument = Console.ReadLine();
            bool IsFirstNumberArgumentANumber = int.TryParse(TestFirstNumberArgument, out int TestFirstNumber);

            Console.WriteLine("DEFINE THE SECOND NUMBER:");
            string TestSecondNumberArgument = Console.ReadLine();
            bool IsSecondNumberArgumentANumber = int.TryParse(TestSecondNumberArgument, out int TestSecondNumber);

            Console.WriteLine("DEFINE THE THIRD NUMBER:");
            string TestThirdNumberArgument = Console.ReadLine();
            bool IsThirdNumberArgumentANumber = int.TryParse(TestThirdNumberArgument, out int TestThirdNumber);

            Console.WriteLine("DEFINE THE FOURTH NUMBER:");
            string TestFourthNumberArgument = Console.ReadLine();
            bool IsFourthNumberArgumentANumber = int.TryParse(TestFourthNumberArgument, out int TestFourthNumber);

            Console.WriteLine("DEFINE THE FIFTH NUMBER:");
            string TestFifthNumberArgument = Console.ReadLine();
            bool IsFifthNumberArgumentANumber = int.TryParse(TestFifthNumberArgument, out int TestFifthNumber);

            Console.WriteLine("DEFINE THE SIXTH NUMBER:");
            string TestSixthNumberArgument = Console.ReadLine();
            bool IsSixthNumberArgumentANumber = int.TryParse(TestSixthNumberArgument, out int TestSixthNumber);

            if (
                IsFirstNumberArgumentANumber && (TestFirstNumber >= 00 && TestFirstNumber <= 45) &&
                IsSecondNumberArgumentANumber && (TestSecondNumber >= 00 && TestSecondNumber <= 45) &&
                IsThirdNumberArgumentANumber && (TestThirdNumber >= 00 && TestThirdNumber <= 45) &&
                IsFourthNumberArgumentANumber && (TestFourthNumber >= 00 && TestFourthNumber <= 45) &&
                IsFifthNumberArgumentANumber && (TestFifthNumber >= 00 && TestFifthNumber <= 45) &&
                IsSixthNumberArgumentANumber && (TestSixthNumber >= 00 && TestSixthNumber <= 45)
                )
            {
                List<Player> UserGeneratedPlayers = new List<Player>
                {
                    new Player
                    (
                        UserName,
                        UserAge,
                        UserCity,
                        UserAddress,
                        UserPhoneNumber.ToString(),
                        new Ticket
                        (
                            new List<int>
                            {
                                TestFirstNumber,
                                TestSecondNumber,
                                TestThirdNumber,
                                TestFourthNumber,
                                TestFifthNumber,
                                TestSixthNumber
                            },
                            UserGP
                        )
                    )
                };
                return UserGeneratedPlayers;
            }
            else
            {
                throw new ArgumentException("USER'S GAME NUMBERS MUST BE 6 DIFFERENT NUMBERS RANGING FROM 00 TO 45!");
            }
        }

        private static void TestMultipleQuini6Games(Quini6Game Q6G, Quini6Winners Q6W)
        {
            Stopwatch SW = new Stopwatch();
            SW.Start();
            int Counter = 1;
            while (Q6W.TPFPW.PrizeWinnerList.Count == 0 && Q6W.TSFPW.PrizeWinnerList.Count == 0 && Q6W.RW.PrizeWinnerList.Count == 0)
            {
                Counter++;
                Console.Clear();
                Q6W = Q6G.ExecuteQuini6Game();
            }
            SW.Stop();
            Console.WriteLine("\n\n\n--------------------------------------------");
            Console.WriteLine($"NUMBER OF GAMES PLAYED: {Counter} | TIME ELAPSED: {SW.Elapsed}");
            Console.WriteLine("--------------------------------------------");
        }

        private static void PrintErrorAndUsageMessage()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("ERROR WHILE TRYING TO EXECUTE Quini6CLI: INVALID PARAMETER(S)");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Quini6CLI USAGE:");
            Console.WriteLine("Quini6CLI.exe [NUMBER OF PLAYERS AS INTEGER (OPTIONAL)] [ITERATE UNTIL JACKPOT COMMAND '--jackpot' (OPTIONAL)] [CREATE CUSTOM PLAYER COMMAND '--custom' (OPTIONAL)]");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("NOTE ON PARAMETERS: THE THREE PARAMETERS CAN BE USED IN ANY ORDER");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("NUMBER OF PLAYERS: OPTIONAL PARAMETER");
            Console.WriteLine("    DETERMINE HOW MANY RANDOM-GENERATED PLAYERS THERE WILL BE IN THE QUINI 6 GAME BEING EXECUTED");
            Console.WriteLine("    IF THIS IS NOT PROVIDED THERE WILL ONLY BE ONE PLAYER ");
            Console.WriteLine("ITERATE UNTIL JACKPOT: OPTIONAL PARAMETER");
            Console.WriteLine("    DETERMINE IF THE GAME SHOULD BE EXECUTED REPEATEDLY UNTIL THERE IS A JACKPOT (A.K.A. FIRST PRIZE) WINNER");
            Console.WriteLine("    IF THIS IS NOT PROVIDED THE GAME WILL ONLY RUN ONCE");
            Console.WriteLine("CREATE CUSTOM PLAYER: OPTIONAL PARAMETER");
            Console.WriteLine("    ASK THE USER TO INPUT THE DATA NECESSARY FOR THE CREATION OF A SINGLE PLAYER");
            Console.WriteLine("    IF THIS IS NOT PROVIDED THE GAME WILL ONLY RUN WITH RANDOM-GENERATED PLAYERS");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine(">> EXAMPLES:");
            Console.WriteLine(">>   Quini6CLI.exe 1000 --jackpot");
            Console.WriteLine(">>   Quini6CLI.exe 300000");
            Console.WriteLine(">>   Quini6CLI.exe --custom --jackpot");
            Console.WriteLine(">>   Quini6CLI.exe");
            Console.WriteLine(">>   Quini6CLI.exe 25 --jackpot");
            Console.WriteLine(">>   Quini6CLI.exe --custom");
            Console.WriteLine(">>   Quini6CLI.exe --custom 40000");
            Console.WriteLine(">>   Quini6CLI.exe --jackpot --custom 750000");
            Console.WriteLine("-------------------------------------------------------------");
        }

        private static void PrintProgramFinishedMessage()
        {
            Console.WriteLine("\n\n\n--------------------------------------------");
            Console.WriteLine("PROGRAM FINISHED - PRESS ANY KEY TO EXIT");
            Console.WriteLine("--------------------------------------------");
            Console.ReadKey();
        }
    }
}