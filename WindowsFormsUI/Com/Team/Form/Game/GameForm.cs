using System;
using System.Drawing;
using System.Windows.Forms;
using C21_Ex02_01.Com.Team.Controller;
using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Database.Board.Coin;
using C21_Ex02_01.Com.Team.Database.Players.Player;
using C21_Ex02_01.Com.Team.Service.Impl;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    public partial class GameForm : System.Windows.Forms.Form
    {
        private const int k_Padding = 12;
        private const int k_Width = 69;
        private int m_CenterWidth;

        private readonly Dialog r_Dialog;
        private int m_MaxButtonCoinHeight;
        private int m_MaxButtonCoinWidth;

        public GameForm()
        {
            // Run settings windows.
            Application.Run(new GameSettingsForm());

            // Set ActuatorService:
            GameControllerImpl.ActuatorService = new ActuatorServiceImpl();

            // Create arrays:
            buttonCoins = new Button[GameControllerImpl.Database.Board.Rows,
                GameControllerImpl.Database.Board.Cols];
            buttonColumns = new Button[GameControllerImpl.Database.Board.Cols];

            InitializeComponent();
            r_Dialog = new Dialog(this);
        }

        public IGameController GameController { get; } =
            new GameControllerImpl();

        private void buttonColumn_Click(object i_Sender, EventArgs i_)
        {
            postButtonColumnClick(i_Sender, out Player winnerPlayer,
                out bool isGameOver);
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
                button.Click += buttonColumn_Click;

                // Set button:
                buttonColumns[i - 1] = button;
            }
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

        private static void createButtonCoin(Button io_Button, int i_X,
            byte i_Col, int i_Y, byte i_Row, int i_Height)
        {
            io_Button.BackColor = SystemColors.Control;
            io_Button.Font = new Font("Microsoft Sans Serif",
                12F);
            io_Button.Location = new Point(
                i_X + (i_Col - 1) * k_Width,
                i_Y + (i_Row - 1) * i_Height);
            io_Button.Name = "buttonCoin" + (i_Row + i_Col);
            io_Button.Size = new Size(k_Width, i_Height);
            io_Button.TabIndex = i_Row + i_Col;
            io_Button.Text =
                GameControllerImpl.Database.Board.GetElement(
                    (byte) (i_Row - 1),
                    (byte) (i_Col - 1)).Char.ToString();
            io_Button.UseVisualStyleBackColor = false;
        }

        private void createButtonCoinWithEventHandler(Button io_Button, int i_X,
            byte i_Col, int i_Y, byte i_Row, int i_Height)
        {
            createButtonCoin(io_Button, i_X, i_Col, i_Y, i_Row, i_Height);

            // Set event handler:
            GameControllerImpl.Database.Board
                .GetElement((byte) (i_Row - 1), (byte) (i_Col - 1))
                .CharModify += buttonCoin_CharModify;
        }

        private void addButtonCoins()
        {
            foreach (Button button in buttonCoins)
            {
                Controls.Add(button);
            }
        }

        private void buttonCoin_CharModify(object i_Sender, EventArgs i_)
        {
            char coinChar = ((Coin) i_Sender).Char;
            Coordinate coinCoordinate = ((Coin) i_Sender).Coordinate;
            buttonCoins[coinCoordinate.Y, coinCoordinate.X].Text =
                coinChar.ToString();
        }

        private void buttonForfeit_Click(object i_Sender, EventArgs i_E)
        {
            GameController.Forfeit(out Player winnerPlayer);
            r_Dialog.CheckForAnotherGameDialogAndInvoke(true, winnerPlayer);
        }

        private void postChooseColumnAsComputerPlayerIfExists(
            out Player o_WinnerPlayer,
            out bool o_IsGameOver)
        {
            GameController.PostChooseColumnAsComputerPlayerIfExists
                (out o_WinnerPlayer, out o_IsGameOver);
            r_Dialog.CheckForAnotherGameDialogAndInvoke(o_IsGameOver,
                o_WinnerPlayer);
        }

        private void postChooseColumnAsHumanPlayer(
            out Player o_WinnerPlayer,
            out bool o_IsGameOver, byte i_ColumnChosen)
        {
            GameController.PostChooseColumnAsHumanPlayer(
                i_ColumnChosen, out o_WinnerPlayer, out o_IsGameOver);
            r_Dialog.CheckForAnotherGameDialogAndInvoke(o_IsGameOver,
                o_WinnerPlayer);
        }

        private void postButtonColumnClick(object i_Sender,
            out Player o_WinnerPlayer, out bool o_IsGameOver)
        {
            string text = ((Button) i_Sender).Text;
            byte columnChosen = (byte) (byte.Parse(text) - 1);

            postChooseColumnAsHumanPlayer(out o_WinnerPlayer,
                out o_IsGameOver, columnChosen);
            postChooseColumnAsComputerPlayerIfExists(out o_WinnerPlayer,
                out o_IsGameOver);

            if (GameControllerImpl.Database.Board.IsColumnFull(columnChosen))
            {
                // Disable this columnButton.
                // TODO: need to implement -> implement here, or in the logic module with events for bonus.
            }
        }

        private class Dialog
        {
            public Dialog(GameForm i_GameForm)
            {
                GameForm = i_GameForm;
            }

            public GameForm GameForm { get; }

            public void CheckForAnotherGameDialogAndInvoke(
                bool i_IsGameOver, Player i_WinnerPlayer)
            {
                const string k_AnotherGameMessage =
                    "Do you want to play another game?";
                const string k_TieMessage = "It is a tie!";

                if (i_IsGameOver)
                {
                    if (i_WinnerPlayer != null)
                    {
                        // There is a WIN, and there is a winnerPlayer:
                        showWinnerDialog(i_WinnerPlayer, k_AnotherGameMessage);
                    }
                    else
                    {
                        // It is a TIE:
                        showTieDialog(k_TieMessage, k_AnotherGameMessage);
                    }
                }
            }

            private void showTieDialog(string i_TieMessage,
                string i_AnotherGameMessage)
            {
                DialogResult dialogResult = MessageBox.Show(
                    i_AnotherGameMessage,
                    i_TieMessage, MessageBoxButtons.YesNo);
                switchDialogGameReplay(dialogResult);
            }

            private void showWinnerDialog(Player i_WinnerPlayer,
                string i_AnotherGameMessage)
            {
                DialogResult dialogResult = MessageBox.Show(
                    i_AnotherGameMessage,
                    winnerPlayerMessage(i_WinnerPlayer),
                    MessageBoxButtons.YesNo);
                switchDialogGameReplay(dialogResult);
            }

            private static string winnerPlayerMessage(Player i_WinnerPlayer)
            {
                return "The winner is Player " + i_WinnerPlayer.ID + "!";
            }

            private void switchDialogGameReplay(DialogResult i_DialogResult)
            {
                if (i_DialogResult == DialogResult.Yes)
                {
                    GameForm.GameController.NewGame();
                }
                else if (i_DialogResult == DialogResult.No)
                {
                    GameForm.Close();
                }
            }
        }
    }
}
