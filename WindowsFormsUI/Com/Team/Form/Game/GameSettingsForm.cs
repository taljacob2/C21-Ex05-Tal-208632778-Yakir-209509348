using System;
using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Database;
using C21_Ex02_01.Com.Team.Database.Board;
using C21_Ex02_01.Com.Team.Database.Players;
using C21_Ex02_01.Com.Team.Database.Players.Player;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    public class DatabaseBuilder
    {
        public DatabaseBuilder(GameSettingsForm i_GameSettingsForm)
        {
            SettingsForm = i_GameSettingsForm;
        }

        public GameSettingsForm SettingsForm { get; }

        public void InitializeDatabase()
        {
            initializeBoard();
            initializePlayersNames();
        }

        private void initializeBoard()
        {
            GameControllerImpl.Database =
                new Database(
                    new Board((byte) SettingsForm.RowsNumericUpDown.Value,
                        (byte) SettingsForm.ColsNumericUpDown.Value),
                    new Players(new Settings(SettingsForm.Opponent)));
        }

        private void initializePlayersNames()
        {
            Players players = GameControllerImpl.Database.Players;
            players.GetPlayerOne().Name =
                SettingsForm.TextBoxPlayer1.Text;
            players.GetPlayerTwo().Name =
                SettingsForm.TextBoxPlayer2.Text;
        }
    }

    public partial class GameSettingsForm : System.Windows.Forms.Form
    {
        public GameSettingsForm()
        {
            initializeComponent();
            DatabaseBuilder = new DatabaseBuilder(this);
        }

        public eType Opponent { get; private set; } = eType.Computer;

        public DatabaseBuilder DatabaseBuilder { get; }

        private void buttonPlay_Click(object i_Sender, EventArgs i_)
        {
            DatabaseBuilder.InitializeDatabase();
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
    }
}
