﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                // Utwórz kopię obrazu z PictureBox
                Bitmap bmp = new Bitmap(pictureBox.Image);

                // Odwróć obraz w poziomie
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Ustaw odwrócony obraz z powrotem na PictureBox
                pictureBox.Image = bmp;
            }
        }

        private void Button7_Click_7(object sender, EventArgs e)
        {
            Admin_panel adminPanel = new Admin_panel();
            adminPanel.FormClosed += (s, args) => this.Close();
            this.Hide();
            adminPanel.Show();
        }

        private void Main_frame_Load(object sender, EventArgs e)
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
                if (control is Guna.UI2.WinForms.Guna2Button button)
                {

                    // Ustaw kolor tła przycisku
                    button.FillColor = buttonsColor;

                    // Opcjonalnie: Ustaw kolor czcionki, jeśli potrzebujesz
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
            Return _return = new Return();
            _return.FormClosed += (s, args) => this.Close();
            this.Hide();
            _return.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }
    }
}
