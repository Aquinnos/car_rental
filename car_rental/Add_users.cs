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
using System.Xml.Linq;
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
                //kopia obrazu z PictureBox
                Bitmap bmp = new Bitmap(pictureBox.Image);
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                // Ustawienie odwróconego obrazu z powrotem na PictureBox
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
            string isAdmin = comboBox1.Text;

            txtBoxPass.PasswordChar = '*';

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
            string isAdmin = comboBox1.Text;

            if (string.IsNullOrWhiteSpace(username) &&
                string.IsNullOrWhiteSpace(password) &&
                string.IsNullOrWhiteSpace(firstName) &&
                string.IsNullOrWhiteSpace(lastName) &&
                string.IsNullOrWhiteSpace(pesel) &&
                string.IsNullOrWhiteSpace(age))
            {
                MessageBox.Show("Nie wpisano żadnego kryterium. Proszę wypełnić przynajmniej jedno pole.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtBoxPesel.Text.Length != 11)
            {
                MessageBox.Show("PESEL musi mieć 11 znaków.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddUser(username, password, firstName, lastName, pesel, age, isAdmin);
            RefreshUserList();
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
                    command.Parameters.AddWithValue("@IsAdmin", isAdmin);

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
                    guna2DataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }
    }
}
