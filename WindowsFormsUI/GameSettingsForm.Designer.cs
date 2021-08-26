using System.Windows.Forms;

namespace WindowsFormsUI
{
    partial class GameSettingsForm
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
            this.ButtonPlay = new System.Windows.Forms.Button();
            this.LabelPlayers = new System.Windows.Forms.Label();
            this.LabelPlayer1 = new System.Windows.Forms.Label();
            this.CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.LabelBoardSize = new System.Windows.Forms.Label();
            this.RowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ColsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LabelRows = new System.Windows.Forms.Label();
            this.LabelCols = new System.Windows.Forms.Label();
            this.TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.RowsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ColsNumericUpDown)).BeginInit();
            this.SuspendLayout();

            // 
            // ButtonPlay
            // 
            this.ButtonPlay.BackColor = System.Drawing.SystemColors.Highlight;
            this.ButtonPlay.Location = new System.Drawing.Point(124, 246);
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(128, 44);
            this.ButtonPlay.TabIndex = 0;
            this.ButtonPlay.Text = "Play";
            this.ButtonPlay.UseVisualStyleBackColor = false;
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);

            // 
            // LabelPlayers
            // 
            this.LabelPlayers.Location = new System.Drawing.Point(12, 9);
            this.LabelPlayers.Name = "LabelPlayers";
            this.LabelPlayers.Size = new System.Drawing.Size(85, 32);
            this.LabelPlayers.TabIndex = 1;
            this.LabelPlayers.Text = "Players:";
            this.LabelPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // LabelPlayer1
            // 
            this.LabelPlayer1.Location = new System.Drawing.Point(46, 41);
            this.LabelPlayer1.Name = "LabelPlayer1";
            this.LabelPlayer1.Size = new System.Drawing.Size(92, 29);
            this.LabelPlayer1.TabIndex = 2;
            this.LabelPlayer1.Text = "Player 1:";
            this.LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // CheckBoxPlayer2
            // 
            this.CheckBoxPlayer2.Location = new System.Drawing.Point(46, 73);
            this.CheckBoxPlayer2.Name = "CheckBoxPlayer2";
            this.CheckBoxPlayer2.Size = new System.Drawing.Size(92, 42);
            this.CheckBoxPlayer2.TabIndex = 4;
            this.CheckBoxPlayer2.Text = "Player 2:";
            this.CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.CheckBoxPlayer2_CheckedChanged);

            // 
            // LabelBoardSize
            // 
            this.LabelBoardSize.Location = new System.Drawing.Point(12, 152);
            this.LabelBoardSize.Name = "LabelBoardSize";
            this.LabelBoardSize.Size = new System.Drawing.Size(85, 32);
            this.LabelBoardSize.TabIndex = 5;
            this.LabelBoardSize.Text = "Board Size:";
            this.LabelBoardSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // RowsNumericUpDown
            // 
            this.RowsNumericUpDown.Location = new System.Drawing.Point(117, 190);
            this.RowsNumericUpDown.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.RowsNumericUpDown.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.RowsNumericUpDown.Name = "RowsNumericUpDown";
            this.RowsNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.RowsNumericUpDown.TabIndex = 6;
            this.RowsNumericUpDown.Value = new decimal(new int[] {4, 0, 0, 0});

            // 
            // ColsNumericUpDown
            // 
            this.ColsNumericUpDown.Location = new System.Drawing.Point(258, 190);
            this.ColsNumericUpDown.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.ColsNumericUpDown.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.ColsNumericUpDown.Name = "ColsNumericUpDown";
            this.ColsNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.ColsNumericUpDown.TabIndex = 7;
            this.ColsNumericUpDown.Value = new decimal(new int[] {4, 0, 0, 0});

            // 
            // LabelRows
            // 
            this.LabelRows.Location = new System.Drawing.Point(46, 184);
            this.LabelRows.Name = "LabelRows";
            this.LabelRows.Size = new System.Drawing.Size(65, 32);
            this.LabelRows.TabIndex = 8;
            this.LabelRows.Text = "Rows:";
            this.LabelRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // LabelCols
            // 
            this.LabelCols.Location = new System.Drawing.Point(187, 184);
            this.LabelCols.Name = "LabelCols";
            this.LabelCols.Size = new System.Drawing.Size(65, 32);
            this.LabelCols.TabIndex = 9;
            this.LabelCols.Text = "Cols:";
            this.LabelCols.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // TextBoxPlayer1
            // 
            this.TextBoxPlayer1.Location = new System.Drawing.Point(209, 44);
            this.TextBoxPlayer1.MaxLength = 10;
            this.TextBoxPlayer1.Name = "TextBoxPlayer1";
            this.TextBoxPlayer1.Size = new System.Drawing.Size(100, 22);
            this.TextBoxPlayer1.TabIndex = 10;

            // 
            // TextBoxPlayer2
            // 
            this.TextBoxPlayer2.Enabled = false;
            this.TextBoxPlayer2.Location = new System.Drawing.Point(209, 82);
            this.TextBoxPlayer2.MaxLength = 10;
            this.TextBoxPlayer2.Name = "TextBoxPlayer2";
            this.TextBoxPlayer2.Size = new System.Drawing.Size(100, 22);
            this.TextBoxPlayer2.TabIndex = 11;
            this.TextBoxPlayer2.Text = "[Computer]";

            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 336);
            this.Controls.Add(this.TextBoxPlayer2);
            this.Controls.Add(this.TextBoxPlayer1);
            this.Controls.Add(this.LabelCols);
            this.Controls.Add(this.LabelRows);
            this.Controls.Add(this.ColsNumericUpDown);
            this.Controls.Add(this.RowsNumericUpDown);
            this.Controls.Add(this.LabelBoardSize);
            this.Controls.Add(this.CheckBoxPlayer2);
            this.Controls.Add(this.LabelPlayer1);
            this.Controls.Add(this.LabelPlayers);
            this.Controls.Add(this.ButtonPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize) (this.RowsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ColsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button ButtonPlay;
        private System.Windows.Forms.CheckBox CheckBoxPlayer2;
        private System.Windows.Forms.NumericUpDown ColsNumericUpDown;
        private System.Windows.Forms.Label LabelBoardSize;
        private System.Windows.Forms.Label LabelCols;
        private System.Windows.Forms.Label LabelPlayer1;
        private System.Windows.Forms.Label LabelPlayers;
        private System.Windows.Forms.Label LabelRows;
        private System.Windows.Forms.NumericUpDown RowsNumericUpDown;
        private System.Windows.Forms.TextBox TextBoxPlayer1;
        private System.Windows.Forms.TextBox TextBoxPlayer2;

        #endregion
    }
}
