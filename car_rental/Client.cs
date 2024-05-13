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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(guna2PictureBox2);
            Main_frame_Load(panel1);
            ButtonsColor(guna2Button1);
            ButtonsColor(guna2Button2);

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
        private void Main_frame_Load(Panel panel)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            panel.BackColor = myColor;
        }
        public void ButtonsColor(Guna2Button button)
        {
            string hexColor = "#FFFAE2";
            Color buttonsColor = ColorTranslator.FromHtml(hexColor);
            button.BackColor = buttonsColor;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            main_frame main_Frame = new main_frame();
            main_Frame.FormClosed += (s, args) => this.Close();
            this.Hide();
            main_Frame.Show();
        }

        private void zapisz_Click(object sender, EventArgs e)
        {
            if (imie.Text == "" || haslo.Text == "" || naz_uz.Text == "" || nazwisko.Text == "" || Pesel.Text == "" || wiek.Text == "" || nr_prawa_jaz.Text == "")
            {
                MessageBox.Show("występują braki w danych danych");
            }
        }
    }
}
