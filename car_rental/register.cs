using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace car_rental
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            this.BackColor = myColor;
        }

        private void guna2Shapes1_Load(object sender, EventArgs e)
        {
            guna2Shapes1.FillColor = ColorTranslator.FromHtml("#714A4A");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void ButtonsColor()
        {
            Color buttonsColor = ColorTranslator.FromHtml("#FFFAE2");

            foreach (Control control in this.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button button)
                {
                    button.FillColor = buttonsColor;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
