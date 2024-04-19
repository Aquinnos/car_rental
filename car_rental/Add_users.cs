using Guna.UI2.WinForms;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace car_rental
{
    public partial class Add_users : Form
    {
        public Add_users()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(pictureBox3);
            ButtonsColor();
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

        private void Add_users_Load(object sender, EventArgs e)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            this.BackColor = myColor;

            string username = txtBoxName.Text;
            string password = txtBoxPass.Text;
            string firstName = txtBoxFirstName.Text;
            string lastName = txtBoxLastName.Text;
            string pesel = txtBoxPesel.Text;
            string age = txtBoxAge.Text;
            string isAdmin = txtBoxAdmin.Text;

            // Buduj zapytanie SQL z wykorzystaniem filtrów
            StringBuilder queryBuilder = new StringBuilder("SELECT Id, Username, Password, FirstName, LastName, Pesel, Age, isAdmin FROM Users WHERE 1=1"); 
            if (!string.IsNullOrWhiteSpace(username))
            {
                queryBuilder.Append(" AND Username = @Username");
            }
            if (!string.IsNullOrWhiteSpace(password))
            {
                queryBuilder.Append(" AND Password = @Password");
            }
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                queryBuilder.Append(" AND FirstName LIKE @FirstName");
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
            if (!string.IsNullOrWhiteSpace(isAdmin))
            {
                queryBuilder.Append(" AND isAdmin = @isAdmin");
            }

            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(queryBuilder.ToString(), connection))
                {
                    // Dodaj parametry jeśli istnieją
                    if (!string.IsNullOrWhiteSpace(username))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                    }
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        command.Parameters.AddWithValue("@Password", password);
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

                    // Ustaw wyniki jako źródło danych dla DataGridView
                    guna2DataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = txtBoxName.Text;
            string password = txtBoxPass.Text;
            string firstName = txtBoxFirstName.Text;
            string lastName = txtBoxLastName.Text;
            string pesel = txtBoxPesel.Text;
            string age = txtBoxAge.Text;
            string isAdmin = txtBoxAdmin.Text;

            AddUser(username, password, firstName, lastName, pesel, age, isAdmin);
            RefreshUserList();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void AddUser(string username, string password, string firstName, string lastName, string pesel, string age, string isAdmin)
        {
            string hashedPassword = HashPassword(password);

            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("INSERT INTO Users (Username, Password, FirstName, LastName, Pesel, Age, IsAdmin) VALUES (@Username, @Password, @FirstName, @LastName, @Pesel, @Age, @IsAdmin)", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", hashedPassword);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Pesel", pesel);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin); // SQLite używa 1 i 0 dla wartości true i false

                    command.ExecuteNonQuery();
                }

                connection.Close();
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

        private void RefreshUserList()
        {
            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT Id, Username, Password, FirstName, LastName, Pesel, Age, isAdmin FROM Users", connection))
                {
                    DataTable dataTable = new DataTable();
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Ustaw wyniki jako źródło danych dla DataGridView
                    guna2DataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }
    }
}
