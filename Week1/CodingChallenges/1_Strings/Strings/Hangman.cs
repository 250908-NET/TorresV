using System;
using System.Collections.Generic;
using System.Linq;

namespace HangmanGame
{
    public class Program
    {
        // Game constants
        private const int MAX_WRONG_GUESSES = 6;
        
        // Word list for the game
        private static readonly string[] WORDS = {
            "COMPUTER", "PROGRAMMING", "CHALLENGE", "ALGORITHM", "DATABASE",
            "INTERNET", "SOFTWARE", "HARDWARE", "KEYBOARD", "MONITOR",
            "CONSOLE", "APPLICATION", "FUNCTION", "VARIABLE", "BOOLEAN"
        };

        // Game state variables
        private static string wordToGuess;
        private static char[] guessedWord;
        private static List<char> incorrectGuesses;
        private static List<char> allGuesses;
        private static int wrongGuessCount;

        public static void Main(string[] args)
        {
            Console.WriteLine("=== WELCOME TO HANGMAN ===");
            Console.WriteLine();

            bool playAgain = true;
            while (playAgain)
            {
                InitializeGame();
                PlayGame();
                playAgain = AskPlayAgain();
            }

            Console.WriteLine("Thanks for playing Hangman!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void InitializeGame()
        {
            // Select random word
            Random random = new Random();
            wordToGuess = WORDS[random.Next(WORDS.Length)];
            
            // Initialize game state
            guessedWord = new char[wordToGuess.Length];
            for (int i = 0; i < guessedWord.Length; i++)
            {
                guessedWord[i] = '_';
            }
            
            incorrectGuesses = new List<char>();
            allGuesses = new List<char>();
            wrongGuessCount = 0;
        }

        private static void PlayGame()
        {
            while (!IsGameOver())
            {
                DisplayGameState();
                char guess = GetPlayerGuess();
                ProcessGuess(guess);
                Console.WriteLine();
            }

            DisplayGameState();
            DisplayGameResult();
        }

        private static void DisplayGameState()
        {
            Console.Clear();
            Console.WriteLine("=== HANGMAN ===");
            Console.WriteLine();
            
            DrawHangman();
            Console.WriteLine();
            
            Console.WriteLine("Word: " + string.Join(" ", guessedWord));
            Console.WriteLine();
            
            Console.WriteLine($"Wrong guesses left: {MAX_WRONG_GUESSES - wrongGuessCount}");
            
            if (incorrectGuesses.Count > 0)
            {
                Console.WriteLine("Incorrect letters: " + string.Join(", ", incorrectGuesses));
            }
            
            if (allGuesses.Count > 0)
            {
                Console.WriteLine("All guesses: " + string.Join(", ", allGuesses.OrderBy(c => c)));
            }
            Console.WriteLine();
        }

        private static void DrawHangman()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");

            switch (wrongGuessCount)
            {
                case 0:
                    Console.WriteLine("  |    ");
                    Console.WriteLine("  |    ");
                    Console.WriteLine("  |    ");
                    Console.WriteLine("  |    ");
                    break;
                case 1:
                    Console.WriteLine("  |   O");
                    Console.WriteLine("  |    ");
                    Console.WriteLine("  |    ");
                    Console.WriteLine("  |    ");
                    break;
                case 2:
                    Console.WriteLine("  |   O");
                    Console.WriteLine("  |   |");
                    Console.WriteLine("  |    ");
                    Console.WriteLine("  |    ");
                    break;
                case 3:
                    Console.WriteLine("  |   O");
                    Console.WriteLine("  |  /|");
                    Console.WriteLine("  |    ");
                    Console.WriteLine("  |    ");
                    break;
                case 4:
                    Console.WriteLine("  |   O");
                    Console.WriteLine("  |  /|\\");
                    Console.WriteLine("  |    ");
                    Console.WriteLine("  |    ");
                    break;
                case 5:
                    Console.WriteLine("  |   O");
                    Console.WriteLine("  |  /|\\");
                    Console.WriteLine("  |  / ");
                    Console.WriteLine("  |    ");
                    break;
                case 6:
                    Console.WriteLine("  |   O");
                    Console.WriteLine("  |  /|\\");
                    Console.WriteLine("  |  / \\");
                    Console.WriteLine("  |    ");
                    break;
            }
            Console.WriteLine("__|__");
        }

        private static char GetPlayerGuess()
        {
            while (true)
            {
                Console.Write("Enter a letter guess: ");
                string input = Console.ReadLine()?.ToUpper();

                if (string.IsNullOrEmpty(input) || input.Length != 1)
                {
                    Console.WriteLine("Please enter exactly one letter.");
                    continue;
                }

                char guess = input[0];

                if (!char.IsLetter(guess))
                {
                    Console.WriteLine("Please enter a valid letter.");
                    continue;
                }

                if (allGuesses.Contains(guess))
                {
                    Console.WriteLine("You already guessed that letter. Try again.");
                    continue;
                }

                return guess;
            }
        }

        private static void ProcessGuess(char guess)
        {
            allGuesses.Add(guess);

            if (wordToGuess.Contains(guess))
            {
                // Correct guess - reveal letters
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess)
                    {
                        guessedWord[i] = guess;
                    }
                }
                Console.WriteLine($"Good guess! '{guess}' is in the word.");
            }
            else
            {
                // Incorrect guess
                incorrectGuesses.Add(guess);
                wrongGuessCount++;
                Console.WriteLine($"Sorry, '{guess}' is not in the word.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static bool IsGameOver()
        {
            return IsWordGuessed() || wrongGuessCount >= MAX_WRONG_GUESSES;
        }

        private static bool IsWordGuessed()
        {
            return !guessedWord.Contains('_');
        }

        private static void DisplayGameResult()
        {
            Console.WriteLine();
            if (IsWordGuessed())
            {
                Console.WriteLine("🎉 CONGRATULATIONS! YOU WON! 🎉");
                Console.WriteLine($"You correctly guessed the word: {wordToGuess}");
                Console.WriteLine($"Wrong guesses: {wrongGuessCount}/{MAX_WRONG_GUESSES}");
            }
            else
            {
                Console.WriteLine("💀 GAME OVER! 💀");
                Console.WriteLine($"The word was: {wordToGuess}");
                Console.WriteLine("Better luck next time!");
            }
            Console.WriteLine();
        }

        private static bool AskPlayAgain()
        {
            while (true)
            {
                Console.Write("Would you like to play again? (y/n): ");
                string response = Console.ReadLine()?.ToLower();

                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response == "n" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' for yes or 'n' for no.");
                }
            }
        }
    }
}