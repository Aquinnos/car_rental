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
    public partial class Admin_panel : Form
    {
        public Admin_panel()
        {
            InitializeComponent();
            ButtonsColor();
            FlipPictureBoxHorizontally(pictureBox3);
        }

        private void admin_panel_Load(object sender, EventArgs e)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            this.BackColor = myColor;
        }

        public void ButtonsColor()
        {
            // Definiuj kolor, który chcesz użyć
            Color buttonsColor = ColorTranslator.FromHtml("#714A4A"); // Przykładowy kolor szesnastkowy

            // Przechodź przez wszystkie kontrolki na formularzu
            foreach (Control control in this.Controls)
            {
                // Sprawdź, czy kontrolka jest przyciskiem Guna.UI2
                if (control is Guna.UI2.WinForms.Guna2Button)
                {
                    Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)control;

                    // Ustaw kolor tła przycisku
                    button.FillColor = buttonsColor;

                    // Opcjonalnie: Ustaw kolor czcionki, jeśli potrzebujesz
                    button.ForeColor = Color.White;
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            main_frame mainFrame = new main_frame();
            mainFrame.FormClosed += (s, args) => this.Close();
            this.Hide();
            mainFrame.Show();
        }

        public void FlipPictureBoxHorizontally(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                // Utwórz kopię obrazu z PictureBox
                Bitmap bmp = new Bitmap(pictureBox.Image);

                // Odwróć obraz w poziomie
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Ustaw odwrócony obraz z powrotem na PictureBox
                pictureBox.Image = bmp;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.FormClosed += (s, args) => this.Close();
            this.Hide();
            users.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Add_users add_users = new Add_users();
            add_users.FormClosed += (s, args) => this.Close();
            this.Hide();
            add_users.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Del_users del_users = new Del_users();
            del_users.FormClosed += (s, args) => this.Close();
            this.Hide();
            del_users.Show();
        }
    }
}
