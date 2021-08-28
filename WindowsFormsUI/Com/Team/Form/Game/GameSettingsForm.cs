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
            initializeComponent();
        }

        public eType Opponent { get; private set; } = eType.Computer;

        private void initializeDatabase()
        {
            initializeBoard();
            initializePlayersNames();
        }

        private void initializeBoard()
        {
            GameControllerImpl.Database =
                new Database(
                    new Board((byte) m_RowsNumericUpDown.Value,
                        (byte) m_ColsNumericUpDown.Value),
                    new Players(new Settings(Opponent)));
        }
        
        private void initializePlayersNames()
        {
            Players players = GameControllerImpl.Database.Players;
            players.GetPlayerOne().Name = m_TextBoxPlayer1.Text;
            players.GetPlayerTwo().Name = m_TextBoxPlayer2.Text;
        }

        private void buttonPlay_Click(object i_Sender, EventArgs i_)
        {
            initializeDatabase();
            Close();
        }
        
        private void checkBoxPlayer2_CheckedChanged(object i_Sender,
            EventArgs i_)
        {
            if (m_CheckBoxPlayer2.Checked)
            {
                m_TextBoxPlayer2.Text = @"Player 2";
                m_TextBoxPlayer2.Enabled = true;
                Opponent = eType.Human;
            }
            else
            {
                m_TextBoxPlayer2.Text = @"[Computer]";
                m_TextBoxPlayer2.Enabled = false;
                Opponent = eType.Computer;
            }
        }
    }
}
