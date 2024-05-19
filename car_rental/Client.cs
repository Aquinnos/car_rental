using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace car_rental
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(guna2PictureBox2);
            Main_frame_Load(panel1);
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
        private void Main_frame_Load(Panel panel)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            panel.BackColor = myColor;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            main_frame main_Frame = new main_frame();
            main_Frame.FormClosed += (s, args) => this.Close();
            this.Hide();
            main_Frame.Show();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int age;
            if (!string.IsNullOrWhiteSpace(Pesel.Text) && Pesel.Text.Length != 11)
            {
                MessageBox.Show("PESEL musi zawierać dokładnie 11 znaków.");
                return;
            }
            if (string.IsNullOrWhiteSpace(naz_uz.Text))
            {
                MessageBox.Show("Nazwa użytkownika nie może być pusta.");
                return;
            }
            if (!int.TryParse(wiek.Text, out age))
            {
                MessageBox.Show("Wprowadzony wiek jest nieprawidłowy. Proszę wprowadzić liczbę.");
                age = SessionManager.CurrentUser.Age; 
            }

            if (!string.IsNullOrWhiteSpace(wiek.Text) && age < 18)
            {
                MessageBox.Show("Użytkownik musi być pełnoletni (18 lat lub więcej).");
                return;
            }

            User updatedUser = new User
            {
                Id = SessionManager.CurrentUser.Id,
                Username = naz_uz.Text,
                FirstName = imie.Text,
                LastName = nazwisko.Text,
                Pesel = string.IsNullOrWhiteSpace(Pesel.Text) ? SessionManager.CurrentUser.Pesel : Pesel.Text,
                Age = age,
                DrivingLicense = nr_prawa_jaz.Text
            };

            UpdateUserInDatabase(updatedUser);
        }

        private static string connectionString = "Data Source=database.sqlite;Version=3;";

        private void UpdateUserInDatabase(User user)
        {
            List<string> setClauses = new List<string>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                if (!string.IsNullOrWhiteSpace(user.Username))
                    setClauses.Add("Username = @Username");
                if (!string.IsNullOrWhiteSpace(user.Password))
                    setClauses.Add("Password = @Password");
                if (!string.IsNullOrWhiteSpace(user.FirstName))
                    setClauses.Add("FirstName = @FirstName");
                if (!string.IsNullOrWhiteSpace(user.LastName))
                    setClauses.Add("LastName = @LastName");
                if (!string.IsNullOrWhiteSpace(user.Pesel))
                    setClauses.Add("Pesel = @Pesel");
                if (!string.IsNullOrWhiteSpace(user.DrivingLicense))
                    setClauses.Add("DrivingLicense = @DrivingLicense");
                if (user.Age > 0)
                    setClauses.Add("Age = @Age");

                if (setClauses.Count == 0)
                {
                    MessageBox.Show("Brak danych do aktualizacji.");
                    return;
                }

                string query = $"UPDATE Users SET {string.Join(", ", setClauses)} WHERE Id = @Id;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    if (setClauses.Contains("Username = @Username"))
                        command.Parameters.AddWithValue("@Username", user.Username);
                    if (setClauses.Contains("Password = @Password"))
                        command.Parameters.AddWithValue("@Password", user.Password);
                    if (setClauses.Contains("FirstName = @FirstName"))
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    if (setClauses.Contains("LastName = @LastName"))
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                    if (setClauses.Contains("Pesel = @Pesel"))
                        command.Parameters.AddWithValue("@Pesel", user.Pesel);
                    if (setClauses.Contains("Age = @Age"))
                        command.Parameters.AddWithValue("@Age", user.Age);
                    if (setClauses.Contains("DrivingLicense = @DrivingLicense"))
                        command.Parameters.AddWithValue("@DrivingLicense", user.DrivingLicense);
                    command.Parameters.AddWithValue("@Id", user.Id);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Dane użytkownika zostały zaktualizowane.");
                    else
                        MessageBox.Show("Aktualizacja danych nie powiodła się.");
                }
                connection.Close();
            }
        }
    }
}
