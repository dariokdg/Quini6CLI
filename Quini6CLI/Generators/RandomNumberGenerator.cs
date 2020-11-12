using Quini6CLI.Interfaces;

namespace Quini6CLI.Generators
{
    class RandomNumberGenerator : IRandomNumber
    {
        private static readonly int InclusiveLowerBound = 0;
        private static readonly int ExclusiveUpperBound = 46;

        public RandomNumberGenerator()
        {

        }

        public int GetRandomQuini6Number()
        {
            return System.Security.Cryptography.RandomNumberGenerator.GetInt32(InclusiveLowerBound, ExclusiveUpperBound);
        }
    }
}