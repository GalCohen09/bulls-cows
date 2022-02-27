namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class BoolPgiaGame : Form
    { 
        public const int k_Space = 50;
        public const int k_SizeBigButton = 40;
        private const int k_Width = 320;
        private const int k_Length = 70;
        private const int k_Extralength = 55;
        private const int k_NumGuess = 4;
        private readonly char[] r_ComputerGuess = ComputerGuess.CreateComputerGuess();
        private readonly int r_NumClick;
        private Button m_CurrentButton;
        private Button[] m_ButtonResult;
        private int m_currentGuess = 0;

        public BoolPgiaGame(int i_NumClick)
        {
            this.r_NumClick = i_NumClick;
            addButton();
            InitializeComponent();
            this.ClientSize = new Size(k_Width, k_Length + (i_NumClick * k_Extralength));
        }

        private void user_Click(object sender, EventArgs e)
        {
            m_CurrentButton = sender as Button;
            PickColor colorForm = new PickColor(m_CurrentButton, m_ButtonResult, m_currentGuess);

            colorForm.ShowDialog();
        }

        private void checkResult_Click(object sender, EventArgs e)
        {
            Button currentResult = sender as Button;
            char[] userGuessArr = new char[k_NumGuess];
            GuessAndResult guessResult;
            string resultGame;
            char[] charSeparators = new char[] { ' ' };
            string[] resultGameStr;
            Control[] currentButtons = this.Controls.Find("buttonUserGuess" + m_currentGuess, false);
            Control[] nextButtons = this.Controls.Find("buttonUserGuess" + (m_currentGuess + 1), false);
            Control[] resultButtons = this.Controls.Find("result" + m_currentGuess, false);

            for (int i = 0; i < k_NumGuess; i++)
            {
                userGuessArr[i] = (char)('A' + PickColor.NumChocice[i]);
            }

            guessResult = BullsAndCowsUpdate.CheckGuessAndUpdateGameData(userGuessArr, r_ComputerGuess);
            resultGame = guessResult.GetResultStr();
            resultGameStr = resultGame.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (guessResult.NumBulls == k_NumGuess || currentResult.TabIndex + 1 == r_NumClick)
            {
                Control[] buttonCompGuess = this.Controls.Find("buttonCompGuess", false);
                for(int i = 0; i < k_NumGuess; i++)
                {
                    buttonCompGuess[i].BackColor = PickColor.ColorList[r_ComputerGuess[i] - 'A'];
                    buttonCompGuess[i].Enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < k_NumGuess; i++)
                {
                    nextButtons[i].Enabled = true;
                }
            }

            for (int i = 0; i < k_NumGuess; i++)
            {
                currentButtons[i].Enabled = false;
            }            

            for (int i = 0; i < resultGameStr.Length; i++)
            {
                if (resultGameStr[i] == "X")
                {
                    resultButtons[i].BackColor = Color.Yellow;
                }
                else if (resultGameStr[i] == "V")
                {
                    resultButtons[i].BackColor = Color.Black;
                }
            }

            for (int i = 0; i < k_NumGuess; i++)
            {
                PickColor.NumChocice[i] = -1;
            }

            m_currentGuess++;
            currentResult.Enabled = false;
        }

        private Button createButton(int i_X, int i_Y, int i_Width, int i_Heigh, string i_Name, int i_TabIndex)
        {
            Button newButton = new Button();

            newButton.Location = new Point(i_X, i_Y);
            newButton.Name = i_Name;
            newButton.Size = new Size(i_Width, i_Heigh);
            newButton.TabIndex = i_TabIndex;
            newButton.UseVisualStyleBackColor = true;
            newButton.Enabled = false;

            return newButton;
        }

        private void theFirstFour()
        {
            Button btnCompGuess;

            for (int i = 0; i < k_NumGuess; i++)
            {
                btnCompGuess = createButton(10 + (i * k_Space), 20, k_SizeBigButton, k_SizeBigButton, "buttonCompGuess", i);
                btnCompGuess.BackColor = Color.Black;
                this.Controls.Add(btnCompGuess);
            }
        }

        private void matrixBuild()
        { 
            Button btnUserGuess;
            Button buttonCheckResult;

            m_ButtonResult = new Button[r_NumClick];
            for (int i = 0; i < r_NumClick; i++)
            {
                for (int j = 0; j < k_NumGuess; j++)
                {
                    btnUserGuess = createButton(10 + (j * k_Space), 80 + (i * k_Space), k_SizeBigButton, k_SizeBigButton, "buttonUserGuess" + i, j);
                    btnUserGuess.Click += new System.EventHandler(this.user_Click);
                    if (i == 0)
                    {
                        btnUserGuess.Enabled = true;
                    }

                    this.Controls.Add(btnUserGuess);
                }

                buttonCheckResult = createButton(210, 90 + (i * k_Space), 50, 20, "buttonCheckResult" + i, i);
                buttonCheckResult.Text = "-->>";
                buttonCheckResult.Click += new System.EventHandler(this.checkResult_Click);
                m_ButtonResult[i] = buttonCheckResult;
                this.Controls.Add(buttonCheckResult);

                for (int j = 0; j < PickColor.k_Two; j++)
                {
                    for (int k = 0; k < PickColor.k_Two; k++)
                    {
                        Button btnResult = createButton(270 + (k * 15), 85 + (j * 15) + (i * k_Space), k_SizeBigButton / 3, k_SizeBigButton / 3, "result" + i, i);
                        this.Controls.Add(btnResult);
                    }
                }
            }
        }

        private void addButton()
        {
            theFirstFour();
            matrixBuild();
        }

        private void boolPgiaGame_Load(object sender, EventArgs e)
        {
        }
    }
}
