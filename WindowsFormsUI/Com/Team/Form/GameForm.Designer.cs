﻿using System.Collections.Generic;
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
            this.buttonForfeit.Location = new System.Drawing.Point(337, 394);
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

            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 200);
            addButtonColumns();
            addButtonCoins();
            this.Controls.Add(this.buttonForfeit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.AutoSize = true;
            this.Padding = new Padding(k_Padding);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect 4";
            this.ResumeLayout(false);
        }
        
        private System.Windows.Forms.Button buttonForfeit;

        private Button[] buttonColumns; 

        private Button[,] buttonCoins;

        #endregion
    }
}
