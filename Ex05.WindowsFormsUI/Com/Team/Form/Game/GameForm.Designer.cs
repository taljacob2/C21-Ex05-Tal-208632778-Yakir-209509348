using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    partial class GameForm
    {
        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer m_Components = null;

        public Button ButtonForfeit { get; set; }

        public Button[] ButtonColumns { get; set; }

        public Button[,] ButtonCoins { get; set; }

        public Label LabelPlayer1 { get; set; }

        public Label LabelPlayer2 { get; set; }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (m_Components != null))
            {
                m_Components.Dispose();
            }

            base.Dispose(disposing);
        }
        
        private void initializeComponent()
        {
            this.ButtonForfeit = new System.Windows.Forms.Button();
            this.LabelPlayer1 = new System.Windows.Forms.Label();
            this.LabelPlayer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // buttonForfeit
            // 
            const int k_ButtonForfeitWidth = 65;
            const int k_ButtonForfeitHeight = 44;
            this.ButtonForfeit.BackColor = System.Drawing.SystemColors.Highlight;
            this.ButtonForfeit.Name = "m_ButtonForfeit";
            this.ButtonForfeit.Size = new System.Drawing.Size(k_ButtonForfeitWidth, k_ButtonForfeitHeight);
            this.ButtonForfeit.TabIndex = 0;
            this.ButtonForfeit.Text = "Forfeit";
            this.ButtonForfeit.UseVisualStyleBackColor = false;
            this.ButtonForfeit.Click += new EventHandler(buttonForfeit_Click);
            
            
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
                                      + this.ButtonForfeit.Size.Height * 2;
            int buttonForfeitWidthLocation = m_CenterWidth + 
                                            (int)(k_Padding * 1.9);
            this.ButtonForfeit.Location = 
                new System.Drawing.Point(buttonForfeitWidthLocation,
                    buttonForfeitHeightLocation);
            
            // 
            // labelPlayer1
            // 
            const int k_LabelPlayer1Width = 110; 
            const int k_LabelPlayer1Height = 60;
            this.LabelPlayer1.Location = new System.Drawing
                .Point(buttonForfeitWidthLocation - k_LabelPlayer1Width,
                    buttonForfeitHeightLocation);
            this.LabelPlayer1.Name = "m_LabelPlayer1";
            this.LabelPlayer1.Size = new System.Drawing.Size(k_LabelPlayer1Width,
                k_LabelPlayer1Height);
            this.LabelPlayer1.TabIndex = 2;
            this.LabelPlayer1.Text = k_LabelPlayer1Text;
            this.LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // labelPlayer2
            // 
            this.LabelPlayer2.Location = new System.Drawing
                .Point(buttonForfeitWidthLocation + k_ButtonForfeitWidth,
                    buttonForfeitHeightLocation);
            this.LabelPlayer2.Name = "m_LabelPlayer2";
            this.LabelPlayer2.Size = new System.Drawing.Size(k_LabelPlayer1Width,
                k_LabelPlayer1Height);
            this.LabelPlayer2.TabIndex = 3;
            this.LabelPlayer2.Text = k_LabelPlayer2Text;
            this.LabelPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100,100);
            addButtonColumns();
            addButtonCoins();
            this.Controls.Add(this.ButtonForfeit);
            this.Controls.Add(this.LabelPlayer1);
            this.Controls.Add(this.LabelPlayer2);
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
            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height -
                        (this.m_MaxButtonCoinHeight +
                         this.ButtonForfeit.Size.Height * 2)) / 2;
            this.Left = ((Screen.PrimaryScreen.Bounds.Width - m_CenterWidth * 2) / 2);
        }
        
    }
}
