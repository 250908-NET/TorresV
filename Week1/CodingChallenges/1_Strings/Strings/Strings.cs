using System;

namespace StringManipulationChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            * Implement the required code here and within the methods below.
            * When you call a method, you call it with arguments. The args values are held in a variable.
            */
            
            Console.WriteLine("=== String Manipulation Challenge ===\n");
            
            // Test StringToUpper
            string testString = "hello world";
            string upperResult = StringToUpper(testString);
            Console.WriteLine($"Original: '{testString}' -> Upper: '{upperResult}'");
            
            // Test StringToLower
            string upperString = "HELLO WORLD";
            string lowerResult = StringToLower(upperString);
            Console.WriteLine($"Original: '{upperString}' -> Lower: '{lowerResult}'");
            
            // Test StringTrim
            string stringWithWhitespace = "   hello world   ";
            string trimmedResult = StringTrim(stringWithWhitespace);
            Console.WriteLine($"Original: '{stringWithWhitespace}' -> Trimmed: '{trimmedResult}'");
            
            // Test StringSubstring
            string fullString = "Hello World Programming";
            string substringResult = StringSubstring(fullString, 6, 5); // Gets "World"
            Console.WriteLine($"Substring of '{fullString}' starting at index 6, length 5: '{substringResult}'");
            
            // Test SearchChar
            string searchString = "Programming";
            char searchChar = 'g';
            int charIndex = SearchChar(searchString, searchChar);
            Console.WriteLine($"First occurrence of '{searchChar}' in '{searchString}' is at index: {charIndex}");
            
            // Test ConcatNames
            string firstName = "John";
            string lastName = "Doe";
            string fullName = ConcatNames(firstName, lastName);
            Console.WriteLine($"Concatenated name: '{fullName}'");
            
            Console.WriteLine("\nPress any key to exit...");
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
        /// 1) trim the whitespace from before and after the string, and
        /// 2) return the new string.
        /// HINT: When getting input from the user (you are the user), try inputting "   a string with whitespace   " to see how the whitespace is trimmed.
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
        /// <param name="lengthOfSubstring"></param>
        /// <returns></returns>
        public static string StringSubstring(string x, int firstElement, int lengthOfSubstring)
        {
            return x.Substring(firstElement, lengthOfSubstring);
        }

        /// <summary>
        /// This method has two parameters, one string and one char. It will:
        /// 1) search the string parameter for first occurrence of the char parameter and
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
            return fName + " " + lName;
        }
    }//end of program
}