using System;
using System.Drawing;
using System.Windows.Forms;
using C21_Ex02_01.Com.Team.Controller;
using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Database.Board.Coin;
using C21_Ex02_01.Com.Team.Misc;

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
            GameController.PostChooseColumnAsHumanPlayer(
                (byte) (byte.Parse(text) - 1));
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
            for (byte row = 1;
                row <= GameControllerImpl.Database.Board.Rows;
                row++)
            {
                for (byte col = 1;
                    col <= GameControllerImpl.Database.Board.Cols;
                    col++)
                {
                    Button button = new Button();
                    const int k_Height = k_Width;
                    const int k_X = k_Padding;
                    const int k_Y = 56;

                    createButtonCoinWithEventHandler(button, k_X, col, k_Y, row,
                        k_Height);

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

        private void createButtonCoinWithEventHandler(Button i_Button, int i_X,
            byte i_Col, int i_Y, byte i_Row, int i_Height)
        {
            createButtonCoin(i_Button, i_X, i_Col, i_Y, i_Row, i_Height);

            // Add event handler:
            GameControllerImpl.Database.Board
                    .GetElement((byte) (i_Row - 1), (byte) (i_Col - 1))
                    .CharModify += new EventHandler(buttonCoin_CharModify);
        }

        private static void createButtonCoin(Button i_Button, int i_X,
            byte i_Col, int i_Y, byte i_Row, int i_Height)
        {
            i_Button.BackColor = SystemColors.Control;
            i_Button.Font = new Font("Microsoft Sans Serif",
                12F);
            i_Button.Location = new Point(
                i_X + (i_Col - 1) * k_Width,
                i_Y + (i_Row - 1) * i_Height);
            i_Button.Name = "buttonCoin" + (i_Row + i_Col);
            i_Button.Size = new Size(k_Width, i_Height);
            i_Button.TabIndex = i_Row + i_Col;
            i_Button.Text =
                GameControllerImpl.Database.Board.GetElement(
                    (byte) (i_Row - 1),
                    (byte) (i_Col - 1)).Char.ToString();
            i_Button.UseVisualStyleBackColor = false;
        }

        private void buttonCoin_CharModify(object i_Sender, EventArgs i_)
        {
            char coinChar = ((Coin) i_Sender).Char;
            Coordinate coinCoordinate = ((Coin) i_Sender).Coordinate;
            this.buttonCoins[coinCoordinate.Y, coinCoordinate.X].Text =
                coinChar.ToString();
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
