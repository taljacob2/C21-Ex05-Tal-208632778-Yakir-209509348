using System;
using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Database;
using C21_Ex02_01.Com.Team.Database.Impl;
using C21_Ex02_01.Com.Team.Entity.Board;
using C21_Ex02_01.Com.Team.Entity.Players;
using C21_Ex02_01.Com.Team.Entity.Players.Player;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    public partial class GameSettingsForm : System.Windows.Forms.Form
    {
        private readonly DatabaseBuilder r_DatabaseBuilder;

        public GameSettingsForm()
        {
            initializeComponent();
            r_DatabaseBuilder = new DatabaseBuilder(this);
        }

        public eType Opponent { get; private set; } = eType.Computer;

        private void buttonPlay_Click(object i_Sender, EventArgs i_)
        {
            r_DatabaseBuilder.InitializeDatabase();
            Close();
        }

        private void checkBoxPlayer2_CheckedChanged(object i_Sender,
            EventArgs i_)
        {
            if (CheckBoxPlayer2.Checked)
            {
                TextBoxPlayer2.Text = @"Player 2";
                TextBoxPlayer2.Enabled = true;
                Opponent = eType.Human;
            }
            else
            {
                TextBoxPlayer2.Text = @"[Computer]";
                TextBoxPlayer2.Enabled = false;
                Opponent = eType.Computer;
            }
        }

        private class DatabaseBuilder
        {
            public DatabaseBuilder(GameSettingsForm i_GameSettingsForm)
            {
                GameSettingsForm = i_GameSettingsForm;
            }

            public GameSettingsForm GameSettingsForm { get; }

            public void InitializeDatabase()
            {
                initializeBoard();
                initializePlayersNames();
            }

            private void initializeBoard()
            {
                GameControllerImpl.GameDatabaseImpl =
                    new GameDatabaseImpl(
                        new Board(
                            (byte) GameSettingsForm.RowsNumericUpDown.Value,
                            (byte) GameSettingsForm.ColsNumericUpDown.Value),
                        new Players(new Settings(GameSettingsForm.Opponent)));
            }

            private void initializePlayersNames()
            {
                Players players = GameControllerImpl.GameDatabaseImpl.Players;
                players.GetPlayerOne().Name =
                    GameSettingsForm.TextBoxPlayer1.Text;
                players.GetPlayerTwo().Name =
                    GameSettingsForm.TextBoxPlayer2.Text;
            }
        }
    }
}
