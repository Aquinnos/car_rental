using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental
{
    public partial class glowna : Form
    {
        private DatabaseManager dbManager;

        public glowna()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            Panel_oferty.Visible = false;
            panel_login.Visible = false;
            panel_rejstracja.Visible = false;
            panel_profil.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dbManager.ConnectToDatabase())
            {
                // Połączenie zostało nawiązane
            }
            else
            {
                // Połączenie nie zostało nawiązane
            }
        }


        private void Login_rejstracja_Click(object sender, EventArgs e)
        {
            panel_login.Visible = true;
            panel_glowny.Visible = false;

        }

        private void oferty_Click(object sender, EventArgs e)
        {
            Panel_oferty.Visible = true;
            panel_glowny.Visible = false;
        }

        private void profil_Click(object sender, EventArgs e)
        {
            panel_profil.Visible = true;
            panel_glowny.Visible = false;
        }

        private void powrot_Click(object sender, EventArgs e)
        {
            panel_glowny.Visible = true;
            Panel_oferty.Visible = false;
            panel_login.Visible = false;
            panel_profil.Visible = false;
        }

        private void powrot_do_login_Click(object sender, EventArgs e)
        {
            panel_login.Visible = true;
            panel_rejstracja.Visible = false;
        }

        private void przejscie_do_rejstracji_Click(object sender, EventArgs e)
        {
            panel_login.Visible = false;
            panel_rejstracja.Visible = true;
        }
    }
}
