using System;
using System.Collections.Generic;
using static Quini6CLI.Enumerators.Enumerators;

namespace Quini6CLI.Core
{
    class Ticket
    {
        public List<int> SelectedNumbers { get; set; }
        public GameParticipation Games { get; set; }

        public decimal Cost = 0;

        public Ticket(List<int> SelectedNumbers, GameParticipation Games)
        {
            this.SelectedNumbers = CheckSelectedNumbers(SelectedNumbers);
            this.Games = Games;
            Cost = GetTicketCost(Games);
        }

        private List<int> CheckSelectedNumbers(List<int> SelectedNumbers)
        {
            List<int> ProcessedNumbers = new List<int>();
            foreach (int SelectedNumber in SelectedNumbers)
            {
                if (!ProcessedNumbers.Contains(SelectedNumber))
                {
                    if (SelectedNumber >= 0 && SelectedNumber <= 45)
                    {
                        ProcessedNumbers.Add(SelectedNumber);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("There are numbers out of range within the provided list.\nTo play 'Quini 6' you need to select 6 different numbers, from 00 to 45.");
                    }
                }
            }
            if (ProcessedNumbers.Count == 6)
            {
                return ProcessedNumbers;
            }
            else
            {
                throw new ArgumentException("There are repeated numbers within the provided list.\nTo play 'Quini 6' you need to select 6 different numbers, from 00 to 45.");
            }
        }

        private decimal GetTicketCost(GameParticipation Games)
        {
            return Games switch
            {
                GameParticipation.TradicionalOnly => 50m,
                GameParticipation.TradicionalAndRevancha => 60m,
                GameParticipation.TradicionalAndRevanchaAndSiempreSale => 80m,
                _ => 50m,
            };
        }
    }
}
