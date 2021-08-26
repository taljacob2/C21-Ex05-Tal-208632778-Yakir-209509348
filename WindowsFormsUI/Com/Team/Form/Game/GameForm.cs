﻿using System;
using System.Drawing;
using System.Windows.Forms;
using C21_Ex02_01.Com.Team.Controller;
using C21_Ex02_01.Com.Team.Controller.Impl;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    public partial class GameForm : System.Windows.Forms.Form
    {
        private const int k_Padding = 12;
        private const int k_Width = 69;
        private int m_CenterWidth;
        private int m_MaxButtonCoinHeight;
        private int m_MaxButtonCoinWidth;

        public IGameController GameController { get; private set; } =
            new GameControllerImpl();

        public GameForm()
        {
            // Run settings windows.
            Application.Run(new GameSettingsForm());

            // Create arrays:
            buttonCoins = new Button[GameControllerImpl.Database.Board.Rows,
                GameControllerImpl.Database.Board.Cols];
            buttonColumns = new Button[GameControllerImpl.Database.Board.Cols];

            InitializeComponent();
        }

        private void createButtonColumns()
        {
            for (int i = 1; i <= GameControllerImpl.Database.Board.Cols; i++)
            {
                Button button = new Button();
                const int k_Height = 34;
                const int k_X = k_Padding;
                const int k_Y = k_Padding;

                button.BackColor = SystemColors.Highlight;
                button.Location = new Point(k_X + (i - 1) * k_Width, k_Y);
                button.Name = "buttonColumn" + i;
                button.Size = new Size(k_Width, k_Height);
                button.TabIndex = i;
                button.Text = i.ToString();
                button.UseVisualStyleBackColor = false;
                button.Cursor = Cursors.Hand;
                button.Click +=
                    new System.EventHandler(this.buttonColumn_Click);

                // Set button:
                buttonColumns[i - 1] = button;
            }
        }

        private void buttonColumn_Click(object i_Sender, EventArgs i_)
        {
            string text = ((Button) i_Sender).Text;
            GameController.PostChooseColumnAsHumanPlayer(byte.Parse(text));
        }

        private void addButtonColumns()
        {
            foreach (Button button in buttonColumns)
            {
                Controls.Add(button);
            }
        }

        private void createButtonCoins()
        {
            for (byte row = 1; row <= GameControllerImpl.Database.Board.Rows; row++)
            {
                for (byte col = 1; col <= GameControllerImpl.Database.Board.Cols; col++)
                {
                    Button button = new Button();
                    const int k_Height = k_Width;
                    const int k_X = k_Padding;
                    const int k_Y = 56;

                    button.BackColor = SystemColors.Control;
                    button.Font = new Font("Microsoft Sans Serif",
                        12F);
                    button.Location = new Point(
                        k_X + (col - 1) * k_Width,
                        k_Y + (row - 1) * k_Height);
                    button.Name = "buttonCoin" + (row + col);
                    button.Size = new Size(k_Width, k_Height);
                    button.TabIndex = row + col;
                    button.Text =
                        GameControllerImpl.Database.Board.GetElement((byte) (row - 1),
                            (byte) (col - 1)).Char.ToString();
                    button.UseVisualStyleBackColor = false;

                    // Update max height and width
                    m_MaxButtonCoinHeight = k_Y + (row - 1) * k_Height;
                    m_MaxButtonCoinWidth = k_X + (col - 1) * k_Width;
                    m_CenterWidth =
                        (m_MaxButtonCoinWidth - k_Width / 2 - k_Padding) / 2;


                    // Set button:
                    buttonCoins[row - 1, col - 1] = button;
                }
            }
        }

        private void addButtonCoins()
        {
            foreach (Button button in buttonCoins)
            {
                Controls.Add(button);
            }
        }
    }
}
