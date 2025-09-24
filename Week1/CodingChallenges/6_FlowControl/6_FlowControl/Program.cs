using System;

namespace _6_FlowControl
{
    public class Program
    {
        // Global variables for Register/Login
        private static string registeredUsername;
        private static string registeredPassword;

        static void Main(string[] args)
        {
            // Example flow (you can adjust as needed for testing)
            int temp = GetValidTemperature();
            GiveActivityAdvice(temp);
            GetTemperatureTernary(temp);

            Register();
            bool loggedIn = Login();
            Console.WriteLine(loggedIn ? "Login successful!" : "Login failed.");
        }

        /// <summary>
        /// This method gets a valid temperature between -40 and 135 inclusive from the user
        /// and returns the valid int. 
        /// </summary>
        public static int GetValidTemperature()
        {
            int temp;
            bool isValid = false;

            do
            {
                Console.Write("Enter a temperature between -40 and 135: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out temp) && temp >= -40 && temp <= 135)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            while (!isValid);

            return temp;
        }

        /// <summary>
        /// Prints outdoor activity advice and temperature opinion based on ranges.
        /// </summary>
        public static void GiveActivityAdvice(int temp)
        {
            if (temp < -20)
                Console.WriteLine("cold cold cold");
            else if (temp < 0)
                Console.WriteLine("cold cold");
            else if (temp < 20)
                Console.WriteLine("cold");
            else if (temp < 40)
                Console.WriteLine("not too cold");
            else if (temp < 60)
                Console.WriteLine("feels like Autumn");
            else if (temp < 80)
                Console.WriteLine("perfect temperature");
            else if (temp < 90)
                Console.WriteLine("love it");
            else if (temp < 100)
                Console.WriteLine("hot hot hot");
            else if (temp <= 135)
                Console.WriteLine("Feels like hell");
        }

        /// <summary>
        /// Gets a username and password from the user and stores them in global variables.
        /// </summary>
        public static void Register()
        {
            Console.Write("Enter a username: ");
            registeredUsername = Console.ReadLine();

            Console.Write("Enter a password: ");
            registeredPassword = Console.ReadLine();

            Console.WriteLine("Registration successful.");
        }

        /// <summary>
        /// Prompts user to log in until username & password match registration.
        /// </summary>
        public static bool Login()
        {
            while (true)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                if (username == registeredUsername && password == registeredPassword)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Incorrect. Try again.");
                }
            }
        }

        /// <summary>
        /// Uses ternary to print advice based on temperature.
        /// </summary>
        public static void GetTemperatureTernary(int temp)
        {
            string message = temp <= 42
                ? $"{temp} is too cold!"
                : (temp <= 78
                    ? $"{temp} is an ok temperature"
                    : $"{temp} is too hot!");

            Console.WriteLine(message);
        }
    }
}

