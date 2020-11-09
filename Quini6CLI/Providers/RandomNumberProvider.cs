using Quini6CLI.Interfaces;
using System;
using System.Security.Cryptography;

namespace Quini6CLI.Providers
{
    class RandomNumberProvider : IRandomNumber
    {
        private int InclusiveLowerBound { get; set; }
        private int ExclusiveUpperBound { get; set; }

        public RandomNumberProvider()
        {
            InclusiveLowerBound = 0;
            ExclusiveUpperBound = 46;
        }

        public int GetRandomQuini6Number()
        {
            return RandomNumberGenerator.GetInt32(InclusiveLowerBound, ExclusiveUpperBound);
        }
    }
}