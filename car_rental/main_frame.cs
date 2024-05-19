using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace car_rental
{

    public partial class main_frame : Form
    {

        public main_frame()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(pictureBox3);
            ButtonsColor();
        }
        public void FlipPictureBoxHorizontally(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Image);
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox.Image = bmp;
            }
        }

        private void Button7_Click_7(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser != null && SessionManager.CurrentUser.IsAdmin)
            {
                Admin_panel adminPanel = new Admin_panel();
                this.Hide();
                adminPanel.Show();
            }
            else
            {
                MessageBox.Show("Brak uprawnień. Tylko administratorzy mogą wejść na ten panel.");
            }
        }

        private void Main_frame_Load(object sender, EventArgs e)
        {
            string hexColor = "#FFFAE2"; 
            Color myColor = ColorTranslator.FromHtml(hexColor);
            this.BackColor = myColor;
        }

        public void ButtonsColor()
        {
            Color buttonsColor = ColorTranslator.FromHtml("#714A4A");
            foreach (Control control in this.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button button)
                {
                    button.FillColor = buttonsColor;
                    button.ForeColor = Color.White;
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Cars cars = new Cars();
            cars.FormClosed += (s, args) => this.Close();
            this.Hide();
            cars.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.FormClosed += (s, args) => this.Close();
            this.Hide();
            client.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Rentals rentals = new Rentals();
            rentals.FormClosed += (s, args) => this.Close();
            this.Hide();
            rentals.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("Musisz być zalogowany, aby wypożyczyć samochód.");
                return;
            }
            Return _return = new Return();
            _return.FormClosed += (s, args) => this.Close();
            this.Hide();
            _return.Show();
        }
        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SessionManager.CurrentUser = null;
            startFrame startframe = new startFrame();
            this.Close();
            startframe.Show();
        }
    }
}
