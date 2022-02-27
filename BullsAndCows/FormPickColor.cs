namespace BullsAndCows
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class PickColor : Form
    {
        public const int k_Two = 2;
        private const int k_Four = 4;
        private static readonly Color[] sr_ColorList = { Color.Purple, Color.Blue, Color.Red, Color.Yellow, Color.Green, Color.Brown, Color.Aqua, Color.White };
        private static int[] s_NumChocice = { -1, -1, -1, -1 };
        private readonly int r_CurrentGuess;
        private readonly Button r_CurrentButton;
        private readonly Button[] r_ButtonResult; 
        private int m_NumButtonChoice = 0;

        public PickColor(Button i_CurrentButton, Button[] i_ButtonResult, int i_CurrentGuess)
        {
            r_CurrentButton = i_CurrentButton;
            r_ButtonResult = i_ButtonResult;
            r_CurrentGuess = i_CurrentGuess;
            InitializeComponent();
            addColor();
        }

        private void addColor()
        {
            Button colorBtn;

            m_NumButtonChoice = r_CurrentButton.TabIndex;
            for (int i = 0; i < k_Four; i++)
            {
                for (int j = 0; j < k_Two; j++)
                {
                    colorBtn = new Button();

                    colorBtn.Location = new Point(10 + (i * BoolPgiaGame.k_Space), 20 + (j * BoolPgiaGame.k_Space));
                    colorBtn.Name = ((k_Two * i) + j).ToString();
                    colorBtn.Size = new Size(BoolPgiaGame.k_SizeBigButton, BoolPgiaGame.k_SizeBigButton);
                    colorBtn.TabIndex = i + j;
                    colorBtn.UseVisualStyleBackColor = true;
                    colorBtn.Click += new System.EventHandler(this.chosenColor);
                    colorBtn.BackColor = sr_ColorList[(k_Two * i) + j];
                    this.Controls.Add(colorBtn);

                    if(s_NumChocice.Contains((k_Two * i) + j))
                    {
                        colorBtn.Enabled = false;
                        colorBtn.BackColor = Color.DarkGray;
                    }
                }
            }
        }

        private void chosenColor(object sender, EventArgs e)
        {
            Button colorBtn = sender as Button;

            r_CurrentButton.BackColor = colorBtn.BackColor;
            s_NumChocice[m_NumButtonChoice] = int.Parse(colorBtn.Name);
            if (!s_NumChocice.Contains(-1))
            {
                r_ButtonResult[r_CurrentGuess].Enabled = true;
            }

            this.Close();
        }

        public static int[] NumChocice
        {
            get
            {
                return s_NumChocice;
            }

            set
            {
                s_NumChocice = value;
            }
        }

        public static Color[] ColorList
        {
            get
            {
                return sr_ColorList;
            }
        }

        private void pickColor_Load(object sender, EventArgs e)
        {
        }
    }
}
