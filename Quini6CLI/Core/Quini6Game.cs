using Quini6CLI.Generators;
using Quini6CLI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using Quini6CLI.Checkers;
using Quini6CLI.Winners;

namespace Quini6CLI.Core
{
    class Quini6Game
    {
        private static readonly decimal TotalTradicionalSales = 100000000;
        private static readonly decimal TotalRevanchaSales = 50000000;
        private static readonly decimal TotalSiempreSaleSales = 40000000;
        private static readonly decimal TradicionalPrimeraFirstPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.7m;
        private static readonly decimal TradicionalPrimeraSecondPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.1m;
        private static readonly decimal TradicionalPrimeraThirdPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.03m;
        private static readonly decimal TradicionalSegundaFirstPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.7m;
        private static readonly decimal TradicionalSegundaSecondPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.1m;
        private static readonly decimal TradicionalSegundaThirdPrize = TotalTradicionalSales * 0.5m * 0.4m * 0.03m;
        private static readonly decimal RevanchaPrize = TotalRevanchaSales * 0.9m * 0.6m * 0.8m;
        private static readonly decimal SiempreSalePrize = TotalSiempreSaleSales * 0.9m * 0.6m * 0.6m;
        private static readonly decimal PozoExtraPrize = (TotalTradicionalSales * 0.5m * 0.163m) + (TotalTradicionalSales * 0.5m * 0.163m) + (TotalRevanchaSales * 0.9m * 0.6m * 0.192m) + (TotalSiempreSaleSales * 0.9m * 0.6m * 0.4m);

        private List<Player> Players { get; set; }
        public List<int> TradicionalPrimeraNumbers { get; set; }
        public List<int> TradicionalSegundaNumbers { get; set; }
        public List<int> RevanchaNumbers { get; set; }
        public List<int> SiempreSaleNumbers { get; set; }
        public List<int> PozoExtraNumbers { get; set; }

        public Quini6Game(List<Player> Players)
        {
            this.Players = Players;
        }

        public void ExecuteQuini6Game()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("QUINI 6: " + DateTime.Now.ToString());
            Console.WriteLine("----------------------");
            PrintPrizes();
            List<GameTypeResult> Drawings = ExecuteDrawings();
            PrintDrawingResults(Drawings);
            Quini6Winners Q6W = CalculateWinners(Drawings);
            PrintWinners(Q6W);
        }

