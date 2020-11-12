﻿using Quini6CLI.Core;
using Quini6CLI.Interfaces;
using RandomNameGeneratorLibrary;
using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Threading;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Generators
{
    class RandomPlayerGenerator
    {
        private readonly List<Player> RandomPlayers = new List<Player>();
        private readonly Random R = new Random();
        private readonly PersonNameGenerator PNG = new PersonNameGenerator();
        private readonly PlaceNameGenerator CNG = new PlaceNameGenerator();
        private readonly IResultGenerator RG = new ResultGenerator();

        public RandomPlayerGenerator()
        {

        }

        public List<Player> GenerateListOfRandomPlayers(long NumberOfRandomPlayers)
        {
            if (NumberOfRandomPlayers > 0)
            {
                ProgressBarOptions PBOptions = new ProgressBarOptions{ForegroundColor = ConsoleColor.DarkCyan, ForegroundColorDone = ConsoleColor.DarkGreen, BackgroundColor = ConsoleColor.DarkGray, BackgroundCharacter = '\u2593'};
                int Counter = 0;
                using (ProgressBar PB = new ProgressBar((int)NumberOfRandomPlayers, $"CREATING RANDOM PLAYERS", PBOptions))
                {
                    while (Counter < NumberOfRandomPlayers)
                    {
                        RandomPlayers.Add(
                            new Player(
                                Name: PNG.GenerateRandomFirstAndLastName(),
                                Age: R.Next(18, 101),
                                City: CNG.GenerateRandomPlaceName(),
                                Address: PNG.GenerateRandomFirstAndLastName() + " " + R.Next(100, 10000),
                                PhoneNumber: (3410000000 + R.Next(1111111, 2000000)).ToString(),
                                Quini6Ticket: 
                                    new Ticket(
                                        SelectedNumbers: RG.GenerateDrawingResults(),
                                        Games: (GameParticipation)R.Next(0, 3)
                                    )
                            )
                        );
                        Counter++;
                        PB.Tick($"CREATING RANDOM PLAYERS: CREATED {Counter}/{NumberOfRandomPlayers}");
                    }
                }
                Console.WriteLine($"ALL {NumberOfRandomPlayers} PLAYERS CREATED");
                PrintGameStartMessage();
                Console.Clear();
                return RandomPlayers;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The number of 'Random Players' to be generated must be an integer greater than zero.");
            }
        }

        private void PrintGameStartMessage()
        {
            Console.Write("STARTING QUINI 6 GAME IN 3.");
            Thread.Sleep(250);
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(" ");
            Thread.Sleep(250);
            Console.Write("2.");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(" ");
            Console.Write("1.");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(" ");
        }
    }
}
