using Quini6CLI.Core;
using Quini6CLI.Helpers;
using System.Collections.Generic;

namespace Quini6CLI.Interfaces
{
    interface IGameResultGenerator
    {
        public List<Player> Players { get; set; }

        public GameResults GetGameResults();
    }
}