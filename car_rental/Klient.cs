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
    public partial class Klient : Form
    {
        public Klient()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(guna2PictureBox2);
            Main_frame_Load(panel1);
            Panel_Load(guna2Panel1);
            ButtonsColor(guna2Button1);
            ButtonsColor(guna2Button2);
            panel_border();

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
        private void Panel_Load(Guna2Panel panel)
        {
            //Color buttonsColor = ColorTranslator.FromHtml("#714A4A");
            string hexColor = "#714A4A";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            panel.BackColor = myColor;
        }

        private void panel_border()
        {
            Guna.UI2.WinForms.Guna2Panel panel = new Guna.UI2.WinForms.Guna2Panel();
            panel.BorderRadius = 20; // Ustawienie promienia zaokrąglenia
            panel.FillColor = Color.Blue; // Ustawienie koloru tła
            panel.Size = new Size(200, 100); // Ustawienie rozmiaru
            panel.Location = new Point(10, 10); // Ustawienie położenia na formularzu

            this.Controls.Add(panel);
        }
        public void ButtonsColor(Guna2Button button)
        {
            string hexColor = "#FFFAE2";
            Color buttonsColor = ColorTranslator.FromHtml(hexColor);
            button.BackColor = buttonsColor;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
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
