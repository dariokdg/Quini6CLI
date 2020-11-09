using System;
using System.Collections.Generic;
using System.Linq;

namespace Quini6CLI.Core
{
    class Player
    {
        public enum GameParticipation
        {
            TradicionalOnly,
            TradicionalAndRevancha,
            TradicionalAndSiempreSale,
            TradicionalAndRevanchaAndSiempreSale
        }

        private string Name { get; set; }
        private int Age { get; set; }
        private string Province { get; set; }
        private string City { get; set; }
        private string Address { get; set; }
        private string PhoneNumber { get; set; }
        private List<int> SelectedNumbers { get; set; }
        private decimal PrizeMoney { get; set; }
        public GameParticipation Games { get; set; }

        public Player(string Name, int Age, string Province, string City, string Address, string PhoneNumber, List<int> SelectedNumbers, GameParticipation Games)
        {
            this.Name = Name;
            this.Age = CheckAge(Age);
            this.Province = Province;
            this.City = City;
            this.Address = Address;
            this.PhoneNumber = CheckPhoneNumber(PhoneNumber);
            this.SelectedNumbers = CheckSelectedNumbers(SelectedNumbers);
            this.PrizeMoney = 0;
            this.Games = Games;
        }

        private int CheckAge(int Age)
        {
            if (Age >= 18)
            {
                return Age;
            }
            else
            {
                throw new ArgumentOutOfRangeException("This user is not allowed to play 'Quini 6'.\nUser must be 18 or older to be able to play this game.");
            }
        }

        private string CheckPhoneNumber(string PhoneNumber)
        {
            if (!string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.All(char.IsDigit) && PhoneNumber.Length == 10)
            {
                return PhoneNumber;
            }
            else
            {
                throw new ArgumentException("The phone number is invalid.\nUser must enter their phone number in the format of 10 consecutive numbers (code area + phone number).\nFor example: '3414455667'");
            }
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

        public decimal CheckWinnings()
        {
            return this.PrizeMoney;
        }
    }
}
