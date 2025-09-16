using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== String Manipulation Challenge ===\n");

            // Test StringToUpper
            Console.Write("Enter a string to convert to uppercase: ");
            string userInput = Console.ReadLine();
            string upperResult = StringToUpper(userInput);
            Console.WriteLine($"Uppercase result: {upperResult}\n");

            // Test StringToLower
            Console.Write("Enter a string to convert to lowercase: ");
            string lowerInput = Console.ReadLine();
            string lowerResult = StringToLower(lowerInput);
            Console.WriteLine($"Lowercase result: {lowerResult}\n");

            // Test StringTrim
            Console.Write("Enter a string with whitespace to trim: ");
            string trimInput = Console.ReadLine();
            string trimResult = StringTrim(trimInput);
            Console.WriteLine($"Trimmed result: '{trimResult}'\n");

            // Test StringSubstring
            Console.Write("Enter a string for substring extraction: ");
            string substringInput = Console.ReadLine();
            Console.Write("Enter starting index: ");
            int startIndex = int.Parse(Console.ReadLine());
            Console.Write("Enter length: ");
            int length = int.Parse(Console.ReadLine());
            
            try
            {
                string substringResult = StringSubstring(substringInput, startIndex, length);
                Console.WriteLine($"Substring result: '{substringResult}'\n");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid substring parameters!\n");
            }

            // Test SearchChar
            Console.Write("Enter a string to search in: ");
            string searchInput = Console.ReadLine();
            Console.Write("Enter a character to search for: ");
            string charInput = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(charInput))
            {
                char searchChar = charInput.Trim()[0]; // Use Trim as hinted
                int charIndex = SearchChar(searchInput, searchChar);
                if (charIndex >= 0)
                    Console.WriteLine($"Character '{searchChar}' found at index: {charIndex}\n");
                else
                    Console.WriteLine($"Character '{searchChar}' not found!\n");
            }

            // Test ConcatNames
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            string fullName = ConcatNames(firstName, lastName);
            Console.WriteLine($"Full name: {fullName}\n");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// This method has one string parameter and will: 
        /// 1) change the string to all upper case and 
        /// 2) return the new string.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public static string StringToUpper(string myString)
        {
            return myString.ToUpper();
        }

        /// <summary>
        /// This method has one string parameter and will:
        /// 1) change the string to all lower case,
        /// 2) return the new string into the 'lowerCaseString' variable
        /// </summary>
        /// <param name="usersString"></param>
        /// <returns></returns>       
        public static string StringToLower(string usersString)
        {
            return usersString.ToLower();
        }

        /// <summary>
        /// This method has one string parameter and will:
        /// 1) remove whitespace from the beginning and end of the string,
        /// 2) return the trimmed string.
        /// </summary>
        /// <param name="usersStringWithWhiteSpace"></param>
        /// <returns></returns>
        public static string StringTrim(string usersStringWithWhiteSpace)
        {
            return usersStringWithWhiteSpace.Trim();
        }

        /// <summary>
        /// This method has three parameters, one string and two integers. It will:
        /// 1) get the substring based on the first integer element and the length 
        /// of the substring desired.
        /// 2) return the substring.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="firstElement"></param>
        /// <param name="lengthOfSubsring"></param>
        /// <returns></returns>
        public static string StringSubstring(string x, int firstElement, int lengthOfSubsring)
        {
            return x.Substring(firstElement, lengthOfSubsring);
        }

        /// <summary>
        /// This method has two parameters, one string and one char. It will:
        /// 1) search the string parameter for first occurrance of the char parameter and
        /// 2) return the index of the char.
        /// HINT: Think about how StringTrim() (above) would be useful in this situation
        /// when getting the char from the user. 
        /// </summary>
        /// <param name="userInputString"></param>
        /// <param name="charUserWants"></param>
        /// <returns></returns>
        public static int SearchChar(string userInputString, char charUserWants)
        {
            return userInputString.IndexOf(charUserWants);
        }

        /// <summary>
        /// This method has two string parameters. It will:
        /// 1) concatenate the two strings with a space between them.
        /// 2) return the new string.
        /// HINT: You will need to get the users first and last name in the 
        /// main method and send them as arguments.
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        public static string ConcatNames(string fName, string lName)
        {
            return $"{fName} {lName}";
        }
    }
}