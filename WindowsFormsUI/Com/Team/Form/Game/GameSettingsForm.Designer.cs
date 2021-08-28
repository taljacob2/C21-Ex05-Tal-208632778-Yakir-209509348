using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    partial class GameSettingsForm
    {
        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer m_Components = null;

        public NumericUpDown RowsNumericUpDown { get; set; }

        public TextBox TextBoxPlayer1 { get; set; }

        public TextBox TextBoxPlayer2 { get; set; }

        public Label LabelRows { get; set; }

        public Label LabelPlayers { get; set; }

        public Label LabelPlayer1 { get; set; }

        public Label LabelCols { get; set; }

        public Label LabelBoardSize { get; set; }

        public NumericUpDown ColsNumericUpDown { get; set; }

        public CheckBox CheckBoxPlayer2 { get; set; }

        public Button ButtonPlay { get; set; }

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
            // buttonPlay
            // 
            this.ButtonPlay.BackColor = System.Drawing.SystemColors.Highlight;
            this.ButtonPlay.Location = new System.Drawing.Point(124, 246);
            this.ButtonPlay.Name = "m_ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(128, 44);
            this.ButtonPlay.TabIndex = 0;
            this.ButtonPlay.Text = "Play";
            this.ButtonPlay.UseVisualStyleBackColor = false;
            this.ButtonPlay.Click += new System.EventHandler(this.buttonPlay_Click);

            // 
            // labelPlayers
            // 
            this.LabelPlayers.Location = new System.Drawing.Point(12, 9);
            this.LabelPlayers.Name = "m_LabelPlayers";
            this.LabelPlayers.Size = new System.Drawing.Size(85, 32);
            this.LabelPlayers.TabIndex = 1;
            this.LabelPlayers.Text = "Players:";
            this.LabelPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // labelPlayer1
            // 
            this.LabelPlayer1.Location = new System.Drawing.Point(46, 41);
            this.LabelPlayer1.Name = "m_LabelPlayer1";
            this.LabelPlayer1.Size = new System.Drawing.Size(92, 29);
            this.LabelPlayer1.TabIndex = 2;
            this.LabelPlayer1.Text = "Player 1:";
            this.LabelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // checkBoxPlayer2
            // 
            this.CheckBoxPlayer2.Location = new System.Drawing.Point(46, 73);
            this.CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.CheckBoxPlayer2.Size = new System.Drawing.Size(92, 42);
            this.CheckBoxPlayer2.TabIndex = 4;
            this.CheckBoxPlayer2.Text = "Player 2:";
            this.CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);

            // 
            // labelBoardSize
            // 
            this.LabelBoardSize.Location = new System.Drawing.Point(12, 152);
            this.LabelBoardSize.Name = "m_LabelBoardSize";
            this.LabelBoardSize.Size = new System.Drawing.Size(85, 32);
            this.LabelBoardSize.TabIndex = 5;
            this.LabelBoardSize.Text = "Board Size:";
            this.LabelBoardSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // rowsNumericUpDown
            // 
            this.RowsNumericUpDown.Location = new System.Drawing.Point(117, 190);
            this.RowsNumericUpDown.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.RowsNumericUpDown.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.RowsNumericUpDown.Name = "m_RowsNumericUpDown";
            this.RowsNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.RowsNumericUpDown.TabIndex = 6;
            this.RowsNumericUpDown.Value = new decimal(new int[] {4, 0, 0, 0});

            // 
            // colsNumericUpDown
            // 
            this.ColsNumericUpDown.Location = new System.Drawing.Point(258, 190);
            this.ColsNumericUpDown.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.ColsNumericUpDown.Minimum = new decimal(new int[] {4, 0, 0, 0});
            this.ColsNumericUpDown.Name = "m_ColsNumericUpDown";
            this.ColsNumericUpDown.Size = new System.Drawing.Size(51, 22);
            this.ColsNumericUpDown.TabIndex = 7;
            this.ColsNumericUpDown.Value = new decimal(new int[] {4, 0, 0, 0});

            // 
            // labelRows
            // 
            this.LabelRows.Location = new System.Drawing.Point(46, 184);
            this.LabelRows.Name = "m_LabelRows";
            this.LabelRows.Size = new System.Drawing.Size(65, 32);
            this.LabelRows.TabIndex = 8;
            this.LabelRows.Text = "Rows:";
            this.LabelRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // labelCols
            // 
            this.LabelCols.Location = new System.Drawing.Point(187, 184);
            this.LabelCols.Name = "m_LabelCols";
            this.LabelCols.Size = new System.Drawing.Size(65, 32);
            this.LabelCols.TabIndex = 9;
            this.LabelCols.Text = "Cols:";
            this.LabelCols.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // textBoxPlayer1
            // 
            this.TextBoxPlayer1.Location = new System.Drawing.Point(209, 44);
            this.TextBoxPlayer1.MaxLength = 10;
            this.TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.TextBoxPlayer1.Size = new System.Drawing.Size(100, 22);
            this.TextBoxPlayer1.TabIndex = 10;
            this.TextBoxPlayer1.Text = "Player 1";

            // 
            // textBoxPlayer2
            // 
            this.TextBoxPlayer2.Enabled = false;
            this.TextBoxPlayer2.Location = new System.Drawing.Point(209, 82);
            this.TextBoxPlayer2.MaxLength = 10;
            this.TextBoxPlayer2.Name = "m_TextBoxPlayer2";
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
            this.BackColor = Color.CadetBlue;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize) (this.RowsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ColsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
    }
}
