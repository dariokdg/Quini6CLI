using Quini6CLI.Helpers;
using System;
using System.Linq;

namespace Quini6CLI.Core
{
    class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Ticket Quini6Ticket { get; set; }
        private decimal PrizeMoney = 0;
        private decimal MoneySpent = 0;

        public Player(string Name, int Age, string City, string Address, string PhoneNumber, Ticket Quini6Ticket)
        {
            this.Name = Name;
            this.Age = CheckAge(Age);
            this.City = City;
            this.Address = Address;
            this.PhoneNumber = CheckPhoneNumber(PhoneNumber);
            this.Quini6Ticket = Quini6Ticket;
            MoneySpent = Quini6Ticket.Cost;
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

        public decimal CheckWinnings()
        {
            return PrizeMoney;
        }

        public GameSpends CheckSpends()
        {
            return new GameSpends(MoneySpent, Quini6Ticket.Games);
        }
    }
}
