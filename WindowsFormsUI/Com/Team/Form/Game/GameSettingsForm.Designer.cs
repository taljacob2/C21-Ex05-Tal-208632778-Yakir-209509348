namespace WindowsFormsUI.Com.Team.Form.Game
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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.rowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.colsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelCols = new System.Windows.Forms.Label();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.rowsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.colsNumericUpDown)).BeginInit();
            this.SuspendLayout();

            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonPlay.Location = new System.Drawing.Point(124, 246);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(128, 44);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);

            // 
            // labelPlayers
            // 
            this.labelPlayers.Location = new System.Drawing.Point(12, 9);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(85, 32);
            this.labelPlayers.TabIndex = 1;
            this.labelPlayers.Text = "Players:";
            this.labelPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // labelPlayer1
            // 
            this.labelPlayer1.Location = new System.Drawing.Point(46, 41);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(92, 29);
            this.labelPlayer1.TabIndex = 2;
            this.labelPlayer1.Text = "Player 1:";
            this.labelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.Location = new System.Drawing.Point(46, 73);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(92, 42);
            this.checkBoxPlayer2.TabIndex = 4;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);

            // 
            // labelBoardSize
            // 
            this.labelBoardSize.Location = new System.Drawing.Point(12, 152);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(85, 32);
            this.labelBoardSize.TabIndex = 5;
            this.labelBoardSize.Text = "Board Size:";
            this.labelBoardSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // rowsNumericUpDown
            // 
            this.rowsNumericUpDown.Location = new System.Drawing.Point(117, 190);
            this.rowsNumericUpDown.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.rowsNumericUpDown.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.rowsNumericUpDown.Name = "rowsNumericUpDown";
            this.rowsNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.rowsNumericUpDown.TabIndex = 6;
            this.rowsNumericUpDown.Value = new decimal(new int[] {4, 0, 0, 0});

            // 
            // colsNumericUpDown
            // 
            this.colsNumericUpDown.Location = new System.Drawing.Point(258, 190);
            this.colsNumericUpDown.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.colsNumericUpDown.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.colsNumericUpDown.Name = "colsNumericUpDown";
            this.colsNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.colsNumericUpDown.TabIndex = 7;
            this.colsNumericUpDown.Value = new decimal(new int[] {4, 0, 0, 0});

            // 
            // labelRows
            // 
            this.labelRows.Location = new System.Drawing.Point(46, 184);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(65, 32);
            this.labelRows.TabIndex = 8;
            this.labelRows.Text = "Rows:";
            this.labelRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // labelCols
            // 
            this.labelCols.Location = new System.Drawing.Point(187, 184);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(65, 32);
            this.labelCols.TabIndex = 9;
            this.labelCols.Text = "Cols:";
            this.labelCols.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(209, 44);
            this.textBoxPlayer1.MaxLength = 10;
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(100, 22);
            this.textBoxPlayer1.TabIndex = 10;

            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(209, 82);
            this.textBoxPlayer2.MaxLength = 10;
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(100, 22);
            this.textBoxPlayer2.TabIndex = 11;
            this.textBoxPlayer2.Text = "[Computer]";

            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 336);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.colsNumericUpDown);
            this.Controls.Add(this.rowsNumericUpDown);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.buttonPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize) (this.rowsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.colsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.NumericUpDown colsNumericUpDown;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.NumericUpDown rowsNumericUpDown;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;

        #endregion
    }
}
