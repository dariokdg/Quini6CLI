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
            Console.WriteLine("STARTING QUINI 6 GAME:");
            PrintPrizes();
            ResultGenerator Q6RG = new ResultGenerator();
            List<GameTypeResult> Drawings = ExecuteDrawings(Q6RG);
            Quini6Winners Q6W = CalculateWinners(Drawings);
            PrintWinners(Q6W);
        }

        private List<GameTypeResult> ExecuteDrawings(IResultGenerator Q6RG)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("DRAWING RESULTS:");
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
            PrintResults("Tradicional Primera", TradicionalPrimeraNumbers);
            GameTypeResult GTR = new GameTypeResult(Players, Enumerators.Enumerators.GameType.TradicionalPrimera, TradicionalPrimeraNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteTradicionalSegunda(IResultGenerator Q6RG)
        {
            TradicionalSegundaNumbers = Q6RG.GenerateDrawingResults();
            PrintResults("Tradicional Segunda", TradicionalSegundaNumbers);
            GameTypeResult GTR = new GameTypeResult(Players, Enumerators.Enumerators.GameType.TradicionalSegunda, TradicionalSegundaNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteRevancha(IResultGenerator Q6RG)
        {
            RevanchaNumbers = Q6RG.GenerateDrawingResults();
            PrintResults("Revancha", RevanchaNumbers);
            Players = Players.Where(p => p.Games == Player.GameParticipation.TradicionalAndRevancha || p.Games == Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale).ToList();
            GameTypeResult GTR = new GameTypeResult(Players, Enumerators.Enumerators.GameType.Revancha, RevanchaNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteSiempreSale(IResultGenerator Q6RG)
        {
            SiempreSaleNumbers = Q6RG.GenerateDrawingResults();
            PrintResults("Siempre Sale", SiempreSaleNumbers);
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
            PrintResults("Pozo Extra", PozoExtraNumbers);
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
            Console.WriteLine("----------------------");
            Console.WriteLine("PRIZE LIST:");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("TRADICIONAL PRIMERA:");
            Console.WriteLine();
            ConsoleTable TradicionalPrimera = new ConsoleTable("FIRST PRIZE (6 matches)", "SECOND PRIZE (5 matches)", "THIRD PRIZE (4 matches)");
            TradicionalPrimera.AddRow(TradicionalPrimeraFirstPrize.ToString("c2"), TradicionalPrimeraSecondPrize.ToString("c2"), TradicionalPrimeraThirdPrize.ToString("c2"));
            TradicionalPrimera.Write(Format.Alternative);
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("TRADICIONAL SEGUNDA:");
            Console.WriteLine();
            ConsoleTable TradicionalSegunda = new ConsoleTable("FIRST PRIZE (6 matches)", "SECOND PRIZE (5 matches)", "THIRD PRIZE (4 matches)");
            TradicionalSegunda.AddRow(TradicionalSegundaFirstPrize.ToString("c2"), TradicionalSegundaSecondPrize.ToString("c2"), TradicionalSegundaThirdPrize.ToString("c2"));
            TradicionalSegunda.Write(Format.Alternative);
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("REVANCHA:");
            Console.WriteLine();
            ConsoleTable Revancha = new ConsoleTable("MAIN PRIZE (6 matches)");
            Revancha.AddRow(RevanchaPrize.ToString("c2"));
            Revancha.Write(Format.Alternative);
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("SIEMPRE SALE:");
            Console.WriteLine();
            ConsoleTable SiempreSale = new ConsoleTable("MAIN PRIZE");
            SiempreSale.AddRow(SiempreSalePrize.ToString("c2"));
            SiempreSale.Write(Format.Alternative);
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("POZO EXTRA:");
            Console.WriteLine();
            ConsoleTable PozoExtra = new ConsoleTable("MAIN PRIZE");
            PozoExtra.AddRow(PozoExtraPrize.ToString("c2"));
            PozoExtra.Write(Format.Alternative);
            Console.WriteLine();
            Console.WriteLine("----------------------");
        }

        private void PrintResults(string GameType, List<int> Numbers)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine($"{GameType.ToUpper()} RESULTS:");
            Console.WriteLine();
            if (GameType != "Pozo Extra")
            {
                ConsoleTable Results = new ConsoleTable("FIRST NUMBER", "SECOND NUMBER", "THIRD NUMBER", "FOURTH NUMBER", "FIFTH NUMBER", "SIXTH NUMBER");
                Results.AddRow(Numbers[0].ToString("D2"), Numbers[1].ToString("D2"), Numbers[2].ToString("D2"), Numbers[3].ToString("D2"), Numbers[4].ToString("D2"), Numbers[5].ToString("D2"));
                Results.Write(Format.Alternative);
            }
            else
            {
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
                ConsoleTable Results = new ConsoleTable(Number01, Number02, Number03, Number04, Number05, Number06);
                if (!string.IsNullOrWhiteSpace(Number07))
                {
                    Results.AddRow(Number07, Number08, Number09, Number10, Number11, Number12);
                    if (!string.IsNullOrWhiteSpace(Number13))
                    {
                        Results.AddRow(Number13, Number14, Number15, Number16, Number17, Number18);
                    }
                }
                Results.Write(Format.Alternative);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------");
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
            Console.WriteLine($"QUINI 6 DRAWING WINNERS:");
            Console.WriteLine("----------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Tradicional Primera:");
            Console.WriteLine("----------------------");
            ConsoleTable TPFP = new ConsoleTable("FIRST PRIZE (6 matches)", "NUMBER OF WINNERS", "EACH ONE GETS");
            TPFP.AddRow(TradicionalPrimeraFirstPrize.ToString("c2"), TPW.TradicionalPrimeraFirstPrizeWinners.Count, TPW.TradicionalPrimeraFirstPrizeAmountPerWinner.ToString("c2"));
            TPFP.Write(Format.Alternative);
            Console.WriteLine("");
            ConsoleTable TPSP = new ConsoleTable("SECOND PRIZE (5 matches)", "NUMBER OF WINNERS", "EACH ONE GETS");
            TPSP.AddRow(TradicionalPrimeraSecondPrize.ToString("c2"), TPW.TradicionalPrimeraSecondPrizeWinners.Count, TPW.TradicionalPrimeraSecondPrizeAmountPerWinner.ToString("c2"));
            TPSP.Write(Format.Alternative);
            Console.WriteLine("");
            ConsoleTable TPTP = new ConsoleTable("THIRD PRIZE (5 matches)", "NUMBER OF WINNERS", "EACH ONE GETS");
            TPTP.AddRow(TradicionalPrimeraThirdPrize.ToString("c2"), TPW.TradicionalPrimeraThirdPrizeWinners.Count, TPW.TradicionalPrimeraThirdPrizeAmountPerWinner.ToString("c2"));
            TPTP.Write(Format.Alternative);



            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Tradicional Segunda:");
            Console.WriteLine("----------------------");
            ConsoleTable TSFP = new ConsoleTable("FIRST PRIZE (6 matches)", "NUMBER OF WINNERS", "EACH ONE GETS");
            TSFP.AddRow(TradicionalSegundaFirstPrize.ToString("c2"), TSW.TradicionalSegundaFirstPrizeWinners.Count, TSW.TradicionalSegundaFirstPrizeAmountPerWinner.ToString("c2"));
            TSFP.Write(Format.Alternative);
            Console.WriteLine("");
            ConsoleTable TSSP = new ConsoleTable("SECOND PRIZE (5 matches)", "NUMBER OF WINNERS", "EACH ONE GETS");
            TSSP.AddRow(TradicionalSegundaSecondPrize.ToString("c2"), TSW.TradicionalSegundaSecondPrizeWinners.Count, TSW.TradicionalSegundaSecondPrizeAmountPerWinner.ToString("c2"));
            TSSP.Write(Format.Alternative);
            Console.WriteLine("");
            ConsoleTable TSTP = new ConsoleTable("THIRD PRIZE (5 matches)", "NUMBER OF WINNERS", "EACH ONE GETS");
            TSTP.AddRow(TradicionalSegundaThirdPrize.ToString("c2"), TSW.TradicionalSegundaThirdPrizeWinners.Count, TSW.TradicionalSegundaThirdPrizeAmountPerWinner.ToString("c2"));
            TSTP.Write(Format.Alternative);



            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Revancha:");
            Console.WriteLine("----------------------");
            ConsoleTable RP = new ConsoleTable("MAIN PRIZE (6 matches)", "NUMBER OF WINNERS", "EACH ONE GETS");
            RP.AddRow(RevanchaPrize.ToString("c2"), RW.RevanchaPrizeWinners.Count, RW.RevanchaPrizeAmountPerWinner.ToString("c2"));
            RP.Write(Format.Alternative);



            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Siempre Sale:");
            Console.WriteLine("----------------------");
            ConsoleTable SSP = new ConsoleTable("MAIN PRIZE", "NUMBER OF WINNERS", "MATCHING NUMBERS", "EACH ONE GETS");
            SSP.AddRow(SiempreSalePrize.ToString("c2"), SSW.SiempreSalePrizeWinners.Count, SSW.SiempreSaleWinnersNumberofMatches, SSW.SiempreSalePrizeAmountPerWinner.ToString("c2"));
            SSP.Write(Format.Alternative);



            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Pozo Extra:");
            Console.WriteLine("----------------------");
            ConsoleTable PEP = new ConsoleTable("MAIN PRIZE (6 matches)", "NUMBER OF WINNERS", "EACH ONE GETS");
            PEP.AddRow(PozoExtraPrize.ToString("c2"), PEW.PozoExtraPrizeWinners.Count, PEW.PozoExtraPrizeAmountPerWinner.ToString("c2"));
            PEP.Write(Format.Alternative);
        }
    }
}