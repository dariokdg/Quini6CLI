using Quini6CLI.Generators;
using System;
using System.Collections.Generic;

namespace Quini6CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Player JohnDoe = new Player("John Doe", 18, "Santa Fe", "Coronda", "Belgrano 123", "3424455667", new List<int> { 01, 32, 44, 15, 35, 17 }, Player.GameParticipation.TradicionalOnly);
            Console.WriteLine("Hello World!");
            ResultGenerator Q6RG = new ResultGenerator();
            List<int> Result = Q6RG.GetQuini6Results();
            foreach (int Number in Result)
            {
                Console.WriteLine(Number.ToString("D2"));
            }
        }
    }
}