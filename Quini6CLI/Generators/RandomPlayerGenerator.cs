using Quini6CLI.Core;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Generators
{
    class RandomPlayerGenerator
    {
        List<Player> RandomPlayers = new List<Player>();
        Random R = new Random();
        PersonNameGenerator PNG = new PersonNameGenerator();
        PlaceNameGenerator CNG = new PlaceNameGenerator();
        ResultGenerator RG = new ResultGenerator();

        public RandomPlayerGenerator()
        {

        }

        public List<Player> GenerateListOfRandomPlayers(long NumberOfRandomPlayers)
        {
            if (NumberOfRandomPlayers > 0)
            {
                int Counter = 0;
                while (Counter < NumberOfRandomPlayers)
                {
                    RandomPlayers.Add(
                        new Player(
                            Name: PNG.GenerateRandomFirstAndLastName(),
                            Age: R.Next(18, 101),
                            City: CNG.GenerateRandomPlaceName(),
                            Address: PNG.GenerateRandomFirstAndLastName() + " " + R.Next(100, 10000),
                            PhoneNumber: (3410000000 + R.Next(11111111, 20000000)).ToString(),
                            Quini6Ticket: 
                                new Ticket(
                                    SelectedNumbers: RG.GenerateDrawingResults(),
                                    Games: (GameParticipation)R.Next(0, 3)
                                )
                        )
                    );
                    Counter++;
                    Console.Write($"CREATING RANDOM PLAYERS: CREATED {Counter}/{NumberOfRandomPlayers}               \r");
                }
                Console.Clear();
                return RandomPlayers;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The number of 'Random Players' to be generated must be an integer greater than zero.");
            }
        }
    }
}
