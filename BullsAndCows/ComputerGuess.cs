namespace BullsAndCows
{
    using System;
    using System.Linq;

    public class ComputerGuess
    {
        public const int k_GuessCharsNum = 4;
        public const int k_GuessCharRangeSize = 8;
        private static readonly Random s_Rnd = new Random();

        public static char[] CreateComputerGuess()
        {
            char[] computerGuess = new char[k_GuessCharsNum];
            int curIndex = 0;
            int randNum = 0;
            char curChar = ' ';

            while (true)
            {
                randNum = s_Rnd.Next(k_GuessCharRangeSize);
                curChar = (char)('A' + randNum);
                if (!computerGuess.Contains(curChar))
                {
                    computerGuess[curIndex] = curChar;
                    curIndex++;
                }

                if (curIndex == k_GuessCharsNum)
                {
                    break;
                }
            }

            return computerGuess;
        }
    }
}