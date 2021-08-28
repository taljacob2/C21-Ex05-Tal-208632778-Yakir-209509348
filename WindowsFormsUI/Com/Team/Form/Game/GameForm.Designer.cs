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
        private System.Windows.Forms.Button m_ButtonForfeit;
        private Button[] m_ButtonColumns;
        private Button[,] m_ButtonCoins;
        private System.Windows.Forms.Label m_LabelPlayer1;
        private System.Windows.Forms.Label m_LabelPlayer2;

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
        
        private void InitializeComponent()
        {
            this.m_ButtonForfeit = new System.Windows.Forms.Button();
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_LabelPlayer2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // buttonForfeit
            // 
            const int k_ButtonForfeitWidth = 65;
            const int k_ButtonForfeitHeight = 44;
            this.m_ButtonForfeit.BackColor = System.Drawing.SystemColors.Highlight;
            this.m_ButtonForfeit.Name = "m_ButtonForfeit";
            this.m_ButtonForfeit.Size = new System.Drawing.Size(k_ButtonForfeitWidth, k_ButtonForfeitHeight);
            this.m_ButtonForfeit.TabIndex = 0;
            this.m_ButtonForfeit.Text = "Forfeit";
            this.m_ButtonForfeit.UseVisualStyleBackColor = false;
            this.m_ButtonForfeit.Click += new EventHandler(buttonForfeit_Click);
            
            
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
                                      + this.m_ButtonForfeit.Size.Height * 2;
            int buttonForfeitWidthLocation = m_CenterWidth + 
                                            (int)(k_Padding * 1.9);
            this.m_ButtonForfeit.Location = 
                new System.Drawing.Point(buttonForfeitWidthLocation,
                    buttonForfeitHeightLocation);
            
            // 
            // labelPlayer1
            // 
            const int k_LabelPlayer1Width = 110; 
            const int k_LabelPlayer1Height = 60;
            this.m_LabelPlayer1.Location = new System.Drawing
                .Point(buttonForfeitWidthLocation - k_LabelPlayer1Width,
                    buttonForfeitHeightLocation);
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(k_LabelPlayer1Width,
                k_LabelPlayer1Height);
            this.m_LabelPlayer1.TabIndex = 2;
            this.m_LabelPlayer1.Text = k_LabelPlayer1Text;
            this.m_LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // labelPlayer2
            // 
            this.m_LabelPlayer2.Location = new System.Drawing
                .Point(buttonForfeitWidthLocation + k_ButtonForfeitWidth,
                    buttonForfeitHeightLocation);
            this.m_LabelPlayer2.Name = "m_LabelPlayer2";
            this.m_LabelPlayer2.Size = new System.Drawing.Size(k_LabelPlayer1Width,
                k_LabelPlayer1Height);
            this.m_LabelPlayer2.TabIndex = 3;
            this.m_LabelPlayer2.Text = k_LabelPlayer2Text;
            this.m_LabelPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100,100);
            addButtonColumns();
            addButtonCoins();
            this.Controls.Add(this.m_ButtonForfeit);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayer2);
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
                         this.m_ButtonForfeit.Size.Height * 2)) / 2;
            this.Left = ((Screen.PrimaryScreen.Bounds.Width - m_CenterWidth * 2) / 2);
        }
        
    }
}
