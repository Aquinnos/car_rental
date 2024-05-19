using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace car_rental
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(pictureBox3);
            ButtonsColor();
        }

        private void register_Load(object sender, EventArgs e)
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
                if (control is Guna2Button button)
                {
                    button.FillColor = buttonsColor;
                    button.ForeColor = Color.White;
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            startFrame startframe = new startFrame();
            startframe.FormClosed += (s, args) => this.Close();
            this.Hide();
            startframe.Show();
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

        private string connectionString = "Data Source=database.sqlite;Version=3;";

        public bool RegisterUser(string firstName, string lastName, string username, string password)
        {
            string hashedPassword = HashPassword(password);
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (FirstName, LastName, Username, Password, isAdmin) VALUES (@FirstName, @LastName, @Username, @Password, 'Nie')";

                    using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);

                        command.ExecuteNonQuery();
                    }
                }

                return true; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; 
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string firstName = imie.Text;
            string lastName = nazwisko.Text;
            string username = nazwa.Text;
            string password = haslo.Text;

            register dbAccess = new register();
            bool isRegistered = dbAccess.RegisterUser(firstName, lastName, username, password);

            if (isRegistered)
            {
                MessageBox.Show("Rejestracja pomyślna!");
            }
            else
            {
                MessageBox.Show("Rejestracja nieudana. Sprawdź logi!");
            }
        }
    }
}
