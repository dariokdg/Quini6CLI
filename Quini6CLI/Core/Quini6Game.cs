using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleTables;
using Quini6CLI.Helpers;
using Quini6CLI.Winners;
using Quini6CLI.Checkers;
using Quini6CLI.Generators;
using Quini6CLI.Interfaces;
using System.Threading;

namespace Quini6CLI.Core
{
    class Quini6Game
    {
        private List<Player> Players { get; set; }

        public Quini6Game(List<Player> Players)
        {
            this.Players = Players;
        }

        public Quini6Winners ExecuteQuini6Game()
        {
            PrintProgramStartup();

            TotalSales TS = CalculateTotalSells();
            PrintTotalSales(TS);

            PrizeGenerator PG = GetPrizes(TS);
            PrintPrizes(PG);

            GameResults Drawings = ExecuteDrawings();
            PrintDrawingResults(Drawings);

            Quini6Winners Q6W = CalculateWinners(Drawings, PG);
            PrintWinners(Q6W, PG);

            return Q6W;
        }

        #region --- Base flow functions ---
        private TotalSales CalculateTotalSells()
        {
            decimal TotalTradicionalSales = 0;
            int TotalTradicionalPlayers = 0;
            decimal TotalRevanchaSales = 0;
            int TotalRevanchaPlayers = 0;
            decimal TotalSiempreSaleSales = 0;
            int TotalSiempreSalePlayers = 0;
            foreach (Player Quini6Player in Players)
            {
                GameSpends GS = Quini6Player.CheckSpends();
                TotalTradicionalSales += GS.TradicionalSpends;
                TotalRevanchaSales += GS.RevanchaSpends;
                TotalSiempreSaleSales += GS.SiempreSaleSpends;
                if (GS.SiempreSaleSpends > 0)
                {
                    TotalSiempreSalePlayers++;
                }
                else if (GS.RevanchaSpends > 0)
                {
                    TotalRevanchaPlayers++;
                }
                else
                {
                    TotalTradicionalPlayers++;
                }
            }
            TotalSales TS = new TotalSales(TotalTradicionalSales, TotalTradicionalPlayers, TotalRevanchaSales, TotalRevanchaPlayers, TotalSiempreSaleSales, TotalSiempreSalePlayers);
            return TS;
        }

        private static PrizeGenerator GetPrizes(TotalSales TS)
        { 
            return new PrizeGenerator(TS.TotalTradicionalSales, TS.TotalRevanchaSales, TS.TotalSiempreSaleSales);
        }

        private GameResults ExecuteDrawings()
        {
            return new GameResultGenerator(Players, new DrawingResultGenerator()).GetGameResults();
        }

        private Quini6Winners CalculateWinners(GameResults Drawings, PrizeGenerator PG)
        {
            GameTypeResult GTRTP = Drawings.GTRTP;
            PrizeCheckerTradicionalPrimeraFirstPrize PCTPFP = new PrizeCheckerTradicionalPrimeraFirstPrize(GTRTP, PG.TradicionalPrimeraFirstPrize);
            IWinner TPFPW = PCTPFP.CheckPrizes();

            PrizeCheckerTradicionalPrimeraSecondPrize PCTPSP = new PrizeCheckerTradicionalPrimeraSecondPrize(GTRTP, PG.TradicionalPrimeraSecondPrize);
            IWinner TPSPW = PCTPSP.CheckPrizes();

            PrizeCheckerTradicionalPrimeraThirdPrize PCTPTP = new PrizeCheckerTradicionalPrimeraThirdPrize(GTRTP, PG.TradicionalPrimeraThirdPrize);
            IWinner TPTPW = PCTPTP.CheckPrizes();


            GameTypeResult GTRTS = Drawings.GTRTS;
            PrizeCheckerTradicionalSegundaFirstPrize PCTSFP = new PrizeCheckerTradicionalSegundaFirstPrize(GTRTS, PG.TradicionalSegundaFirstPrize);
            IWinner TSFPW = PCTSFP.CheckPrizes();

            PrizeCheckerTradicionalSegundaSecondPrize PCTSSP = new PrizeCheckerTradicionalSegundaSecondPrize(GTRTS, PG.TradicionalSegundaSecondPrize);
            IWinner TSSPW = PCTSSP.CheckPrizes();

            PrizeCheckerTradicionalSegundaThirdPrize PCTSTP = new PrizeCheckerTradicionalSegundaThirdPrize(GTRTS, PG.TradicionalSegundaThirdPrize);
            IWinner TSTPW = PCTSTP.CheckPrizes();


            GameTypeResult GTRR = Drawings.GTRR;
            PrizeCheckerRevancha PCR = new PrizeCheckerRevancha(GTRR, PG.RevanchaPrize);
            IWinner RW = PCR.CheckPrizes();


            GameTypeResult GTRSS = Drawings.GTRSS;
            PrizeCheckerSiempreSale PCSS = new PrizeCheckerSiempreSale(GTRSS, PG.SiempreSalePrize);
            IWinner SSW = PCSS.CheckPrizes();


            GameTypeResult GTRPE = Drawings.GTRPE;
            PrizeCheckerPozoExtra PCPE = new PrizeCheckerPozoExtra(GTRPE, PG.PozoExtraPrize, TPFPW, TSFPW, RW);
            IWinner PEW = PCPE.CheckPrizes();


            Quini6Winners Q6W = new Quini6Winners(TPFPW, TPSPW, TPTPW, TSFPW, TSSPW, TSTPW, RW, SSW, PEW);

            return Q6W;
        }
        #endregion

