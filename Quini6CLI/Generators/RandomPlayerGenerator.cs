using Quini6CLI.Core;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Quini6CLI.Generators
{
    class RandomPlayerGenerator
    {

        public RandomPlayerGenerator()
        {

        }

        public List<Player> GenerateListOfRandomPlayers(long NumberOfRandomPlayers)
        {
            if (NumberOfRandomPlayers > 0)
            {
                List<Player> RandomPlayers = new List<Player>();

                PersonNameGenerator PNG1 = new PersonNameGenerator();
                Random R1 = new Random();
                PlaceNameGenerator CNG = new PlaceNameGenerator();
                PersonNameGenerator PNG2 = new PersonNameGenerator();
                Random R2 = new Random();
                Random R3 = new Random();
                ResultGenerator RG = new ResultGenerator();

                int Counter = 0;
                while (Counter < NumberOfRandomPlayers)
                {
                    RandomPlayers.Add(
                        new Player(
                            Name: PNG1.GenerateRandomFirstAndLastName(),
                            Age: R1.Next(18, 101),
                            City: CNG.GenerateRandomPlaceName(),
                            Address: PNG2.GenerateRandomFirstAndLastName() + " " + R2.Next(100, 10000),
                            PhoneNumber: (3410000000 + R3.Next(11111111, 20000000)).ToString(),
                            SelectedNumbers: RG.GenerateDrawingResults(),
                            Games: Player.GameParticipation.TradicionalAndRevanchaAndSiempreSale)
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
