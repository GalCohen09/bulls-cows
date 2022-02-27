namespace BullsAndCows
{
    using System.Linq;

    public class BullsAndCowsUpdate
    {  
        public static GuessAndResult CheckGuessAndUpdateGameData(char[] i_UserGuess, char[] i_ComputerGuess)
        {
            int numBulls = 0;
            int numCows = 0;
            GuessAndResult newGuess; 

            for (int i = 0; i < i_UserGuess.Length; i++)
            {
                if (i_UserGuess[i] == i_ComputerGuess[i])
                {
                    numBulls++;
                }
                else if (i_UserGuess.Contains(i_ComputerGuess[i]))
                {
                    numCows++;
                }
            }

            newGuess = new GuessAndResult(i_UserGuess, numBulls, numCows);

            return newGuess;
        }  
    }
}
