using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    partial class GameForm
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
            this.buttonForfeit = new System.Windows.Forms.Button();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // buttonForfeit
            // 
            const int k_ButtonForfeitWidth = 128;
            const int k_ButtonForfeitHeight = 44;
            this.buttonForfeit.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonForfeit.Name = "buttonForfeit";
            this.buttonForfeit.Size = new System.Drawing.Size(k_ButtonForfeitWidth, 44);
            this.buttonForfeit.TabIndex = 0;
            this.buttonForfeit.Text = "Forfeit";
            this.buttonForfeit.UseVisualStyleBackColor = false;
            this.buttonForfeit.Click += new EventHandler(buttonForfeit_Click);
            
            
            // 
            // buttonColumns
            // 
            createButtonColumns();
            
            // 
            // buttonCoins
            // 
            createButtonCoins();
            
            // set Location of `buttonForfeit`:
            int buttonForfeitHeightLocation = m_MaxButtonCoinHeight
                                      + this.buttonForfeit.Size.Height * 2;
            int buttonForfeitWidthLocation = m_CenterWidth;
            this.buttonForfeit.Location = 
                new System.Drawing.Point(buttonForfeitWidthLocation,
                    buttonForfeitHeightLocation);
            
            // 
            // labelPlayer1
            // 
            const int k_LabelPlayer1Width = 80; 
            const int k_LabelPlayer1Height = 29;
            this.labelPlayer1.Location = new System.Drawing
                .Point(buttonForfeitWidthLocation - k_LabelPlayer1Width,
                    buttonForfeitHeightLocation);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(k_LabelPlayer1Width,
                k_LabelPlayer1Height);
            this.labelPlayer1.TabIndex = 2;
            this.labelPlayer1.Text = "Player 1:";
            this.labelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.Location = new System.Drawing
                .Point(buttonForfeitWidthLocation + k_ButtonForfeitWidth,
                    buttonForfeitHeightLocation);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(k_LabelPlayer1Width,
                k_LabelPlayer1Height);
            this.labelPlayer2.TabIndex = 3;
            this.labelPlayer2.Text = "Player 2:";
            this.labelPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100,100);
            addButtonColumns();
            addButtonCoins();
            this.Controls.Add(this.buttonForfeit);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.AutoSize = true;
            this.Padding = new Padding(k_Padding);
            this.Name = "GameForm";
            this.BackColor = Color.CadetBlue;
            manualCenterPosition();
            this.Text = "Connect 4";
            this.ResumeLayout(false);
        }

        private void manualCenterPosition()
        {
            // this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height -
                        (this.m_MaxButtonCoinHeight +
                         this.buttonForfeit.Size.Height * 2)) / 2;
            this.Left = ((Screen.PrimaryScreen.Bounds.Width - m_CenterWidth * 2) / 2);
        }
        
        private System.Windows.Forms.Button buttonForfeit;

        private Button[] buttonColumns; 

        private Button[,] buttonCoins;
        
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayer2;

        #endregion
    }
}
