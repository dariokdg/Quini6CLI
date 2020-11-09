using Quini6CLI.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quini6CLI.Core
{
    class GameTypeResult
    {
        public List<Player> Players = new List<Player>();
        public Enumerators.Enumerators.GameType Quini6GameType { get; set; }
        public List<int> DrawingResults { get; set; }

        public GameTypeResult(List<Player> Players, Enumerators.Enumerators.GameType Quini6GameType, List<int> DrawingResults)
        {
            this.Players = Players;
            this.Quini6GameType = Quini6GameType;
            this.DrawingResults = DrawingResults;
        }
    }
}