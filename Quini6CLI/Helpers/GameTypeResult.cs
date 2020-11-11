using Quini6CLI.Core;
using System.Collections.Generic;

namespace Quini6CLI.Helpers
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