using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            do
            {
                Console.Clear();
                Console.WriteLine("The number of users: " + UserService.getNumberOfUsers());
                if (!AuthenticationService.isAuthenticated())
                {
                    User authernticatedUser = AuthenticationService.getAuthenticatedUser();
                    Console.WriteLine("1. Login");
                    Console.WriteLine("2. Register");
                    Console.WriteLine("3. Quit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Username: ");
                            string LoginUsername = Console.ReadLine();
                            Console.Write("Password: ");
                            string LoginPassword = Console.ReadLine();
                            if (AuthenticationService.authenticate(LoginUsername, LoginPassword))
                            {
                                Console.WriteLine("Login Success! ");
                            }
                            else
                            {
                                Console.WriteLine("The username or password was incorrect or not registered.");
                            }
                            break;
                        case "2":
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            UserService.registerNewUser(username, password);
                            break;
                        case "3":
                            finished = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    User authenticatedUser = AuthenticationService.getAuthenticatedUser();
                    Console.WriteLine("Hello, " + authenticatedUser.GetUsername() + "!");
                    Console.WriteLine("1. List Data");
                    Console.WriteLine("2. Record New Data");
                    Console.WriteLine("3. Log Out");
                    Console.WriteLine("4. Quit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Dictionary<string, string> data = UserDataService.getAllDataForUser(AuthenticationService.getAuthenticatedUser().GetID());
                            foreach (KeyValuePair<string, string> item in data)
                            {
                                Console.WriteLine(item.Key + ": " + item.Value);
                            }
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.WriteLine("Data Type: ");
                            string dataKey = Console.ReadLine();
                            Console.WriteLine("Data Value: ");
                            string dataValue = Console.ReadLine();
                            UserDataService.storeUserData(AuthenticationService.getAuthenticatedUser().GetID(), dataKey, dataValue);
                            break;
                        case "3":
                            AuthenticationService.logout();
                            Console.WriteLine("Logged out. Adios muchacho.");
                            break;
                        case "4":
                            finished = true;
                            break;
                    
                    }
                }
            } while (!finished);
        }
    }
}
