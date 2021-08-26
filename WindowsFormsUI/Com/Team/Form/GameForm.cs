using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using C21_Ex02_01.Com.Team.Engine;

namespace WindowsFormsUI.Com.Team.Form
{
    public partial class GameForm : System.Windows.Forms.Form
    {
        public GameForm()
        {
            Application.Run(new GameSettingsForm()); // Run settings windows.
            InitializeComponent();
        }

        // private void createColumnButtons()
        // {
        //     for (int i = 1; i <= Engine.Database.Board.Cols; i++)
        //     {
        //         Button button = new Button();
        //         const int k_Width = 69;
        //         const int k_Height = 34;
        //         const int k_X = 12;
        //         const int k_Y = 12;
        //
        //         button.BackColor = SystemColors.Highlight;
        //         button.Location = new Point(k_X + (i - 1) * k_Width, k_Y);
        //         button.Name = "buttonColumn" + i;
        //         button.Size = new Size(k_Width, k_Height);
        //         button.TabIndex = i;
        //         button.Text = i.ToString();
        //         button.UseVisualStyleBackColor = false;
        //
        //         // Add button to list:
        //         buttonColumnList.Add(button);
        //     }
        // }

        // private void addColumnButtons()
        // {
        //     foreach (Button button in buttonColumnList)
        //     {
        //         Controls.Add(button);
        //     }
        // }
    }
}
