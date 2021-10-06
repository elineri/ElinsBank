using System;

namespace ElinsBank
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isLoggedIn = false;
            int loginAttempts = 3;

            Console.WriteLine("Välkommen till Elins bank!");

            // Users
            string[] user = new string[5];
            user[0] = "elin.ericstam";
            user[1] = "anas.alhussain";
            user[2] = "tobias.landen";
            user[3] = "malin.claesson";
            user[4] = "fredrik.strandberg";

            // User passwords
            string[] userpin = new string[5];
            userpin[0] = "1234";
            userpin[1] = "1234";
            userpin[2] = "1234";
            userpin[3] = "1234";
            userpin[4] = "1234";

            Console.Write("\nAnvändarnamn: "); //TODO Trycatch
            string userName = Console.ReadLine().ToLower();

            int userID = Array.IndexOf(user, userName); // Matches username with correct password

            while (loginAttempts > 0 && isLoggedIn == false)
            {
                Console.Write("Pinkod: ");
                string pin = Console.ReadLine();

                loginAttempts--;

                if (pin == userpin[userID] && userName == user[userID])
                {
                    isLoggedIn = true;
                    Console.Clear();
                    Console.WriteLine("Du är nu inloggad som {0}!\n", userName);
                }
                else
                {
                    Console.WriteLine("Fel pinkod. Du har {0} antal försök kvar\n", loginAttempts);
                }
            }

            while (isLoggedIn == true)
            {
                Menu();
            }
        }

        public static void Menu()
        {

        }
    }
}
