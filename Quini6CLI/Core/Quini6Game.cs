﻿using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleTables;
using Quini6CLI.Helpers;
using Quini6CLI.Winners;
using Quini6CLI.Checkers;
using Quini6CLI.Generators;
using Quini6CLI.Interfaces;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Core
{
    class Quini6Game
    {
        public decimal TotalTradicionalSales { get; set; }
        public decimal TotalRevanchaSales { get; set; }
        public decimal TotalSiempreSaleSales { get; set; }
        public List<Player> Players { get; set; }
        public List<int> TradicionalPrimeraNumbers { get; set; }
        public List<int> TradicionalSegundaNumbers { get; set; }
        public List<int> RevanchaNumbers { get; set; }
        public List<int> SiempreSaleNumbers { get; set; }
        public List<int> PozoExtraNumbers { get; set; }

        public Quini6Game(List<Player> Players)
        {
            this.Players = Players;
            TotalTradicionalSales = 0;
            TotalRevanchaSales = 0;
            TotalSiempreSaleSales = 0;
        }

        public Quini6Winners ExecuteQuini6Game()
        {
            PrintProgramStartup();

            decimal TotalSells = CalculateTotalSells();
            PrintTotalSells(TotalSells);

            PrizeGenerator PG = GetPrizes();
            PrintPrizes(PG);

            List<GameTypeResult> Drawings = ExecuteDrawings();
            PrintDrawingResults(Drawings);

            Quini6Winners Q6W = CalculateWinners(Drawings, PG);
            PrintWinners(Q6W, PG);

            return Q6W;
        }

        private void PrintProgramStartup()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"QUINI 6 GAME STARTED: {DateTime.Now}");
            Console.WriteLine("----------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine($"NUMBER OF PLAYERS: {Players.Count}");
            Console.WriteLine("----------------------");
        }

        private decimal CalculateTotalSells()
        {
            decimal TotalSells = 0;
            foreach (Player Quini6Player in Players)
            {
                GameSpends GS = Quini6Player.CheckSpends();
                TotalTradicionalSales += GS.TradicionalSpends;
                TotalRevanchaSales += GS.RevanchaSpends;
                TotalSiempreSaleSales += GS.SiempreSaleSpends;
                TotalSells += (GS.TradicionalSpends + GS.RevanchaSpends + GS.SiempreSaleSpends);
            }
            return TotalSells;
        }

        private void PrintTotalSells(decimal TotalSells)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine($"TOTAL SELLS: {TotalSells:c2}");
            Console.WriteLine("----------------------");
        }

        private PrizeGenerator GetPrizes()
        { 
            return new PrizeGenerator(TotalTradicionalSales, TotalRevanchaSales, TotalSiempreSaleSales);
        }

        private List<GameTypeResult> ExecuteDrawings()
        {
            IResultGenerator Q6RG = new ResultGenerator();
            GameTypeResult GTRTP = ExecuteTradicionalPrimera(Q6RG);
            GameTypeResult GTRTS = ExecuteTradicionalSegunda(Q6RG);
            GameTypeResult GTRR = ExecuteRevancha(Q6RG);
            GameTypeResult GTRSS = ExecuteSiempreSale(Q6RG);
            GameTypeResult GTRPE = ExecutePozoExtra();
            return new List<GameTypeResult> { GTRTP, GTRTS, GTRR, GTRSS, GTRPE };
        }

        private GameTypeResult ExecuteTradicionalPrimera(IResultGenerator Q6RG)
        {
            TradicionalPrimeraNumbers = Q6RG.GenerateDrawingResults();
            TradicionalPrimeraNumbers.Sort();
            GameTypeResult GTR = new GameTypeResult(Players, GameType.TradicionalPrimera, TradicionalPrimeraNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteTradicionalSegunda(IResultGenerator Q6RG)
        {
            TradicionalSegundaNumbers = Q6RG.GenerateDrawingResults();
            TradicionalSegundaNumbers.Sort();
            GameTypeResult GTR = new GameTypeResult(Players, Enumerators.Enumerators.GameType.TradicionalSegunda, TradicionalSegundaNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteRevancha(IResultGenerator Q6RG)
        {
            RevanchaNumbers = Q6RG.GenerateDrawingResults();
            RevanchaNumbers.Sort();
            Players = Players.Where(p => p.Quini6Ticket.Games == GameParticipation.TradicionalAndRevancha || p.Quini6Ticket.Games == GameParticipation.TradicionalAndRevanchaAndSiempreSale).ToList();
            GameTypeResult GTR = new GameTypeResult(Players, GameType.Revancha, RevanchaNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteSiempreSale(IResultGenerator Q6RG)
        {
            SiempreSaleNumbers = Q6RG.GenerateDrawingResults();
            SiempreSaleNumbers.Sort();
            Players = Players.Where(p => p.Quini6Ticket.Games == GameParticipation.TradicionalAndRevanchaAndSiempreSale).ToList();
            GameTypeResult GTR = new GameTypeResult(Players, GameType.SiempreSale, SiempreSaleNumbers);
            return GTR;
        }

        private GameTypeResult ExecutePozoExtra()
        {
            List<int> TemporaryList = new List<int>();
            TemporaryList.AddRange(TradicionalPrimeraNumbers);
            TemporaryList.AddRange(TradicionalSegundaNumbers);
            TemporaryList.AddRange(RevanchaNumbers);
            PozoExtraNumbers = TemporaryList.Distinct().ToList();
            PozoExtraNumbers.Sort();
            GameTypeResult GTR = new GameTypeResult(Players, Enumerators.Enumerators.GameType.PozoExtra, PozoExtraNumbers);
            return GTR;
        }

        private Quini6Winners CalculateWinners(List<GameTypeResult> Drawings, PrizeGenerator PG)
        {
            GameTypeResult GTRTP = Drawings.First(d => d.Quini6GameType == GameType.TradicionalPrimera);
            GameTypeResult GTRTS = Drawings.First(d => d.Quini6GameType == GameType.TradicionalSegunda);
            GameTypeResult GTRR = Drawings.First(d => d.Quini6GameType == GameType.Revancha);
            GameTypeResult GTRSS = Drawings.First(d => d.Quini6GameType == GameType.SiempreSale);
            GameTypeResult GTRPE = Drawings.First(d => d.Quini6GameType == GameType.PozoExtra);

            PrizeCheckerTradicionalPrimeraFirstPrize PCTPFP = new PrizeCheckerTradicionalPrimeraFirstPrize(GTRTP, PG.TradicionalPrimeraFirstPrize);
            IWinner TPFPW = PCTPFP.CheckPrizes();

            PrizeCheckerTradicionalPrimeraSecondPrize PCTPSP = new PrizeCheckerTradicionalPrimeraSecondPrize(GTRTP, PG.TradicionalPrimeraSecondPrize);
            IWinner TPSPW = PCTPSP.CheckPrizes();

            PrizeCheckerTradicionalPrimeraThirdPrize PCTPTP = new PrizeCheckerTradicionalPrimeraThirdPrize(GTRTP, PG.TradicionalPrimeraThirdPrize);
            IWinner TPTPW = PCTPTP.CheckPrizes();

            PrizeCheckerTradicionalSegundaFirstPrize PCTSFP = new PrizeCheckerTradicionalSegundaFirstPrize(GTRTS, PG.TradicionalSegundaFirstPrize);
            IWinner TSFPW = PCTSFP.CheckPrizes();

            PrizeCheckerTradicionalSegundaSecondPrize PCTSSP = new PrizeCheckerTradicionalSegundaSecondPrize(GTRTS, PG.TradicionalSegundaSecondPrize);
            IWinner TSSPW = PCTSSP.CheckPrizes();

            PrizeCheckerTradicionalSegundaThirdPrize PCTSTP = new PrizeCheckerTradicionalSegundaThirdPrize(GTRTS, PG.TradicionalSegundaThirdPrize);
            IWinner TSTPW = PCTSTP.CheckPrizes();

            PrizeCheckerRevancha PCR = new PrizeCheckerRevancha(GTRR, PG.RevanchaPrize);
            IWinner RW = PCR.CheckPrizes();

            PrizeCheckerSiempreSale PCSS = new PrizeCheckerSiempreSale(GTRSS, PG.SiempreSalePrize);
            IWinner SSW = PCSS.CheckPrizes();

            PrizeCheckerPozoExtra PCPE = new PrizeCheckerPozoExtra(GTRPE, PG.PozoExtraPrize, TPFPW, TSFPW, RW);
            IWinner PEW = PCPE.CheckPrizes();


            Quini6Winners Q6W = new Quini6Winners(TPFPW, TPSPW, TPTPW, TSFPW, TSSPW, TSTPW, RW, SSW, PEW);

            return Q6W;
        }

        private void PrintPrizes(PrizeGenerator PG)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine("QUINI 6 PRIZE LIST:");
            Console.WriteLine("----------------------");
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

        private void PrintDrawingResults(List<GameTypeResult> DrawingResults)
        {
            GameTypeResult GTRTP = DrawingResults[0];
            GameTypeResult GTRTS = DrawingResults[1];
            GameTypeResult GTRR = DrawingResults[2];
            GameTypeResult GTRSS = DrawingResults[3];
            GameTypeResult GTRPE = DrawingResults[4];


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine($"QUINI 6 DRAWINGS:");
            Console.WriteLine("----------------------");
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

        private void PrintWinners(Quini6Winners Q6W, PrizeGenerator PG)
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

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine($"QUINI 6 RESULTS:");
            Console.WriteLine("----------------------");
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
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("----------------------");
                Console.WriteLine($"THERE WERE NO WINNERS");
                Console.WriteLine("----------------------");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("----------------------");
                Console.WriteLine($"QUINI 6 WINNERS:");
                Console.WriteLine("----------------------");
                Console.WriteLine("");

                ConsoleTable Winners = new ConsoleTable("GAME TYPE", "PRIZE CATEGORY", "WINNER'S NAME", "WINNER'S SELECTED NUMBERS", "NUMBER OF HITS", "AMOUNT WON");
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
                        Winners.AddRow("TRADICIONAL PRIMERA", "FIRST PRIZE", TPFPWinner.Name, SelectedNumbers, "6", TPFPW.PrizeAmountPerWinner.ToString("c2"));
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
                        Winners.AddRow("TRADICIONAL PRIMERA", "SECOND PRIZE", TPSPWinner.Name, SelectedNumbers, "5", TPSPW.PrizeAmountPerWinner.ToString("c2"));
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
                        Winners.AddRow("TRADICIONAL PRIMERA", "THIRD PRIZE", TPTPWinner.Name, SelectedNumbers, "4", TPTPW.PrizeAmountPerWinner.ToString("c2"));
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
                        Winners.AddRow("TRADICIONAL SEGUNDA", "FIRST PRIZE", TSFPWinner.Name, SelectedNumbers, "6", TSFPW.PrizeAmountPerWinner.ToString("c2"));
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
                        Winners.AddRow("TRADICIONAL SEGUNDA", "SECOND PRIZE", TSSPWinner.Name, SelectedNumbers, "5", TSSPW.PrizeAmountPerWinner.ToString("c2"));
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
                        Winners.AddRow("TRADICIONAL SEGUNDA", "THIRD PRIZE", TSTPWinner.Name, SelectedNumbers, "4", TSTPW.PrizeAmountPerWinner.ToString("c2"));
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
                        Winners.AddRow("REVANCHA", "MAIN PRIZE", RPWinner.Name, SelectedNumbers, "6", RW.PrizeAmountPerWinner.ToString("c2"));
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
                        Winners.AddRow("SIEMPRE SALE", "MAIN PRIZE", SSPWinner.Name, SelectedNumbers, SSW.SiempreSaleWinnersNumberofMatches, SSW.PrizeAmountPerWinner.ToString("c2"));
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
                        Winners.AddRow("POZO EXTRA", "MAIN PRIZE", PEPWinner.Name, SelectedNumbers, "6", PEW.PrizeAmountPerWinner.ToString("c2"));
                    }
                }
                Winners.Write(Format.Alternative);
            }
        }
    }
}