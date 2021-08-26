using System;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object i_Sender, EventArgs i_)
        {
            Close();
        }

        private void checkBoxPlayer2_CheckedChanged(object i_Sender,
            EventArgs i_)
        {
            if (checkBoxPlayer2.Checked)
            {
                textBoxPlayer2.Text = "";
                textBoxPlayer2.Enabled = true;
            }
            else
            {
                textBoxPlayer2.Text = @"[Computer]";
                textBoxPlayer2.Enabled = false;
            }
        }
    }
}
