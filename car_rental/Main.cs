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
    public partial class Main : Form
    {
        private DatabaseManager dbManager;

        public Main()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dbManager.ConnectToDatabase())
            {
                // Połączenie zostało nawiązane
                //
            }
            else
            {
                // Połączenie nie zostało nawiązane
            }
        }
    }
}
