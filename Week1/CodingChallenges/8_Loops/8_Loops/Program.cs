using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // You can add manual tests here if you want
            // but unit tests should drive the verification.
        }

        /// <summary>
        /// Return the number of elements in the List<int> that are even (excluding 1234).
        /// </summary>
        public static int UseFor(List<int> x)
        {
            int count = 0;
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] != 1234 && x[i] % 2 == 0) 
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// This method counts the even entries from the provided List<object> 
        /// and returns the total number found.
        /// </summary>
        public static int UseForEach(List<object> x)
        {
            int count = 0;
            foreach (var item in x)
            {
                if (item is char) continue;

                if (item is IConvertible conv)
                {
                    try
                    {
                        long val = conv.ToInt64(null);
                        if (val % 2 == 0)
                        {
                            count++;
                        }
                    }
                    catch
                    {
                        
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// This method counts the multiples of 4 from the provided List<int>. 
        /// Exit the loop when the integer 1234 is found.
        /// Return the total number of multiples of 4.
        /// </summary>
        public static int UseWhile(List<int> x)
        {
            int count = 0;
            int i = 0;

            while (i < x.Count)
            {
                if (x[i] == 1234)
                {
                    break;
                }
                if (x[i] % 4 == 0)
                {
                    count++;
                }
                i++;
            }
            return count;
        }

        /// <summary>
        /// This method will evaluate the Int Array provided and return how many of its 
        /// values are multiples of 3 and 4.
        /// </summary>
        public static int UseForThreeFour(int[] x)
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 3 == 0 && x[i] % 4 == 0) 
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// This method takes an array of List<string>'s. 
        /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
        /// </summary>
        public static string LoopdyLoop(List<string>[] stringListArray)
        {
            List<string> allStrings = new List<string>();

            foreach (var list in stringListArray)
            {
                foreach (var str in list)
                {
                    allStrings.Add(str);
                }
            }

            return string.Join(" ", allStrings) + " ";
        }
    }
}
