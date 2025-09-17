



using System;

namespace _6_FlowControl
{
    public class Program
    {
        // Global variables for storing registration data
        private static string registeredUsername = "";
        private static string registeredPassword = "";

        static void Main(string[] args)
        {
            Console.WriteLine("=== Flow Control Challenge Demo ===\n");
            
            // Demo the temperature methods
            Console.WriteLine("1. Getting valid temperature:");
            int temp = GetValidTemperature();
            Console.WriteLine($"You entered: {temp}°F\n");
            
            Console.WriteLine("2. Activity advice:");
            GiveActivityAdvice(temp);
            Console.WriteLine("\n");
            
            Console.WriteLine("3. Temperature ternary advice:");
            GetTemperatureTernary(temp);
            Console.WriteLine("\n");
            
            // Demo the registration/login system
            Console.WriteLine("4. Registration and Login:");
            Register();
            bool loginSuccess = Login();
            Console.WriteLine($"Login successful: {loginSuccess}");
        }

        /// <summary>
        /// This method gets a valid temperature between -40 and 135 inclusive from the user
        /// and returns the valid int.
        /// </summary>
        /// <returns></returns>
        public static int GetValidTemperature()
        {
            int temperature;
            bool isValidInput;

            do
            {
                Console.Write("Enter a temperature between -40 and 135 (Fahrenheit): ");
                string input = Console.ReadLine();
                
                isValidInput = int.TryParse(input, out temperature);
                
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                else if (temperature < -40 || temperature > 135)
                {
                    Console.WriteLine("Temperature must be between -40 and 135 degrees Fahrenheit.");
                    isValidInput = false;
                }
            } 
            while (!isValidInput);

            return temperature;
        }

        /// <summary>
        /// This method has one int parameter
        /// It prints outdoor activity advice and temperature opinion to the console
        /// based on 20 degree increments starting at -20 and ending at 135
        /// </summary>
        /// <param name="temp"></param>
        public static void GiveActivityAdvice(int temp)
        {
            if (temp < -20)
            {
                Console.Write("hella cold");
            }
            else if (temp >= -20 && temp < 0)
            {
                Console.Write("pretty cold");
            }
            else if (temp >= 0 && temp < 20)
            {
                Console.Write("cold");
            }
            else if (temp >= 20 && temp < 40)
            {
                Console.Write("thawed out");
            }
            else if (temp >= 40 && temp < 60)
            {
                Console.Write("feels like Autumn");
            }
            else if (temp >= 60 && temp < 80)
            {
                Console.Write("perfect outdoor workout temperature");
            }
            else if (temp >= 80 && temp < 90)
            {
                Console.Write("niiice");
            }
            else if (temp >= 90 && temp < 100)
            {
                Console.Write("hella hot");
            }
            else if (temp >= 100 && temp <= 135)
            {
                Console.Write("hottest");
            }
        }

        /// <summary>
        /// This method gets a username and password from the user
        /// and stores that data in the global variables of the
        /// names in the method.
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("=== Registration ===");
            
            Console.Write("Enter a username: ");
            registeredUsername = Console.ReadLine();
            
            Console.Write("Enter a password: ");
            registeredPassword = Console.ReadLine();
            
            Console.WriteLine("Registration successful!");
        }

        /// <summary>
        /// This method gets username and password from the user and
        /// compares them with the username and password names provided in Register().
        /// If the password and username match, the method returns true.
        /// If they do not match, the user is reprompted for the username and password
        /// until the exact matches are inputted.
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            Console.WriteLine("=== Login ===");
            
            string enteredUsername, enteredPassword;
            
            do
            {
                Console.Write("Enter username: ");
                enteredUsername = Console.ReadLine();
                
                Console.Write("Enter password: ");
                enteredPassword = Console.ReadLine();
                
                if (enteredUsername != registeredUsername || enteredPassword != registeredPassword)
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }
            while (enteredUsername != registeredUsername || enteredPassword != registeredPassword);
            
            Console.WriteLine("Login successful!");
            return true;
        }

        /// <summary>
        /// This method has one int parameter.
        /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
        /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
        /// or > 78, Console.WriteLine($"{temp} is too hot!");
        /// For each temperature range, a different advice is given.
        /// </summary>
        /// <param name="temp"></param>
        public static void GetTemperatureTernary(int temp)
        {
            string message = temp <= 42 ? $"{temp} is too cold!" :
                           temp >= 43 && temp <= 78 ? $"{temp} is an ok temperature" :
                           $"{temp} is too hot!";
            
            Console.WriteLine(message);
        }
    }//EoP
}//EoN