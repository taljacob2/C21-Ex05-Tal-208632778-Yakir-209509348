using System.Drawing;
using System.Windows.Forms;

namespace C21_Ex05_01.Com.Team.Form
{
    public class FormUI : System.Windows.Forms.Form
    {
        public FormUI()
        {
            initialize();
        }

        private void initialize()
        {
            this.Text = "Connect 4";
            this.BackColor = Color.Aqua;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D; // Fixed borders.
        }
    }
}
