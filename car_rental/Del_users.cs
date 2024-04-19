using Guna.UI2.WinForms;
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
    public partial class Del_users : Form
    {
        public Del_users()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(pictureBox3);
            ButtonsColor();
        }

        private void Del_users_Load(object sender, EventArgs e)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            this.BackColor = myColor;
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Admin_panel adminPanel = new Admin_panel();
            adminPanel.FormClosed += (s, args) => this.Close();
            this.Hide();
            adminPanel.Show();
        }

        public void ButtonsColor()
        {
            // Definiuj kolor, który chcesz użyć
            Color buttonsColor = ColorTranslator.FromHtml("#714A4A"); // Przykładowy kolor szesnastkowy

            // Przechodź przez wszystkie kontrolki na formularzu
            foreach (Control control in this.Controls)
            {
                // Sprawdź, czy kontrolka jest przyciskiem Guna.UI2
                if (control is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)control;

                    // Ustaw kolor tła przycisku
                    button.FillColor = buttonsColor;

                    // Opcjonalnie: Ustaw kolor czcionki, jeśli potrzebujesz
                    button.ForeColor = Color.White;
                }
            }
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
    }
}
