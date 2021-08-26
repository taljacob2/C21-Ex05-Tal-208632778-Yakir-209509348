using System.Windows.Forms;

namespace WindowsFormsUI.Com.Team.Form
{
    public partial class GameForm : System.Windows.Forms.Form
    {
        public GameForm()
        {
            Application.Run(new GameSettingsForm()); // Run settings windows.
            InitializeComponent();
        }
        
    }
}
