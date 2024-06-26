﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static car_rental.Users;

namespace car_rental
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            ButtonsColor();
            FlipPictureBoxHorizontally(pictureBox3);
        }

        private void Users_Load(object sender, EventArgs e)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            this.BackColor = myColor;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string id = txtBoxId.Text;
            string firstName = txtBoxFirstName.Text;
            string lastName = txtBoxLastName.Text;
            string pesel = txtBoxPesel.Text;
            string age = txtBoxAge.Text;
            string isAdmin = comboBox1.Text;

            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Users WHERE 1=1");
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryBuilder.Append(" AND Id = @Id");
            }
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                queryBuilder.Append(" AND Name LIKE @FirstName");
            }
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                queryBuilder.Append(" AND LastName LIKE @LastName");
            }
            if (!string.IsNullOrWhiteSpace(pesel))
            {
                queryBuilder.Append(" AND Pesel = @Pesel");
            }
            if (!string.IsNullOrWhiteSpace(age))
            {
                queryBuilder.Append(" AND Age = @Age");
            }
            if(!string.IsNullOrWhiteSpace(isAdmin))
            {
                queryBuilder.Append(" AND isAdmin = @isAdmin");
            }

            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(queryBuilder.ToString(), connection))
                {
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                    }
                    if (!string.IsNullOrWhiteSpace(firstName))
                    {
                        command.Parameters.AddWithValue("@FirstName", $"%{firstName}%");
                    }
                    if (!string.IsNullOrWhiteSpace(lastName))
                    {
                        command.Parameters.AddWithValue("@LastName", $"%{lastName}%");
                    }
                    if (!string.IsNullOrWhiteSpace(pesel))
                    {
                        command.Parameters.AddWithValue("@Pesel", pesel);
                    }
                    if (!string.IsNullOrWhiteSpace(age))
                    {
                        command.Parameters.AddWithValue("@Age", age);
                    }
                    if (!string.IsNullOrWhiteSpace(isAdmin))
                    {
                        command.Parameters.AddWithValue("@isAdmin", isAdmin);
                    }

                    DataTable dataTable = new DataTable();
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    guna2DataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
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
            Color buttonsColor = ColorTranslator.FromHtml("#714A4A"); 

            foreach (Control control in this.Controls)
            {
                if (control is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)control;
                    button.FillColor = buttonsColor;
                    button.ForeColor = Color.White;
                }
            }
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
    }
}
