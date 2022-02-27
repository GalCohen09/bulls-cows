namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class UserValidCheck
    {
        private const int k_MaxGuess = 10;
        private const int k_MinGuess = 4;
        private const int k_SizeWord = 4;

        public static int MaxGuessInput()
        {
            int numOfGuesses = 0;

            string guesses = Console.ReadLine();

            if(int.TryParse(guesses, out numOfGuesses))
            {
                if(numOfGuesses < k_MinGuess || numOfGuesses > k_MaxGuess)
                {
                    numOfGuesses = (int)eCheckValidMaxGuess.NotInRange;
                }
            }
            else
            {
                numOfGuesses = (int)eCheckValidMaxGuess.Invalid;
            }

            return numOfGuesses;
        }

        public static char[] CreateGuess(ref eCheckValidGuess o_CheckValidGuess)
        {
            char[] guess = new char[k_SizeWord];
            string guessStr = String.Empty;
            char[] charSeparators = new char[] { ' ' };
            string[] guessStrParts;
            string curStr = String.Empty;
            char curChar = ' ';

            Array.Clear(guess, 0, guess.Length);
            guessStr = Console.ReadLine();
            guessStrParts = guessStr.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if(guessStrParts[0] == "Q")
            {
                o_CheckValidGuess = eCheckValidGuess.Quit;
            }
            else if(guessStrParts.Length != k_SizeWord)
            {
                o_CheckValidGuess = eCheckValidGuess.NotFourLetter;
            }
            else
            {
                for(int i = 0; i < guessStrParts.Length; i++)
                {
                    curStr = guessStrParts[i];
                    if(curStr.Length != 1)
                    {
                        o_CheckValidGuess = eCheckValidGuess.NoOneLetter;
                        break;
                    }

                    curChar = curStr[0];
                    if(curChar < 'A' || curChar > 'H')
                    {
                        o_CheckValidGuess = eCheckValidGuess.NotInRange;
                        break;
                    }
                    else if(guess.Contains(curChar))
                    {
                        o_CheckValidGuess = eCheckValidGuess.HaveRepeat;
                        break;
                    }

                    guess[i] = curChar;
                }

            }

            return guess;
        }
    }
}
