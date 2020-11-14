using Quini6CLI.Interfaces;
using System.Collections.Generic;

namespace Quini6CLI.Generators
{
    class DrawingResultGenerator : IDrawingResultGenerator
    {
        private int FirstNumber { get; set; }
        private int SecondNumber { get; set; }
        private int ThirdNumber { get; set; }
        private int FourthNumber { get; set; }
        private int FifthNumber { get; set; }
        private int SixthNumber { get; set; }

        public DrawingResultGenerator()
        {

        }

        public List<int> GenerateDrawingResults()
        {
            IRandomNumber RNP = new RandomNumberGenerator();
            FirstNumber = GetFirstNumber(RNP);
            SecondNumber = GetSecondNumber(RNP);
            ThirdNumber = GetThirdNumber(RNP);
            FourthNumber = GetFourthNumber(RNP);
            FifthNumber = GetFifthNumber(RNP);
            SixthNumber = GetSixthNumber(RNP);
            return new List<int> { FirstNumber, SecondNumber, ThirdNumber, FourthNumber, FifthNumber, SixthNumber };
        }

        private int GetFirstNumber(IRandomNumber RNP)
        {
            return RNP.GetRandomQuini6Number();
        }

        private int GetSecondNumber(IRandomNumber RNP)
        {
            int Result;
            int TemporaryResult = RNP.GetRandomQuini6Number();
            while (TemporaryResult == FirstNumber)
            {
                TemporaryResult = RNP.GetRandomQuini6Number();
            }
            Result = TemporaryResult;
            return Result;
        }

        private int GetThirdNumber(IRandomNumber RNP)
        {
            int Result;
            int TemporaryResult = RNP.GetRandomQuini6Number();
            while (TemporaryResult == FirstNumber || TemporaryResult == SecondNumber)
            {
                TemporaryResult = RNP.GetRandomQuini6Number();
            }
            Result = TemporaryResult;
            return Result;
        }

        private int GetFourthNumber(IRandomNumber RNP)
        {
            int Result;
            int TemporaryResult = RNP.GetRandomQuini6Number();
            while (TemporaryResult == FirstNumber || TemporaryResult == SecondNumber || TemporaryResult == ThirdNumber)
            {
                TemporaryResult = RNP.GetRandomQuini6Number();
            }
            Result = TemporaryResult;
            return Result;
        }

        private int GetFifthNumber(IRandomNumber RNP)
        {
            int Result;
            int TemporaryResult = RNP.GetRandomQuini6Number();
            while (TemporaryResult == FirstNumber || TemporaryResult == SecondNumber || TemporaryResult == ThirdNumber || TemporaryResult == FourthNumber)
            {
                TemporaryResult = RNP.GetRandomQuini6Number();
            }
            Result = TemporaryResult;
            return Result;
        }

        private int GetSixthNumber(IRandomNumber RNP)
        {
            int Result;
            int TemporaryResult = RNP.GetRandomQuini6Number();
            while (TemporaryResult == FirstNumber || TemporaryResult == SecondNumber || TemporaryResult == ThirdNumber || TemporaryResult == FourthNumber || TemporaryResult == FifthNumber)
            {
                TemporaryResult = RNP.GetRandomQuini6Number();
            }
            Result = TemporaryResult;
            return Result;
        }
    }

}
