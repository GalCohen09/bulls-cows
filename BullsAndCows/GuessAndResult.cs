namespace BullsAndCows
{
    public class GuessAndResult
    {
        private const int k_SizeWord = 4;
        public const int k_GuessResDisplayMaxChars = 8;
        private char[] m_Guess;
        private int m_NumBulls = 0;
        private int m_NumCows = 0;

        public GuessAndResult(char[] i_Guess, int i_NumBulls, int i_NumCows) 
        {
            this.m_Guess = new char[k_SizeWord];
            for (int i = 0; i < i_Guess.Length; i++)
            {
                this.m_Guess[i] = i_Guess[i];
            }

            this.m_NumBulls = i_NumBulls;
            this.m_NumCows = i_NumCows;
        }

        public int NumBulls
        {
            get
            {
                return m_NumBulls;
            }

            set
            {
                m_NumBulls = value;
            }
        }

        public string GetResultStr()
        {
            string bullsAndCowsStr = string.Empty;
            int numSpaces = 0;

            if (m_NumBulls > 0)
            {
                for (int j = 0; j < m_NumBulls; j++)
                {
                    bullsAndCowsStr += "V";
                    if (j != (m_NumBulls - 1))
                    {
                        bullsAndCowsStr += " ";
                    }
                }
            }

            if (m_NumCows > 0)
            {
                if (m_NumBulls > 0)
                {
                    bullsAndCowsStr += " ";
                }

                for (int j = 0; j < m_NumCows; j++)
                {
                    bullsAndCowsStr += "X";
                    if (j != (m_NumCows - 1))
                    {
                        bullsAndCowsStr += " ";
                    }
                }
            }

            numSpaces = k_GuessResDisplayMaxChars - bullsAndCowsStr.Length;
            if (numSpaces > 0)
            {
                bullsAndCowsStr += new string(' ', numSpaces);
            }

            return bullsAndCowsStr;
        }
    }
}