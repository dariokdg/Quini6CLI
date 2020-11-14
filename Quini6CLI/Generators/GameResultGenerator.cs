using System.Linq;
using Quini6CLI.Core;
using Quini6CLI.Helpers;
using Quini6CLI.Interfaces;
using System.Collections.Generic;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Generators
{
    class GameResultGenerator : IGameResultGenerator
    {
        public List<Player> Players { get; set; }
        private GameTypeResult GTRTP { get; set; }
        private GameTypeResult GTRTS { get; set; }
        private GameTypeResult GTRR { get; set; }
        private GameTypeResult GTRSS { get; set; }
        private GameTypeResult GTRPE { get; set; }
    
        public GameResultGenerator(List<Player> Players, IDrawingResultGenerator Q6RG)
        {
            this.Players = Players;
            GTRTP = ExecuteTradicionalPrimera(Q6RG);
            GTRTS = ExecuteTradicionalSegunda(Q6RG);
            GTRR = ExecuteRevancha(Q6RG);
            GTRSS = ExecuteSiempreSale(Q6RG);
            GTRPE = ExecutePozoExtra(GTRTP.DrawingResults, GTRTS.DrawingResults, GTRR.DrawingResults);
        }

        private GameTypeResult ExecuteTradicionalPrimera(IDrawingResultGenerator Q6RG)
        {
            List<int> TradicionalPrimeraNumbers = Q6RG.GenerateDrawingResults();
            TradicionalPrimeraNumbers.Sort();
            GameTypeResult GTR = new GameTypeResult(Players, GameType.TradicionalPrimera, TradicionalPrimeraNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteTradicionalSegunda(IDrawingResultGenerator Q6RG)
        {
            List<int> TradicionalSegundaNumbers = Q6RG.GenerateDrawingResults();
            TradicionalSegundaNumbers.Sort();
            GameTypeResult GTR = new GameTypeResult(Players, GameType.TradicionalSegunda, TradicionalSegundaNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteRevancha(IDrawingResultGenerator Q6RG)
        {
            List<int> RevanchaNumbers = Q6RG.GenerateDrawingResults();
            RevanchaNumbers.Sort();
            Players = Players.Where(p => p.Quini6Ticket.Games == GameParticipation.TradicionalAndRevancha || p.Quini6Ticket.Games == GameParticipation.TradicionalAndRevanchaAndSiempreSale).ToList();
            GameTypeResult GTR = new GameTypeResult(Players, GameType.Revancha, RevanchaNumbers);
            return GTR;
        }

        private GameTypeResult ExecuteSiempreSale(IDrawingResultGenerator Q6RG)
        {
            List<int> SiempreSaleNumbers = Q6RG.GenerateDrawingResults();
            SiempreSaleNumbers.Sort();
            Players = Players.Where(p => p.Quini6Ticket.Games == GameParticipation.TradicionalAndRevanchaAndSiempreSale).ToList();
            GameTypeResult GTR = new GameTypeResult(Players, GameType.SiempreSale, SiempreSaleNumbers);
            return GTR;
        }

        private GameTypeResult ExecutePozoExtra(List<int> TPDrawingNumbers, List<int> TSDrawingNumbers, List<int> RDrawingNumbers)
        {
            List<int> TemporaryList = new List<int>();
            TemporaryList.AddRange(TPDrawingNumbers);
            TemporaryList.AddRange(TSDrawingNumbers);
            TemporaryList.AddRange(RDrawingNumbers);
            List<int> PozoExtraNumbers = TemporaryList.Distinct().ToList();
            PozoExtraNumbers.Sort();
            GameTypeResult GTR = new GameTypeResult(Players, GameType.PozoExtra, PozoExtraNumbers);
            return GTR;
        }

        public GameResults GetGameResults()
        {
            return new GameResults(GTRTP, GTRTS, GTRR, GTRSS, GTRPE);
        }
    }
}