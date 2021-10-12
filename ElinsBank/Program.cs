using System;
using System.Threading;

namespace ElinsBank
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isLoggedIn = false;
            bool run = true;

            string[] user = new string[5];
            string[] userpin = new string[5];
            string userName;
            int userID = 0;

            // User Accounts
            string[,] userAccounts = new string[5, 6];

            // User 1
            userAccounts[0, 0] = "elin.ericstam"; // Set username
            userAccounts[0, 1] = "Huvudkonto"; // Set first account name
            userAccounts[0, 2] = "20234,50"; // Set first account balance
            userAccounts[0, 3] = "Sparkonto"; // Set second account name
            userAccounts[0, 4] = "30035,00"; // Set second account balance

            // User 2
            userAccounts[1, 0] = "anas.alhussain"; // Set username
            userAccounts[1, 1] = "Huvudkonto"; // Set first account name
            userAccounts[1, 2] = "40341,00"; // Set first account balance
            userAccounts[1, 3] = "Sparkonto"; // Set second account name
            userAccounts[1, 4] = "130160,25"; // Set second account balance

            // User 3
            userAccounts[2, 0] = "tobias.landen"; // Set username
            userAccounts[2, 1] = "Huvudkonto"; // Set first account name
            userAccounts[2, 2] = "32198,50"; // Set first account balance
            userAccounts[2, 3] = "Sparkonto"; // Set second account name
            userAccounts[2, 4] = "90200,00"; // Set second account balance

            // User 4
            userAccounts[3, 0] = "malin.claesson"; // Set username
            userAccounts[3, 1] = "Huvudkonto"; // Set first account name
            userAccounts[3, 2] = "10112,25"; // Set first account balance
            userAccounts[3, 3] = "Sparkonto"; // Set second account name
            userAccounts[3, 4] = "40000,00"; // Set second account balance

            // User 5
            userAccounts[4, 0] = "fredrik.strandberg"; // Set username
            userAccounts[4, 1] = "Huvudkonto"; // Set first account name
            userAccounts[4, 2] = "50000,00"; // Set first account balance
            userAccounts[4, 3] = "Sparkonto"; // Set second account name
            userAccounts[4, 4] = "65000,00"; // Set second account balance

            while (run)
            {
                LogIn(out isLoggedIn, out userID, out user, out userpin, out userName);

                if (isLoggedIn)
                {
                    Menu(userAccounts, userID, user, userpin, userName, out isLoggedIn);
                }
                else
                {
                    run = false; // If the user hasn't logged in within 3 attempts the program shuts down.
                }
            }
        }

        public static void LogIn(out bool isLoggedIn, out int userID, out string[] users, out string[] userpin, out string userName) // Welcome message and login
        {
            isLoggedIn = false;
            int loginAttempts = 3;

            // Users
            users = new string[5];
            users[0] = "elin.ericstam";
            users[1] = "anas.alhussain";
            users[2] = "tobias.landen";
            users[3] = "malin.claesson";
            users[4] = "fredrik.strandberg";

            // User passwords
            userpin = new string[5];
            userpin[0] = "1234";
            userpin[1] = "2345";
            userpin[2] = "3456";
            userpin[3] = "4567";
            userpin[4] = "5678";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t***** Välkommen till Elins bank! *****");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Ange användarnamn(förnamn.efternamn) samt en fyrsiffrig pinkod för att logga in.");
            
            Console.Write("\nAnvändarnamn: ");
            userName = Console.ReadLine().ToLower(); // Input username
            bool userFound = false;

            // Checks if the user exists and if not asks for input again
            do
            {
                for (int i = 0; i < users.GetLength(0); i++)
                {
                    if (users[i] == userName)
                    {
                        userFound = true;
                    }
                }

                if (userFound == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Användaren kan inte hittas. Vänligen försök igen.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("\nAnvändarnamn: ");
                    userName = Console.ReadLine().ToLower();
                }
            } while (userFound == false);

            userID = Array.IndexOf(users, userName); // Matches username with correct password

            while (loginAttempts > 0 && isLoggedIn == false)
            {
                Console.Write("Pinkod: ");
                string pin = Console.ReadLine();

                loginAttempts--;

                if (pin == userpin[userID] && userName == users[userID])
                {
                    isLoggedIn = true;
                    Console.Clear();
                    Console.WriteLine("Du är nu inloggad som {0}!\n", userName);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel pinkod. Du har {0} antal försök kvar\n", loginAttempts);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public static void Menu(string[,] userAccounts, int userID, string[] user, string[] userpin, string userName, out bool isLoggedIn) // Menu when logged in
        {
            bool run = true;
            isLoggedIn = true;

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
                    case 1: // View accounts and balance
                        CheckAccounts(userAccounts, userID);
                        BackToMenu();
                        break;
                    case 2: // Transfer between accounts
                        AccountsTransfer(userAccounts, userID);
                        BackToMenu();
                        break;
                    case 3: // Withdraw money
                        AccountWithdrawal(userAccounts, userID, user, userpin, userName);
                        BackToMenu();
                        break;
                    case 4: // Log out
                        isLoggedIn = false;
                        Console.Clear();
                        Console.WriteLine("Du är nu utloggad.\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Ogiltligt val. Vänligen klicka enter och välj igen.");
                        Console.ReadKey(); // TODO Fixa enter
                        Console.Clear();
                        break;
                }
            }
        }
        
        public static void CheckAccounts(string[,] userAccounts, int userID) // View accounts and balance
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Konton för {userAccounts[userID,0]}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            int accountNum = 1;

            for (int i = 1; i < userAccounts.GetLength(0); i++)
            {
                if (!(i % 2 == 0))
                {
                    Console.Write(accountNum + ". " + userAccounts[userID, i] + ": \t");
                    accountNum++;
                }
                else
                {
                    Console.WriteLine(userAccounts[userID, i]);
                }
            }
        }

        public static void AccountsTransfer(string[,] userAccounts, int userID) // Transfer between accounts
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Överföring mellan konton.\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            int accountNum = 1; // Set

            // Prints accounts and balance
            for (int i = 1; i < userAccounts.GetLength(0); i++)
            {
                if (!(i % 2 == 0))
                {
                    Console.Write(accountNum + ". " + userAccounts[userID, i] + ": \t"); // TODO Fixa nummer för alternativ
                    accountNum++;
                }
                else
                {
                    Console.WriteLine(userAccounts[userID, i]);
                }
            }

            int fromAccount;
            bool error = false;

            do
            {
                // User input account transfer From
                Console.Write("\nAnge nummer för det konto du vill föra över ifrån: ");
                fromAccount = Int32.Parse(Console.ReadLine());

                if (fromAccount < 1 || fromAccount > accountNum)
                {
                    error = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltligt val.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    error = false;
                }

            } while (error == true);

            if (fromAccount > 1)
                fromAccount++;

            for (int i = 0; i < userAccounts.GetLength(0); i++)
            {
                if (fromAccount == i && !(fromAccount % 2 == 0))
                {
                    Console.WriteLine($"Du kan föra över totalt {userAccounts[userID, i + 1]} kr från {userAccounts[userID, i]}");
                }
                else if (fromAccount == i && fromAccount % 2 == 0)
                {
                    Console.WriteLine($"Du kan föra över totalt {userAccounts[userID, i + 2]} kr från {userAccounts[userID, i + 1]}");
                }
            }

            // Convert balance from string to decimal for the From account
            decimal balanceAccountFrom = decimal.Parse(userAccounts[userID, fromAccount + 1]);

            
            int toAccount;

            do
            {
                // User input account transfer To
                Console.Write("\nAnge nummer för det konto du vill föra över till: ");
                toAccount = Int32.Parse(Console.ReadLine());

                if (toAccount < 1 || toAccount > accountNum)
                {
                    error = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltligt val.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    error = false;
                }
            } while (error == true);

            if (toAccount > 1)
                    toAccount++;

            if (toAccount == fromAccount || toAccount + 1 == fromAccount + 1)
            {   Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Det går inte att föra över pengar till samma konto");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                // Convert balance from string to decimal for the To account.
                decimal balanceAccountTo = decimal.Parse(userAccounts[userID, toAccount + 1]);

                // User input amount to transfer
                Console.Write("\nAnge summa att föra över: ");
                decimal transferAmount = decimal.Parse(Console.ReadLine());

                if (transferAmount <= balanceAccountFrom)
                {
                    // Add and withdraw money to accounts
                    balanceAccountFrom = balanceAccountFrom - transferAmount;
                    balanceAccountTo = balanceAccountTo + transferAmount;

                    // Set new balance to accounts
                    string newBalanceFrom = balanceAccountFrom.ToString();
                    userAccounts[userID, fromAccount + 1] = newBalanceFrom;

                    string newBalanceTo = balanceAccountTo.ToString();
                    userAccounts[userID, toAccount + 1] = newBalanceTo;

                    Console.WriteLine("\n\t**********************");
                    Console.WriteLine($"\nDu har fört över {transferAmount} kr från {userAccounts[userID, fromAccount]} till {userAccounts[userID, toAccount]}.\n\nNytt saldo:");

                    Console.WriteLine(userAccounts[userID, fromAccount] + ":\t" + userAccounts[userID, fromAccount + 1]);
                    Console.WriteLine(userAccounts[userID, toAccount] + ":\t" + userAccounts[userID, toAccount + 1]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nSumman är för stor för föra över. Kontot har otillräckligt saldo.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public static void AccountWithdrawal(string[,] userAccounts, int userID, string[] user, string[] userpin, string userName) // Withdrawal fron accounts
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Uttag av pengar.\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            int accountNum = 1;

            // Prints accounts and balance
            for (int i = 1; i < userAccounts.GetLength(0); i++)
            {
                if (!(i % 2 == 0))
                {
                    Console.Write(accountNum + ". " + userAccounts[userID, i] + ": \t"); // TODO Fixa nummer för alternativ
                    accountNum++;
                }
                else
                {
                    Console.WriteLine(userAccounts[userID, i]);
                }
            }

            int fromAccount;
            bool error = false;

            do
            {
                // User input account transfer From
                Console.Write("\nAnge nummer för det konto du vill ta ut pengar ifrån: ");
                fromAccount = Int32.Parse(Console.ReadLine());

                if (fromAccount < 1 || fromAccount > accountNum)
                {
                    error = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltligt val.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    error = false;
                }

            } while (error == true);

            if (fromAccount > 1)
            {
                fromAccount++;
            }

            for (int i = 1; i < userAccounts.GetLength(0); i++)
            {
                if (fromAccount == i && !(fromAccount % 2 == 0))
                {
                    Console.WriteLine($"Du kan ta ut totalt {userAccounts[userID, i + 1]} kr från {userAccounts[userID, i]}");
                }
                else if (fromAccount == i && (fromAccount % 2 == 0))
                {
                    Console.WriteLine($"Du kan ta ut totalt {userAccounts[userID, i + 2]} kr från {userAccounts[userID, i + 1]}");
                }
            }

            // User input withdrawal amount
            Console.Write("\nHur mycket vill du ta ut: ");
            decimal withdrawal = decimal.Parse(Console.ReadLine());

            // Converts balance from string to decimal for the From account
            decimal balanceAccountFrom = decimal.Parse(userAccounts[userID, fromAccount + 1]);

            while (withdrawal > balanceAccountFrom)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Summan är för stor för att ta ut. Kontot har otillräckligt saldo.");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("\nHur mycket vill du ta ut: ");
                withdrawal = decimal.Parse(Console.ReadLine());
            }

            bool pinCorrect = false;
            int pinAttempts = 3;

            while (!pinCorrect && pinAttempts > 0)
            {
                // User input for password / pincode
                Console.Write("Ange pinkod: ");
                string pin = Console.ReadLine();

                pinAttempts--;

                if (pin == userpin[userID] && userName == user[userID] && withdrawal <= balanceAccountFrom) // If pin correct and sufficient funds
                {
                    pinCorrect = true;

                    // Withdraw and set new account balance
                    balanceAccountFrom = balanceAccountFrom - withdrawal;
                    string newBalanceFrom = balanceAccountFrom.ToString();
                    userAccounts[userID, fromAccount + 1] = newBalanceFrom;

                    // Print new balance
                    Console.WriteLine("\n\t**********************");
                    Console.WriteLine($"\nDu har tagit ut {withdrawal} kr från {userAccounts[userID, fromAccount]}");
                    Console.WriteLine("Nytt saldo är: {0} kr", balanceAccountFrom);
                }
                else if (!(pin == userpin[userID] && userName == user[userID])) // If pin doesn't match with username
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFelaktig pinkod. Du har {tries} försök kvar", pinAttempts);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public static void BackToMenu() // Go back to Main menu
        {
            Console.WriteLine("\nKlicka enter för att komma till huvudmenyn");
            Console.ReadKey(); // TODO Fixa enter
            Console.Clear();
        }
    }
}
