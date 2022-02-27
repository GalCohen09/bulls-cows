namespace BullsAndCows
{
    using System;
    using System.Windows.Forms;

    public partial class BoolPgia : Form
    {
        private const int k_MaxOption = 10;
        private const int k_MinOption = 4;
        private int m_numClick = 4;

        public BoolPgia()
        {
            InitializeComponent();
        }

        private void boolPgia_Load(object sender, EventArgs e)
        {
            btnNumOfChance.Text = "Number of chances:" + k_MinOption;
        }

        private void numChance_Click(object sender, EventArgs e)
        {
            if(m_numClick < k_MaxOption)
            {
                m_numClick++;
            }
            else if(m_numClick == k_MaxOption)
            {
                m_numClick = k_MinOption;
            }

            btnNumOfChance.Text = "Number of chances:" + m_numClick;
        }

        private void start_Click(object sender, EventArgs e)
        {
            BoolPgiaGame secondForm = new BoolPgiaGame(this.m_numClick);

            this.Hide();
            secondForm.ShowDialog();
            this.Close();
        }
    }
}
