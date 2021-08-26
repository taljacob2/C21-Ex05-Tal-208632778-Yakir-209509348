using System;
using C21_Ex02_01.Com.Team.Controller.Impl;
using C21_Ex02_01.Com.Team.Database;
using C21_Ex02_01.Com.Team.Database.Board;
using C21_Ex02_01.Com.Team.Database.Players;
using C21_Ex02_01.Com.Team.Database.Players.Player;

namespace WindowsFormsUI.Com.Team.Form.Game
{
    public partial class GameSettingsForm : System.Windows.Forms.Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public eType Opponent { get; private set; } = eType.Computer;

        private void initializeDatabase()
        {
            GameControllerImpl.Database =
                new Database(
                    new Board((byte) rowsNumericUpDown.Value,
                        (byte) colsNumericUpDown.Value),
                    new Players(new Settings(Opponent)));
        }

        private void buttonPlay_Click(object i_Sender, EventArgs i_)
        {
            initializeDatabase();
            Close();
        }

        private void checkBoxPlayer2_CheckedChanged(object i_Sender,
            EventArgs i_)
        {
            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Text = "";
                textBoxPlayer2.Enabled = true;
                Opponent = eType.Human;
            }
            else
            {
                textBoxPlayer2.Text = @"[Computer]";
                textBoxPlayer2.Enabled = false;
                Opponent = eType.Computer;
            }
        }
    }
}
