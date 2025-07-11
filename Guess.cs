using System;

namespace NumberGuesser
{
    public class Guess
    {
        // This property stores the user's guess and can't be changed after creation
        public int UserGuess { get; }

        // This property stores when the guess was made and can't be changed
        public DateTime GuessTime { get; }

        // Constructor - runs when we create a new Guess object
        public Guess(int guess)
        {
            UserGuess = guess;
            GuessTime = DateTime.Now; 
        }
    }
}