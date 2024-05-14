using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(pictureBox1);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            startFrame startframe = new startFrame();
            this.Close();
            startframe.Show();
        }

        private string connectionString = "Data Source=database.sqlite;Version=3;";

        public User LoginUser(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT Id, FirstName, LastName, Pesel, Age, isAdmin FROM Users WHERE Username = @Username AND Password = @Password";

                    using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Username = username,
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    Pesel = reader.IsDBNull(reader.GetOrdinal("Pesel")) ? null : reader.GetString(reader.GetOrdinal("Pesel")),
                                    Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? 0 : reader.GetInt32(reader.GetOrdinal("Age")),
                                    isAdmin = reader.IsDBNull(reader.GetOrdinal("isAdmin")) ? "Nie" : reader.GetString(reader.GetOrdinal("isAdmin"))
                                };
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("SQLite exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General exception: " + ex.Message);
            }
            return null;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = nazwa.Text;
            string password = haslo.Text;

            User user = this.LoginUser(username, password);

            if (user != null)
            {
                SessionManager.CurrentUser = user;
                MessageBox.Show("Logowanie pomyślne!");
                main_frame main_Frame = new main_frame();
                this.Close();
                main_Frame.Show();
            }
            else
            {
                MessageBox.Show("Błąd logowania. Sprawdź nazwę użytkownika i hasło.");
            }
        }
    }
}
