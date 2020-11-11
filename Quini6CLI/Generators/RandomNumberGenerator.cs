using Quini6CLI.Interfaces;

namespace Quini6CLI.Generators
{
    class RandomNumberGenerator : IRandomNumber
    {
        private int InclusiveLowerBound { get; set; }
        private int ExclusiveUpperBound { get; set; }

        public RandomNumberGenerator()
        {
            InclusiveLowerBound = 0;
            ExclusiveUpperBound = 46;
        }

        public int GetRandomQuini6Number()
        {
            return System.Security.Cryptography.RandomNumberGenerator.GetInt32(InclusiveLowerBound, ExclusiveUpperBound);
        }
    }
}