        #region --- Console print section ---
        private static void PrintProgramStartup()
        {
            PrintGameStartMessage();
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"QUINI 6 GAME STARTED: {DateTime.Now}");
            Console.WriteLine("--------------------------------------------");
        }

        private static void PrintTotalSales(TotalSales TS)
        {
            Console.WriteLine("\n\n\n--------------------------------------------");
            Console.WriteLine($"TOTAL NUMBER OF PLAYERS: {TS.GetTotalGamePlayers()}");
            Console.WriteLine($"    > TRADICIONAL PLAYERS: {TS.TotalTradicionalPlayers}");
            Console.WriteLine($"    > REVANCHA PLAYERS: {TS.TotalRevanchaPlayers}");
            Console.WriteLine($"    > SIEMPRE SALE PLAYERS: {TS.TotalSiempreSalePlayers}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("\n\n\n--------------------------------------------");
            Console.WriteLine($"TOTAL SALES: {TS.GetTotalGameSales():c2}");
            Console.WriteLine($"    > TRADICIONAL SALES: {TS.TotalTradicionalSales:c2}");
            Console.WriteLine($"    > REVANCHA SALES: {TS.TotalRevanchaSales:c2}");
            Console.WriteLine($"    > SIEMPRE SALE SALES: {TS.TotalSiempreSaleSales:c2}");
            Console.WriteLine("--------------------------------------------");
        }

        private static void PrintPrizes(PrizeGenerator PG)
        {
            Console.WriteLine("\n\n\n--------------------------------------------");
            Console.WriteLine("QUINI 6 PRIZE LIST:");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");

            ConsoleTable Results = new ConsoleTable("GAME TYPE", "PRIZE CATEGORY", "NUMBER OF HITS", "TOTAL PRIZE");
            Results.AddRow("TRADICIONAL PRIMERA", "FIRST PRIZE", "6", PG.TradicionalPrimeraFirstPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL PRIMERA", "SECOND PRIZE", "5", PG.TradicionalPrimeraSecondPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL PRIMERA", "THIRD PRIZE", "4", PG.TradicionalPrimeraThirdPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "FIRST PRIZE", "6", PG.TradicionalSegundaFirstPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "SECOND PRIZE", "5", PG.TradicionalSegundaSecondPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "THIRD PRIZE", "4", PG.TradicionalSegundaThirdPrize.ToString("c2"));
            Results.AddRow("REVANCHA", "MAIN PRIZE", "6", PG.RevanchaPrize.ToString("c2"));
            Results.AddRow("SIEMPRE SALE", "MAIN PRIZE", "6/5/4/3/2/1", PG.SiempreSalePrize.ToString("c2"));
            Results.AddRow("POZO EXTRA", "MAIN PRIZE", "6", PG.PozoExtraPrize.ToString("c2"));
            Results.Write(Format.Alternative);
        }

        private static void PrintDrawingResults(GameResults DrawingResults)
        {
            GameTypeResult GTRTP = DrawingResults.GTRTP;
            GameTypeResult GTRTS = DrawingResults.GTRTS;
            GameTypeResult GTRR = DrawingResults.GTRR;
            GameTypeResult GTRSS = DrawingResults.GTRSS;
            GameTypeResult GTRPE = DrawingResults.GTRPE;

            Console.WriteLine("\n\n--------------------------------------------");
            Console.WriteLine($"QUINI 6 DRAWINGS:");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");
            ConsoleTable Results = new ConsoleTable("GAME TYPE", "FIRST NUMBER", "SECOND NUMBER", "THIRD NUMBER", "FOURTH NUMBER", "FIFTH NUMBER", "SIXTH NUMBER");
            Results.AddRow("TRADICIONAL PRIMERA", GTRTP.DrawingResults[0].ToString("D2"), GTRTP.DrawingResults[1].ToString("D2"), GTRTP.DrawingResults[2].ToString("D2"), GTRTP.DrawingResults[3].ToString("D2"), GTRTP.DrawingResults[4].ToString("D2"), GTRTP.DrawingResults[5].ToString("D2"));
            Results.AddRow("TRADICIONAL SEGUNDA", GTRTS.DrawingResults[0].ToString("D2"), GTRTS.DrawingResults[1].ToString("D2"), GTRTS.DrawingResults[2].ToString("D2"), GTRTS.DrawingResults[3].ToString("D2"), GTRTS.DrawingResults[4].ToString("D2"), GTRTS.DrawingResults[5].ToString("D2"));
            Results.AddRow("REVANCHA", GTRR.DrawingResults[0].ToString("D2"), GTRR.DrawingResults[1].ToString("D2"), GTRR.DrawingResults[2].ToString("D2"), GTRR.DrawingResults[3].ToString("D2"), GTRR.DrawingResults[4].ToString("D2"), GTRR.DrawingResults[5].ToString("D2"));
            Results.AddRow("SIEMPRE SALE", GTRSS.DrawingResults[0].ToString("D2"), GTRSS.DrawingResults[1].ToString("D2"), GTRSS.DrawingResults[2].ToString("D2"), GTRSS.DrawingResults[3].ToString("D2"), GTRSS.DrawingResults[4].ToString("D2"), GTRSS.DrawingResults[5].ToString("D2"));
            Results.Write(Format.Alternative);

            Console.WriteLine("");
            Console.WriteLine($"POZO EXTRA:");
            List<int> Numbers = GTRPE.DrawingResults;
            string Number01 = Numbers.Count() >= 01 ? Numbers[00].ToString("D2") : " ";
            string Number02 = Numbers.Count() >= 02 ? Numbers[01].ToString("D2") : " ";
            string Number03 = Numbers.Count() >= 03 ? Numbers[02].ToString("D2") : " ";
            string Number04 = Numbers.Count() >= 04 ? Numbers[03].ToString("D2") : " ";
            string Number05 = Numbers.Count() >= 05 ? Numbers[04].ToString("D2") : " ";
            string Number06 = Numbers.Count() >= 06 ? Numbers[05].ToString("D2") : " ";
            string Number07 = Numbers.Count() >= 07 ? Numbers[06].ToString("D2") : " ";
            string Number08 = Numbers.Count() >= 08 ? Numbers[07].ToString("D2") : " ";
            string Number09 = Numbers.Count() >= 09 ? Numbers[08].ToString("D2") : " ";
            string Number10 = Numbers.Count() >= 10 ? Numbers[09].ToString("D2") : " ";
            string Number11 = Numbers.Count() >= 11 ? Numbers[10].ToString("D2") : " ";
            string Number12 = Numbers.Count() >= 12 ? Numbers[11].ToString("D2") : " ";
            string Number13 = Numbers.Count() >= 13 ? Numbers[12].ToString("D2") : " ";
            string Number14 = Numbers.Count() >= 14 ? Numbers[13].ToString("D2") : " ";
            string Number15 = Numbers.Count() >= 15 ? Numbers[14].ToString("D2") : " ";
            string Number16 = Numbers.Count() >= 16 ? Numbers[15].ToString("D2") : " ";
            string Number17 = Numbers.Count() >= 17 ? Numbers[16].ToString("D2") : " ";
            string Number18 = Numbers.Count() == 18 ? Numbers[17].ToString("D2") : " ";
            ConsoleTable PozoExtraResults = new ConsoleTable(Number01, Number02, Number03, Number04, Number05, Number06);
            if (!string.IsNullOrWhiteSpace(Number07))
            {
                PozoExtraResults.AddRow(Number07, Number08, Number09, Number10, Number11, Number12);
                if (!string.IsNullOrWhiteSpace(Number13))
                {
                    PozoExtraResults.AddRow(Number13, Number14, Number15, Number16, Number17, Number18);
                }
            }
            PozoExtraResults.Write(Format.Alternative);
        }

        private static void PrintWinners(Quini6Winners Q6W, PrizeGenerator PG)
        {
            TradicionalPrimeraFirstPrizeWinners TPFPW = (TradicionalPrimeraFirstPrizeWinners)Q6W.TPFPW;
            TradicionalPrimeraSecondPrizeWinners TPSPW = (TradicionalPrimeraSecondPrizeWinners)Q6W.TPSPW;
            TradicionalPrimeraThirdPrizeWinners TPTPW = (TradicionalPrimeraThirdPrizeWinners)Q6W.TPTPW;
            TradicionalSegundaFirstPrizeWinners TSFPW = (TradicionalSegundaFirstPrizeWinners)Q6W.TSFPW;
            TradicionalSegundaSecondPrizeWinners TSSPW = (TradicionalSegundaSecondPrizeWinners)Q6W.TSSPW;
            TradicionalSegundaThirdPrizeWinners TSTPW = (TradicionalSegundaThirdPrizeWinners)Q6W.TSTPW;
            RevanchaWinners RW = (RevanchaWinners)Q6W.RW;
            SiempreSaleWinners SSW = (SiempreSaleWinners)Q6W.SSW;
            PozoExtraWinners PEW = (PozoExtraWinners)Q6W.PEW;

            Console.WriteLine("\n\n--------------------------------------------");
            Console.WriteLine($"QUINI 6 RESULTS:");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");

            ConsoleTable Results = new ConsoleTable("GAME TYPE", "PRIZE CATEGORY", "TOTAL PRIZE AMOUNT", "NUMBER OF WINNERS", "NUMBER OF HITS", "PRIZE FOR EACH WINNER");
            Results.AddRow("TRADICIONAL PRIMERA", "FIRST PRIZE", PG.TradicionalPrimeraFirstPrize.ToString("c2"), TPFPW.PrizeWinnerList.Count, "6", TPFPW.PrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL PRIMERA", "SECOND PRIZE", PG.TradicionalPrimeraSecondPrize.ToString("c2"), TPSPW.PrizeWinnerList.Count, "5", TPSPW.PrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL PRIMERA", "THIRD PRIZE", PG.TradicionalPrimeraThirdPrize.ToString("c2"), TPTPW.PrizeWinnerList.Count, "4", TPTPW.PrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "FIRST PRIZE", PG.TradicionalSegundaFirstPrize.ToString("c2"), TSFPW.PrizeWinnerList.Count, "6", TSFPW.PrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "SECOND PRIZE", PG.TradicionalSegundaSecondPrize.ToString("c2"), TSSPW.PrizeWinnerList.Count, "5", TSSPW.PrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "THIRD PRIZE", PG.TradicionalSegundaThirdPrize.ToString("c2"), TSTPW.PrizeWinnerList.Count, "4", TSTPW.PrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("REVANCHA", "MAIN PRIZE", PG.RevanchaPrize.ToString("c2"), RW.PrizeWinnerList.Count, "6", RW.PrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("SIEMPRE SALE", "MAIN PRIZE", PG.SiempreSalePrize.ToString("c2"), SSW.PrizeWinnerList.Count, SSW.SiempreSaleWinnersNumberofMatches, SSW.PrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("POZO EXTRA", "MAIN PRIZE", PG.PozoExtraPrize.ToString("c2"), PEW.PrizeWinnerList.Count, "6", PEW.PrizeAmountPerWinner.ToString("c2"));
            Results.Write(Format.Alternative);

            if (TPFPW.PrizeWinnerList.Count == 0 &&
                TPSPW.PrizeWinnerList.Count == 0 &&
                TPTPW.PrizeWinnerList.Count == 0 &&
                TSFPW.PrizeWinnerList.Count == 0 &&
                TSSPW.PrizeWinnerList.Count == 0 &&
                TSTPW.PrizeWinnerList.Count == 0 &&
                RW.PrizeWinnerList.Count == 0 &&
                SSW.PrizeWinnerList.Count == 0 &&
                PEW.PrizeWinnerList.Count == 0
                )
            {
                Console.WriteLine("\n\n----------------------");
                Console.WriteLine($"THERE WERE NO WINNERS");
                Console.WriteLine("----------------------");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("\n\n----------------------");
                Console.WriteLine($"QUINI 6 WINNERS:");
                Console.WriteLine("----------------------");
                Console.WriteLine("");

                ConsoleTable Winners = new ConsoleTable("GAME TYPE", "PRIZE CATEGORY", "WINNER'S NAME", "WINNER'S AGE", "WINNER'S CITY", "WINNER'S ADDRESS", "WINNER'S PHONE NUMBER", "WINNER'S SELECTED NUMBERS", "NUMBER OF HITS", "AMOUNT WON");
                if (TPFPW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player TPFPWinner in TPFPW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TPFPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL PRIMERA", "FIRST PRIZE", TPFPWinner.Name, TPFPWinner.Age, TPFPWinner.City, TPFPWinner.Address, TPFPWinner.PhoneNumber, SelectedNumbers, "6", TPFPW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TPSPW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player TPSPWinner in TPSPW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TPSPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL PRIMERA", "SECOND PRIZE", TPSPWinner.Name, TPSPWinner.Age, TPSPWinner.City, TPSPWinner.Address, TPSPWinner.PhoneNumber, SelectedNumbers, "5", TPSPW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TPTPW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player TPTPWinner in TPTPW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TPTPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL PRIMERA", "THIRD PRIZE", TPTPWinner.Name, TPTPWinner.Age, TPTPWinner.City, TPTPWinner.Address, TPTPWinner.PhoneNumber, SelectedNumbers, "4", TPTPW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TSFPW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player TSFPWinner in TSFPW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TSFPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL SEGUNDA", "FIRST PRIZE", TSFPWinner.Name, TSFPWinner.Age, TSFPWinner.City, TSFPWinner.Address, TSFPWinner.PhoneNumber, SelectedNumbers, "6", TSFPW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TSSPW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player TSSPWinner in TSSPW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TSSPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL SEGUNDA", "SECOND PRIZE", TSSPWinner.Name, TSSPWinner.Age, TSSPWinner.City, TSSPWinner.Address, TSSPWinner.PhoneNumber, SelectedNumbers, "5", TSSPW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TSTPW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player TSTPWinner in TSTPW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TSTPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL SEGUNDA", "THIRD PRIZE", TSTPWinner.Name, TSTPWinner.Age, TSTPWinner.City, TSTPWinner.Address, TSTPWinner.PhoneNumber, SelectedNumbers, "4", TSTPW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (RW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player RPWinner in RW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in RPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("REVANCHA", "MAIN PRIZE", RPWinner.Name, RPWinner.Age, RPWinner.City, RPWinner.Address, RPWinner.PhoneNumber, SelectedNumbers, "6", RW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (SSW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player SSPWinner in SSW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in SSPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("SIEMPRE SALE", "MAIN PRIZE", SSPWinner.Name, SSPWinner.Age, SSPWinner.City, SSPWinner.Address, SSPWinner.PhoneNumber, SelectedNumbers, SSW.SiempreSaleWinnersNumberofMatches, SSW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (PEW.PrizeWinnerList.Count > 0)
                {
                    foreach (Player PEPWinner in PEW.PrizeWinnerList)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in PEPWinner.Quini6Ticket.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("POZO EXTRA", "MAIN PRIZE", PEPWinner.Name, PEPWinner.Age, PEPWinner.City, PEPWinner.Address, PEPWinner.PhoneNumber, SelectedNumbers, "6", PEW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                Winners.Write(Format.Alternative);
            }
        }

        private static void PrintGameStartMessage()
        {
            Console.Write("STARTING QUINI 6 GAME IN 3.");
            Thread.Sleep(250);
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(" ");
            Thread.Sleep(250);
            Console.Write("2.");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(" ");
            Console.Write("1.");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(" ");
        }
        #endregion
    }
}