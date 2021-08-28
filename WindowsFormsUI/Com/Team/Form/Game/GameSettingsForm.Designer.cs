using System.Drawing;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    partial class GameSettingsForm
    {
        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer m_Components = null;
        private System.Windows.Forms.Button m_ButtonPlay;
        private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
        private System.Windows.Forms.NumericUpDown m_ColsNumericUpDown;
        private System.Windows.Forms.Label m_LabelBoardSize;
        private System.Windows.Forms.Label m_LabelCols;
        private System.Windows.Forms.Label m_LabelPlayer1;
        private System.Windows.Forms.Label m_LabelPlayers;
        private System.Windows.Forms.Label m_LabelRows;
        private System.Windows.Forms.NumericUpDown m_RowsNumericUpDown;
        private System.Windows.Forms.TextBox m_TextBoxPlayer1;
        private System.Windows.Forms.TextBox m_TextBoxPlayer2;
        
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
            this.m_ButtonPlay = new System.Windows.Forms.Button();
            this.m_LabelPlayers = new System.Windows.Forms.Label();
            this.m_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_RowsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_ColsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_LabelRows = new System.Windows.Forms.Label();
            this.m_LabelCols = new System.Windows.Forms.Label();
            this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.m_RowsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.m_ColsNumericUpDown)).BeginInit();
            this.SuspendLayout();

            // 
            // buttonPlay
            // 
            this.m_ButtonPlay.BackColor = System.Drawing.SystemColors.Highlight;
            this.m_ButtonPlay.Location = new System.Drawing.Point(124, 246);
            this.m_ButtonPlay.Name = "m_ButtonPlay";
            this.m_ButtonPlay.Size = new System.Drawing.Size(128, 44);
            this.m_ButtonPlay.TabIndex = 0;
            this.m_ButtonPlay.Text = "Play";
            this.m_ButtonPlay.UseVisualStyleBackColor = false;
            this.m_ButtonPlay.Click += new System.EventHandler(this.buttonPlay_Click);

            // 
            // labelPlayers
            // 
            this.m_LabelPlayers.Location = new System.Drawing.Point(12, 9);
            this.m_LabelPlayers.Name = "m_LabelPlayers";
            this.m_LabelPlayers.Size = new System.Drawing.Size(85, 32);
            this.m_LabelPlayers.TabIndex = 1;
            this.m_LabelPlayers.Text = "Players:";
            this.m_LabelPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // labelPlayer1
            // 
            this.m_LabelPlayer1.Location = new System.Drawing.Point(46, 41);
            this.m_LabelPlayer1.Name = "m_LabelPlayer1";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(92, 29);
            this.m_LabelPlayer1.TabIndex = 2;
            this.m_LabelPlayer1.Text = "Player 1:";
            this.m_LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // checkBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(46, 73);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(92, 42);
            this.m_CheckBoxPlayer2.TabIndex = 4;
            this.m_CheckBoxPlayer2.Text = "Player 2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);

            // 
            // labelBoardSize
            // 
            this.m_LabelBoardSize.Location = new System.Drawing.Point(12, 152);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(85, 32);
            this.m_LabelBoardSize.TabIndex = 5;
            this.m_LabelBoardSize.Text = "Board Size:";
            this.m_LabelBoardSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // rowsNumericUpDown
            // 
            this.m_RowsNumericUpDown.Location = new System.Drawing.Point(117, 190);
            this.m_RowsNumericUpDown.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.m_RowsNumericUpDown.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.m_RowsNumericUpDown.Name = "m_RowsNumericUpDown";
            this.m_RowsNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.m_RowsNumericUpDown.TabIndex = 6;
            this.m_RowsNumericUpDown.Value = new decimal(new int[] {4, 0, 0, 0});

            // 
            // colsNumericUpDown
            // 
            this.m_ColsNumericUpDown.Location = new System.Drawing.Point(258, 190);
            this.m_ColsNumericUpDown.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.m_ColsNumericUpDown.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.m_ColsNumericUpDown.Name = "m_ColsNumericUpDown";
            this.m_ColsNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.m_ColsNumericUpDown.TabIndex = 7;
            this.m_ColsNumericUpDown.Value = new decimal(new int[] {4, 0, 0, 0});

            // 
            // labelRows
            // 
            this.m_LabelRows.Location = new System.Drawing.Point(46, 184);
            this.m_LabelRows.Name = "m_LabelRows";
            this.m_LabelRows.Size = new System.Drawing.Size(65, 32);
            this.m_LabelRows.TabIndex = 8;
            this.m_LabelRows.Text = "Rows:";
            this.m_LabelRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // labelCols
            // 
            this.m_LabelCols.Location = new System.Drawing.Point(187, 184);
            this.m_LabelCols.Name = "m_LabelCols";
            this.m_LabelCols.Size = new System.Drawing.Size(65, 32);
            this.m_LabelCols.TabIndex = 9;
            this.m_LabelCols.Text = "Cols:";
            this.m_LabelCols.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // textBoxPlayer1
            // 
            this.m_TextBoxPlayer1.Location = new System.Drawing.Point(209, 44);
            this.m_TextBoxPlayer1.MaxLength = 10;
            this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.m_TextBoxPlayer1.Size = new System.Drawing.Size(100, 22);
            this.m_TextBoxPlayer1.TabIndex = 10;
            this.m_TextBoxPlayer1.Text = "Player 1";

            // 
            // textBoxPlayer2
            // 
            this.m_TextBoxPlayer2.Enabled = false;
            this.m_TextBoxPlayer2.Location = new System.Drawing.Point(209, 82);
            this.m_TextBoxPlayer2.MaxLength = 10;
            this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
            this.m_TextBoxPlayer2.Size = new System.Drawing.Size(100, 22);
            this.m_TextBoxPlayer2.TabIndex = 11;
            this.m_TextBoxPlayer2.Text = "[Computer]";

            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 336);
            this.Controls.Add(this.m_TextBoxPlayer2);
            this.Controls.Add(this.m_TextBoxPlayer1);
            this.Controls.Add(this.m_LabelCols);
            this.Controls.Add(this.m_LabelRows);
            this.Controls.Add(this.m_ColsNumericUpDown);
            this.Controls.Add(this.m_RowsNumericUpDown);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayers);
            this.Controls.Add(this.m_ButtonPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GameSettingsForm";
            this.BackColor = Color.CadetBlue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize) (this.m_RowsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.m_ColsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
    }
}
