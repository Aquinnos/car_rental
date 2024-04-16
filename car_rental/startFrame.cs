﻿using Guna.UI2.WinForms;
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
    public partial class startFrame : Form
    {
        public startFrame()
        {
            InitializeComponent();
            ButtonsColor();
            FlipGuna2PictureBoxHorizontally(guna2PictureBox3);
        }

        private void startFrame_Load(object sender, EventArgs e)
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

        public void FlipGuna2PictureBoxHorizontally(Guna2PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                Bitmap originalBitmap = new Bitmap(pictureBox.Image);

                Bitmap flippedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        flippedBitmap.SetPixel(originalBitmap.Width - 1 - x, y, originalBitmap.GetPixel(x, y));
                    }
                }
                pictureBox.Image = flippedBitmap;
            }
        }
    }
}

