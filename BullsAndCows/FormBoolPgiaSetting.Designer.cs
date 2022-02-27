namespace BullsAndCows
{
    using System.Windows.Forms;
    using System.Drawing;

    public partial class BoolPgia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNumOfChance = new Button();
            this.btnStart = new Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.btnNumOfChance.Location = new Point(78, 57);
            this.btnNumOfChance.Name = "Number of chances:";
            this.btnNumOfChance.Size = new Size(656, 90);
            this.btnNumOfChance.TabIndex = 0;
            this.btnNumOfChance.Text = "Number of chances:";
            this.btnNumOfChance.UseVisualStyleBackColor = true;
            this.btnNumOfChance.Click += new System.EventHandler(this.numChance_Click);
            // 
            // button2
            // 
            this.btnStart.Location = new Point(488, 334);
            this.btnStart.Name = "start";
            this.btnStart.Size = new Size(246, 59);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.start_Click);

            // 
            // Win1
            // 
            this.AutoScaleDimensions = new SizeF(19F, 37F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnNumOfChance);
            this.Name = "Bool Pgia";
            this.Text = "Bool Pgia";
            this.Load += new System.EventHandler(this.boolPgia_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private Button btnNumOfChance;
        private Button btnStart;
    }
}