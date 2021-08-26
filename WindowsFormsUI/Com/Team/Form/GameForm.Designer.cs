using System.Collections.Generic;
using System.Windows.Forms;
using C21_Ex02_01.Com.Team.Engine;

namespace WindowsFormsUI.Com.Team.Form
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
            this.SuspendLayout();

            // 
            // buttonForfeit
            // 
            this.buttonForfeit.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonForfeit.Name = "buttonForfeit";
            this.buttonForfeit.Size = new System.Drawing.Size(128, 44);
            this.buttonForfeit.TabIndex = 0;
            this.buttonForfeit.Text = "Forfeit";
            this.buttonForfeit.UseVisualStyleBackColor = false;
            
            // 
            // buttonColumns
            // 
            createButtonColumns();
            
            // 
            // buttonCoins
            // 
            createButtonCoins();
            
            // set Location of `buttonForfeit`:
            this.buttonForfeit.Location = 
                new System.Drawing.Point(m_CenterWidth, m_MaxButtonCoinHeight
                 + this.buttonForfeit.Size.Height * 2);

            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100,100);
            addButtonColumns();
            addButtonCoins();
            this.Controls.Add(this.buttonForfeit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.AutoSize = true;
            this.Padding = new Padding(k_Padding);
            this.Name = "GameForm";
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
                         this.buttonForfeit.Size.Height * 2))/2;
            this.Left = ((Screen.PrimaryScreen.Bounds.Width -m_CenterWidth * 2)/ 2);
        }
        
        private System.Windows.Forms.Button buttonForfeit;

        private Button[] buttonColumns; 

        private Button[,] buttonCoins;

        #endregion
    }
}
