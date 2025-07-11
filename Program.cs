using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Random random = new Random();
            
            // Generate a random number between 1 and 100
            int targetNumber = random.Next(1, 101);
            
            // List to store all the user's guesses
            List<Guess> guesses = new List<Guess>();
            
            // Variable to hold the user's current guess
            int userGuessNumber = 0;

            Console.WriteLine("Welcome to Darlington's Number Guesser Game!");
            Console.WriteLine("I've picked a number between 1 and 100. Can you guess it?");

            // Game loop - keeps running until user guesses correctly
            do
            {
                Console.Write("Enter your guess (1-100): ");
                string userInput = Console.ReadLine();

                // Check if input is a valid number
                if (!int.TryParse(userInput, out userGuessNumber))
                {
                    Console.WriteLine("Error: That's not a number. Please try again.");
                    continue; 
                }

                
                if (userGuessNumber < 1 || userGuessNumber > 100)
                {
                    Console.WriteLine("Please enter a number between 1 and 100.");
                    continue;
                }

                
                Guess currentGuess = new Guess(userGuessNumber);
                
                
                guesses.Add(currentGuess);

            
                var previousGuesses = guesses.Take(guesses.Count - 1)
                                            .Select((g, i) => new { Guess = g.UserGuess, Index = i })
                                            .Where(x => x.Guess == userGuessNumber)
                                            .ToList();

                if (previousGuesses.Any())
                {
                    int lastIndex = previousGuesses.Last().Index;
                    int turnsAgo = (guesses.Count - 1) - lastIndex;
                    Console.WriteLine($"You guessed this number {turnsAgo} turns ago!");
                }

                
                if (userGuessNumber == targetNumber)
                {
                    break; 
                }
                else if (userGuessNumber < targetNumber)
                {
                    Console.WriteLine("Too low! Try a higher number.");
                }
                else
                {
                    Console.WriteLine("Too high! Try a lower number.");
                }

            } while (true); 

            // Game won - show results
            Console.WriteLine($"\nYou Won! The answer was {targetNumber}.");
            Console.WriteLine($"Total guesses: {guesses.Count}");
            Console.WriteLine("Your guess history:");
            
            foreach (var guess in guesses)
            {
                Console.WriteLine($"{guess.UserGuess} at {guess.GuessTime.ToString("HH:mm:ss")}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}