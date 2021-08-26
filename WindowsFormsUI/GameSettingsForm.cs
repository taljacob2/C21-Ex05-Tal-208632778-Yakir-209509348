using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void ButtonPlay_Click(object i_Sender, EventArgs i_)
        {
            this.Close();
        }

        private void CheckBoxPlayer2_CheckedChanged(object i_Sender, EventArgs i_)
        {
            if(this.CheckBoxPlayer2.Checked){
                this.TextBoxPlayer2.Text = "";
                this.TextBoxPlayer2.Enabled = true;
            }
            else
            {
                this.TextBoxPlayer2.Text = @"[Computer]";
                this.TextBoxPlayer2.Enabled = false;
            }
        }
    }
}
