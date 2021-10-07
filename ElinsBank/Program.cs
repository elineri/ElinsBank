using System;

namespace ElinsBank
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isLoggedIn = false;
            int loginAttempts = 3;

            Console.WriteLine("Välkommen till Elins bank!\nAnge användarnamn (förnamn.efternamn) samt en fyrsiffrig pinkod för att logga in.");

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

            // User Accounts
            string[,] userAccounts = new string[5, 6];

            // User 1
            userAccounts[0, 0] = "elin.ericstam"; // Set username
            userAccounts[0, 1] = "Huvudkonto"; // Set first account name
            userAccounts[0, 2] = "20000,00"; // Set first account balance
            userAccounts[0, 3] = "Sparkonto"; // Set second account name
            userAccounts[0, 4] = "30000,00"; // Set second account balance

            // User 2
            userAccounts[1, 0] = "anas.alhussain";
            userAccounts[1, 1] = "Huvudkonto";
            userAccounts[1, 2] = "40000,00";
            userAccounts[1, 3] = "Sparkonto";
            userAccounts[1, 4] = "130000,00";

            // User 3
            userAccounts[2, 0] = "tobias.landen";
            userAccounts[2, 1] = "Huvudkonto";
            userAccounts[2, 2] = "30000,00";
            userAccounts[2, 3] = "Sparkonto";
            userAccounts[2, 4] = "90000,00";

            // User 4
            userAccounts[3, 0] = "malin.claesson";
            userAccounts[3, 1] = "Huvudkonto";
            userAccounts[3, 2] = "10000,00";
            userAccounts[3, 3] = "Sparkonto";
            userAccounts[3, 4] = "40000,00";

            // User 5
            userAccounts[4, 0] = "fredrik.strandberg";
            userAccounts[4, 1] = "Huvudkonto";
            userAccounts[4, 2] = "50000,00";
            userAccounts[4, 3] = "Sparkonto";
            userAccounts[4, 4] = "65000,00";

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
                Menu(userAccounts, userID);
            }
        }

        public static void Menu(string[,] userAccounts, int userID)
        {
            bool run = true;

            while (run)
            {
                // Prints menu options
                Console.WriteLine("Välj vad du vill göra\n");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("1. Se dina konton och saldo");
                Console.WriteLine("2. Överföring mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");
                Console.ForegroundColor = ConsoleColor.Gray;

                int menuSelection = Int32.Parse(Console.ReadLine());

                switch (menuSelection)
                {
                    case 1: // Se konton och saldo
                        CheckAccounts(userAccounts, userID);
                        BackToMenu();
                        break;
                    case 2: // Överföring mellan konton
                        AccountsTransfer(userAccounts, userID);
                        BackToMenu();
                        break;
                    case 3: // Ta ut pengar
                        AccountWithdrawal(userAccounts, userID);
                        BackToMenu();
                        break;
                    case 4: // Logga ut
                        run = false; // TODO Fixa utloggning
                        break;
                    default:
                        Console.WriteLine("Ogiltligt val. Vänligen klicka enter och välj igen.");
                        Console.ReadLine(); // TODO Fixa enter
                        Console.Clear();
                        break;
                }
            }
        }
        public static void BackToMenu() // Gå tillbaka till huvudmenyn
        {
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadLine(); // TODO Fixa enter
            Console.Clear();
        }

        public static void CheckAccounts(string[,] userAccounts, int userID)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Konton för {userAccounts[userID,0]}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 1; i < userAccounts.GetLength(0); i++)
            {
                if (!(i % 2 == 0))
                {
                    Console.Write(userAccounts[userID, i] + ": \t");
                }
                else
                {
                    Console.WriteLine(userAccounts[userID, i]);
                }
            }
        }

        public static void AccountsTransfer(string[,] userAccounts, int userID)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Överföring mellan konton.\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // Prints accounts and balance
            for (int i = 1; i < userAccounts.GetLength(0); i++)
            {
                if (!(i % 2 == 0))
                {
                    Console.Write(i + ". " + userAccounts[userID, i] + ": \t"); // TODO Fixa nummer för alternativ
                }
                else
                {
                    Console.WriteLine(userAccounts[userID, i]);
                }
            }

            // User input account transfer From
            Console.Write("\nAnge nummer för det konto du vill föra över ifrån: ");
            int fromAccount = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < userAccounts.GetLength(0); i++)
            {
                if (fromAccount == i && fromAccount % 2 == 0)
                {
                    Console.WriteLine($"Du kan föra över totalt {userAccounts[userID, i]} kr från {userAccounts[userID, i + 1]}");
                }
                else if (fromAccount == i && !(fromAccount % 2 == 0))
                {
                    Console.WriteLine($"Du kan föra över totalt {userAccounts[userID, i + 1]} kr från {userAccounts[userID, i]}");
                }
            }

            // Convert balance from strng to decimal for the From account
            decimal balanceAccountFrom = decimal.Parse(userAccounts[userID, fromAccount + 1]);

            // User input account transfer To
            Console.Write("\nAnge nummer för det konto du vill föra över till: ");
            int toAccount = Int32.Parse(Console.ReadLine());

            // Convert balance from string to decimal for the To account.
            decimal balanceAccountTo = decimal.Parse(userAccounts[userID, fromAccount + 1]);

            // User input amount to transfer
            Console.Write("\nAnge summa att föra över: ");
            decimal transfer = decimal.Parse(Console.ReadLine());

            // Add and withdraw money to accounts
            balanceAccountFrom = balanceAccountFrom - transfer;
            balanceAccountTo = balanceAccountTo + transfer;

            // Set new balance to accounts
            string newBalanceFrom = balanceAccountFrom.ToString();
            userAccounts[userID, fromAccount + 1] = newBalanceFrom;

            string newBalanceTo = balanceAccountTo.ToString();
            userAccounts[userID, toAccount + 1] = newBalanceTo;

            Console.WriteLine($"\nDu har fört över {transfer} kr från {userAccounts[userID, fromAccount]} till {userAccounts[userID, toAccount]}");
        }

        public static void AccountWithdrawal(string[,] userAccounts, int userID)
        {

        }
    }
}
