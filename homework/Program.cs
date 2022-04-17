using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework
{
    public class Card
    {
        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVV { get; set; }
        //public DateTime ExpireDate { get; set; }
        public decimal Balance { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Card CreditCard { get; set; }
    }

    internal class Program
    {
        static void Work()
        {
            User[] user = { new User { Name = "tural", Surname = "novruzlu",
                CreditCard = { PIN = "1234", PAN = "12345678", CVV = "123", Balance = 5555} },
                new User { Name = "samir", Surname = "mammadov",
                CreditCard = { PIN = "24682468", PAN = "2468", CVV = "248", Balance = 4444} },
            };

            string pin = Pin();
            bool check = int.TryParse(findPin(user, pin), out int index);
            if(!check)
            {
                Console.Clear();
                Console.WriteLine("Don't find!");
                Thread.Sleep(1111);
                Console.Clear();
                findPin(user, pin);
            }
            Opeartion(user, index);
        }

        static void Opeartion(User[] user, int index)
        {
            Console.WriteLine("Welcome" + user[index].Name + user[index].Surname);
            Console.WriteLine("1-Balance\n2-Cash");
            string cho = Console.ReadLine();
            if (!int.TryParse(cho, out int choice))
            {
                Console.Clear();
                Console.WriteLine("Wrong Entry!");
                Thread.Sleep(1111);
                Console.Clear();
                Opeartion(user, index);
            }
            if (choice == 1)
            {
                Console.WriteLine("Balance: " + user[index].CreditCard.Balance.ToString());
            }
            else if(choice == 2)
            {
                withdrawMoney(user,index);
            }
            else if (choice == 3)
            {
                transfer(user, index);
            }
        }

        static string Pin()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\tWelcome");
            Console.WriteLine("Enter the PIN: ");
            string pin = Console.ReadLine();
            if (checkPin(pin)) ;
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong Enter!");
                Thread.Sleep(1111);
                Console.Clear();
                Pin();
            }
            return pin;
        }

        static bool checkPin(string pin)
        {
            Int32.TryParse(pin, out int value);
            if (pin.Length == 4 && value != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string findPin(User[] user, string pin)
        {
            bool found = false;
            int index = 0;

            for (int i = 0; i < user.Length; i++)
            {
                if (user[i].CreditCard.PIN == pin)
                {
                    found = true;
                    index = i;
                }
                else break;
            }

            if (found) return index.ToString();
            else return "DO NOT FIND";
        }

        static void withdrawMoney(User[] user, int index)
        {
            Console.Clear();
            Console.WriteLine("Enter how much you wanna withdraw: ");
            string wdrw = Console.ReadLine();
            if (int.TryParse(wdrw, out int withdraw))
            {
                if (user[index].CreditCard.Balance >= withdraw)
                {
                    user[index].CreditCard.Balance = user[index].CreditCard.Balance - withdraw;
                    Console.WriteLine("Take your money..\nNow your balance is: " + user[index].CreditCard.Balance);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You don't have enough money, Re-Enter please..");
                    Thread.Sleep(1111);
                    Console.Clear();
                    withdrawMoney(user, index);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong Enter!");
                Thread.Sleep(1111);
                Console.Clear();
                withdrawMoney(user,index);
            }
        }

        static void transfer(User[] user, int index)
        {
            Console.Clear();
            Console.WriteLine("Enter target PIN: ");
            string pin = Console.ReadLine();
            if (checkPin(pin)) ;
            else
            {
                Console.Clear();
                Console.WriteLine("Wrong Enter!");
                Thread.Sleep(1111);
                Console.Clear();
                Pin();
            }
            
        }

        static void Main(string[] args)
        {
            Work();

            Console.ReadKey();
        }
    }
}