        private List<GameTypeResult> ExecuteDrawings()
        {
            ResultGenerator Q6RG = new ResultGenerator();
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
            GameTypeResult GTR = new GameTypeResult(Players, Enumerators.Enumerators.GameType.TradicionalPrimera, TradicionalPrimeraNumbers);
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
            Players = Players.Where(p => p.Games == Player.GameParticipation.TradicionalAndRevancha || p.Games == Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale).ToList();
            GameTypeResult GTR = new GameTypeResult(Players, Enumerators.Enumerators.GameType.Revancha, RevanchaNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteSiempreSale(IResultGenerator Q6RG)
        {
            SiempreSaleNumbers = Q6RG.GenerateDrawingResults();
            SiempreSaleNumbers.Sort();
            Players = Players.Where(p => p.Games == Player.GameParticipation.TradicionalAndSiempreSale || p.Games == Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale).ToList();
            GameTypeResult GTR = new GameTypeResult(Players, Enumerators.Enumerators.GameType.SiempreSale, SiempreSaleNumbers);
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

        private Quini6Winners CalculateWinners(List<GameTypeResult> Drawings)
        {
            GameTypeResult GTRTP = Drawings.First(d => d.Quini6GameType == Enumerators.Enumerators.GameType.TradicionalPrimera);
            GameTypeResult GTRTS = Drawings.First(d => d.Quini6GameType == Enumerators.Enumerators.GameType.TradicionalSegunda);
            GameTypeResult GTRR = Drawings.First(d => d.Quini6GameType == Enumerators.Enumerators.GameType.Revancha);
            GameTypeResult GTRSS = Drawings.First(d => d.Quini6GameType == Enumerators.Enumerators.GameType.SiempreSale);
            GameTypeResult GTRPE = Drawings.First(d => d.Quini6GameType == Enumerators.Enumerators.GameType.PozoExtra);

            PrizeCheckerTradicionalPrimera PCTP = new PrizeCheckerTradicionalPrimera(GTRTP, TradicionalPrimeraFirstPrize, TradicionalPrimeraSecondPrize, TradicionalPrimeraThirdPrize);
            PrizeCheckerTradicionalSegunda PCTS = new PrizeCheckerTradicionalSegunda(GTRTS, TradicionalSegundaFirstPrize, TradicionalSegundaSecondPrize, TradicionalSegundaThirdPrize);
            PrizeCheckerRevancha PCR = new PrizeCheckerRevancha(GTRR, RevanchaPrize);
            PrizeCheckerSiempreSale PCSS = new PrizeCheckerSiempreSale(GTRSS, SiempreSalePrize);
            PrizeCheckerPozoExtra PCPE = new PrizeCheckerPozoExtra(GTRPE, PozoExtraPrize);

            TradicionalPrimeraWinners TPW = PCTP.CheckPrizes();
            TradicionalSegundaWinners TSW = PCTS.CheckPrizes();
            RevanchaWinners RW = PCR.CheckPrizes();
            SiempreSaleWinners SSW = PCSS.CheckPrizes();
            PozoExtraWinners PEW = PCPE.CheckPrizes(TPW, TSW, RW);

            Quini6Winners Q6W = new Quini6Winners(TPW, TSW, RW, SSW, PEW);

            return Q6W;
        }

        private void PrintPrizes()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine("QUINI 6 PRIZE LIST:");
            Console.WriteLine("----------------------");
            Console.WriteLine("");

            ConsoleTable Results = new ConsoleTable("GAME TYPE", "PRIZE CATEGORY", "NUMBER OF HITS", "TOTAL PRIZE");
            Results.AddRow("TRADICIONAL PRIMERA", "FIRST PRIZE", "6", TradicionalPrimeraFirstPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL PRIMERA", "SECOND PRIZE", "5", TradicionalPrimeraSecondPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL PRIMERA", "THIRD PRIZE", "4", TradicionalPrimeraThirdPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "FIRST PRIZE", "6", TradicionalSegundaFirstPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "SECOND PRIZE", "5", TradicionalSegundaSecondPrize.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "THIRD PRIZE", "4", TradicionalSegundaThirdPrize.ToString("c2"));
            Results.AddRow("REVANCHA", "MAIN PRIZE", "6", RevanchaPrize.ToString("c2"));
            Results.AddRow("SIEMPRE SALE", "MAIN PRIZE", "6/5/4/3/2/1", SiempreSalePrize.ToString("c2"));
            Results.AddRow("POZO EXTRA", "MAIN PRIZE", "6", PozoExtraPrize.ToString("c2"));
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

        private void PrintWinners(Quini6Winners Q6W)
        {
            TradicionalPrimeraWinners TPW = Q6W.TPW;
            TradicionalSegundaWinners TSW = Q6W.TSW;
            RevanchaWinners RW = Q6W.RW;
            SiempreSaleWinners SSW = Q6W.SSW;
            PozoExtraWinners PEW = Q6W.PEW;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine($"QUINI 6 RESULTS:");
            Console.WriteLine("----------------------");
            Console.WriteLine("");

            ConsoleTable Results = new ConsoleTable("GAME TYPE", "PRIZE CATEGORY", "TOTAL PRIZE AMOUNT", "NUMBER OF WINNERS", "NUMBER OF HITS", "PRIZE FOR EACH WINNER");
            Results.AddRow("TRADICIONAL PRIMERA", "FIRST PRIZE", TradicionalPrimeraFirstPrize.ToString("c2"), TPW.TradicionalPrimeraFirstPrizeWinners.Count, "6", TPW.TradicionalPrimeraFirstPrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL PRIMERA", "SECOND PRIZE", TradicionalPrimeraSecondPrize.ToString("c2"), TPW.TradicionalPrimeraSecondPrizeWinners.Count, "5", TPW.TradicionalPrimeraSecondPrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL PRIMERA", "THIRD PRIZE", TradicionalPrimeraThirdPrize.ToString("c2"), TPW.TradicionalPrimeraThirdPrizeWinners.Count, "4", TPW.TradicionalPrimeraThirdPrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "FIRST PRIZE", TradicionalSegundaFirstPrize.ToString("c2"), TSW.TradicionalSegundaFirstPrizeWinners.Count, "6", TSW.TradicionalSegundaFirstPrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "SECOND PRIZE", TradicionalSegundaSecondPrize.ToString("c2"), TSW.TradicionalSegundaSecondPrizeWinners.Count, "5", TSW.TradicionalSegundaSecondPrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("TRADICIONAL SEGUNDA", "THIRD PRIZE", TradicionalSegundaThirdPrize.ToString("c2"), TSW.TradicionalSegundaThirdPrizeWinners.Count, "4", TSW.TradicionalSegundaThirdPrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("REVANCHA", "MAIN PRIZE", RevanchaPrize.ToString("c2"), RW.RevanchaPrizeWinners.Count, "6", RW.RevanchaPrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("SIEMPRE SALE", "MAIN PRIZE", SiempreSalePrize.ToString("c2"), SSW.SiempreSalePrizeWinners.Count, SSW.SiempreSaleWinnersNumberofMatches, SSW.SiempreSalePrizeAmountPerWinner.ToString("c2"));
            Results.AddRow("POZO EXTRA", "MAIN PRIZE", PozoExtraPrize.ToString("c2"), PEW.PozoExtraPrizeWinners.Count, "6", PEW.PozoExtraPrizeAmountPerWinner.ToString("c2"));
            Results.Write(Format.Alternative);

            if (TPW.TradicionalPrimeraFirstPrizeWinners.Count == 0 &&
                TPW.TradicionalPrimeraSecondPrizeWinners.Count == 0 &&
                TPW.TradicionalPrimeraThirdPrizeWinners.Count == 0 &&
                TSW.TradicionalSegundaFirstPrizeWinners.Count == 0 &&
                TSW.TradicionalSegundaSecondPrizeWinners.Count == 0 &&
                TSW.TradicionalSegundaThirdPrizeWinners.Count == 0 &&
                RW.RevanchaPrizeWinners.Count == 0 &&
                SSW.SiempreSalePrizeWinners.Count == 0 &&
                PEW.PozoExtraPrizeWinners.Count == 0
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
                if (TPW.TradicionalPrimeraFirstPrizeWinners.Count > 0)
                {
                    foreach (Player TPFPWinner in TPW.TradicionalPrimeraFirstPrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TPFPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL PRIMERA", "FIRST PRIZE", TPFPWinner.Name, SelectedNumbers, "6", TPW.TradicionalPrimeraFirstPrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TPW.TradicionalPrimeraSecondPrizeWinners.Count > 0)
                {
                    foreach (Player TPSPWinner in TPW.TradicionalPrimeraSecondPrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TPSPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL PRIMERA", "SECOND PRIZE", TPSPWinner.Name, SelectedNumbers, "5", TPW.TradicionalPrimeraSecondPrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TPW.TradicionalPrimeraThirdPrizeWinners.Count > 0)
                {
                    foreach (Player TPTPWinner in TPW.TradicionalPrimeraThirdPrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TPTPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL PRIMERA", "THIRD PRIZE", TPTPWinner.Name, SelectedNumbers, "4", TPW.TradicionalPrimeraThirdPrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TSW.TradicionalSegundaFirstPrizeWinners.Count > 0)
                {
                    foreach (Player TSFPWinner in TSW.TradicionalSegundaFirstPrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TSFPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL SEGUNDA", "FIRST PRIZE", TSFPWinner.Name, SelectedNumbers, "6", TSW.TradicionalSegundaFirstPrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TSW.TradicionalSegundaSecondPrizeWinners.Count > 0)
                {
                    foreach (Player TSSPWinner in TSW.TradicionalSegundaSecondPrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TSSPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL SEGUNDA", "SECOND PRIZE", TSSPWinner.Name, SelectedNumbers, "5", TSW.TradicionalSegundaSecondPrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (TSW.TradicionalSegundaThirdPrizeWinners.Count > 0)
                {
                    foreach (Player TSTPWinner in TSW.TradicionalSegundaThirdPrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in TSTPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("TRADICIONAL SEGUNDA", "THIRD PRIZE", TSTPWinner.Name, SelectedNumbers, "4", TSW.TradicionalSegundaThirdPrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (RW.RevanchaPrizeWinners.Count > 0)
                {
                    foreach (Player RPWinner in RW.RevanchaPrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in RPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("REVANCHA", "MAIN PRIZE", RPWinner.Name, SelectedNumbers, "6", RW.RevanchaPrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (SSW.SiempreSalePrizeWinners.Count > 0)
                {
                    foreach (Player SSPWinner in SSW.SiempreSalePrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in SSPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("SIEMPRE SALE", "MAIN PRIZE", SSPWinner.Name, SelectedNumbers, SSW.SiempreSaleWinnersNumberofMatches, SSW.SiempreSalePrizeAmountPerWinner.ToString("c2"));
                    }
                }
                if (PEW.PozoExtraPrizeWinners.Count > 0)
                {
                    foreach (Player PEPWinner in PEW.PozoExtraPrizeWinners)
                    {
                        string SelectedNumbers = string.Empty;
                        foreach (int Number in PEPWinner.SelectedNumbers)
                        {
                            SelectedNumbers = SelectedNumbers + Number.ToString("d2") + " - ";
                        }
                        SelectedNumbers = SelectedNumbers.Substring(0, SelectedNumbers.Length - 3);
                        Winners.AddRow("POZO EXTRA", "MAIN PRIZE", PEPWinner.Name, SelectedNumbers, "6", PEW.PozoExtraPrizeAmountPerWinner.ToString("c2"));
                    }
                }
                Winners.Write(Format.Alternative);
            }
        }
    }
}