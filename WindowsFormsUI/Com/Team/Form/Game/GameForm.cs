using System;
using System.Drawing;
using System.Windows.Forms;
using C21_Ex02_01.Com.Team.Controller;
using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Database.Board.Coin;
using C21_Ex02_01.Com.Team.Database.Players;
using C21_Ex02_01.Com.Team.Database.Players.Player;
using C21_Ex02_01.Com.Team.Service.Impl;
using ColumnHeader =
    C21_Ex02_01.Com.Team.Database.Board.ColumnHeader.ColumnHeader;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    public partial class GameForm : System.Windows.Forms.Form
    {
        private const int k_Padding = 12;
        private const int k_Width = 69;
        private const string k_LabelPlayer1Text = "Player 1: ";
        private const string k_LabelPlayer2Text = "Player 2: ";

        private readonly Dialog r_Dialog;
        private int m_CenterWidth;
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
            initializeLabelPlayersScoreEventHandler();
            r_Dialog = new Dialog(this);
        }

        public IGameController GameController { get; } =
            new GameControllerImpl();

        private void initializeLabelPlayersScoreEventHandler()
        {
            initializeLabelPlayersText();

            // Set ScoreModify EventHandler:
            GameControllerImpl.Database.Players.GetPlayerOne().ScoreModify +=
                labelPlayer1_ScoreModify;
            GameControllerImpl.Database.Players.GetPlayerTwo().ScoreModify +=
                labelPlayer2_ScoreModify;
        }

        private void initializeLabelPlayersText()
        {
            Players players = GameControllerImpl.Database.Players;
            string player1Name = players.GetPlayerOne().Name;
            string player2Name = players.GetPlayerTwo().Name;

            labelPlayer1.Text = k_LabelPlayer1Text + 0;
            labelPlayer1.Text += Environment.NewLine + player1Name;
            labelPlayer2.Text = k_LabelPlayer1Text + 0;
            labelPlayer2.Text += Environment.NewLine + player2Name;
        }

        private void labelPlayer1_ScoreModify(object i_Sender, EventArgs i_)
        {
            byte score = ((Player) i_Sender).Score;
            Players players = GameControllerImpl.Database.Players;
            string player1Name = players.GetPlayerOne().Name;
            labelPlayer1.Text = k_LabelPlayer1Text + score;
            labelPlayer1.Text += Environment.NewLine + player1Name;
        }

        private void labelPlayer2_ScoreModify(object i_Sender, EventArgs i_)
        {
            byte score = ((Player) i_Sender).Score;
            Players players = GameControllerImpl.Database.Players;
            string player2Name = players.GetPlayerTwo().Name;
            labelPlayer2.Text = k_LabelPlayer2Text + score;
            labelPlayer2.Text += Environment.NewLine + player2Name;
        }

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

                createButtonColumnWithEventHandler(button, k_X, i, k_Y,
                    k_Height);

                // Set button:
                buttonColumns[i - 1] = button;
            }
        }

        private void createButtonColumnWithEventHandler(Button io_Button,
            int i_X, int i_I, int i_Y, int i_Height)
        {
            createButtonColumn(io_Button, i_X, i_I, i_Y, i_Height);

            ColumnHeader columnHeader =
                GameControllerImpl.Database.Board.ColumnHeaders[i_I - 1];

            // Set ColumnFilledUp EventHandler:
            columnHeader.ColumnFilledUp += buttonColumn_ColumnFilledUp;

            // Set ColumnNotFilledUp EventHandler:
            columnHeader.ColumnNotFilledUp += buttonColumn_ColumnNotFilledUp;
        }

        private void buttonColumn_ColumnNotFilledUp(object i_Sender,
            EventArgs i_E)
        {
            byte columnNumber = ((ColumnHeader) i_Sender).ColumnNumber;
            Button button = buttonColumns[columnNumber - 1];
            button.Enabled = true;
            button.BackColor = SystemColors.Highlight;
        }

        private void buttonColumn_ColumnFilledUp(object i_Sender, EventArgs i_E)
        {
            byte columnNumber = ((ColumnHeader) i_Sender).ColumnNumber;
            Button button = buttonColumns[columnNumber - 1];
            button.Enabled = false;
            button.BackColor = SystemColors.GrayText;
        }

        private void createButtonColumn(Button io_Button, int i_X, int i_I,
            int i_Y, int i_Height)
        {
            io_Button.BackColor = SystemColors.Highlight;
            io_Button.Location = new Point(i_X + (i_I - 1) * k_Width, i_Y);
            io_Button.Name = "buttonColumn" + i_I;
            io_Button.Size = new Size(k_Width, i_Height);
            io_Button.TabIndex = i_I;
            io_Button.Text = i_I.ToString();
            io_Button.UseVisualStyleBackColor = false;
            io_Button.Cursor = Cursors.Hand;
            io_Button.Click += buttonColumn_Click;
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
            disableAndColorButtonCoin(io_Button);
        }

        private static void disableAndColorButtonCoin(Button io_Button)
        {
            io_Button.Enabled = false;
            io_Button.BackColor = Color.Azure;
        }

        private void createButtonCoinWithEventHandler(Button io_Button, int i_X,
            byte i_Col, int i_Y, byte i_Row, int i_Height)
        {
            createButtonCoin(io_Button, i_X, i_Col, i_Y, i_Row, i_Height);

            // Set CharModify EventHandler:
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
