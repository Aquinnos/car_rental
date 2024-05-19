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

namespace car_rental
{
    public partial class Del_users : Form
    {
        public Del_users()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(pictureBox3);
            ButtonsColor();
        }

        private void Del_users_Load(object sender, EventArgs e)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            this.BackColor = myColor;

            string firstName = txtBoxFirstName.Text;
            string lastName = txtBoxLastName.Text;
            string pesel = txtBoxPesel.Text;
            string age = txtBoxAge.Text;

            StringBuilder queryBuilder = new StringBuilder("SELECT Id,FirstName, LastName, Pesel, Age FROM Users WHERE 1=1");
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

            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(queryBuilder.ToString(), connection))
                {
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtBoxId.Text;
            string firstName = txtBoxFirstName.Text;
            string lastName = txtBoxLastName.Text;
            string pesel = txtBoxPesel.Text;
            string age = txtBoxAge.Text;

            StringBuilder queryBuilder = new StringBuilder("DELETE FROM Users WHERE ");
            List<SQLiteParameter> parameters = new List<SQLiteParameter>();

            if (!string.IsNullOrEmpty(id))
            {
                queryBuilder.Append("Id = @Id");
                parameters.Add(new SQLiteParameter("@Id", id));
            }
            else
            {
                List<string> conditions = new List<string>();

                if (!string.IsNullOrEmpty(firstName))
                {
                    conditions.Add("Name = @Name");
                    parameters.Add(new SQLiteParameter("@Name", firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    conditions.Add("Surname = @Surname");
                    parameters.Add(new SQLiteParameter("@Surname", lastName));
                }
                if (!string.IsNullOrEmpty(pesel))
                {
                    conditions.Add("Pesel = @Pesel");
                    parameters.Add(new SQLiteParameter("@Pesel", pesel));
                }
                if (!string.IsNullOrEmpty(age))
                {
                    conditions.Add("Age = @Age");
                    parameters.Add(new SQLiteParameter("@Age", age));
                }

                if (!conditions.Any())
                {
                    MessageBox.Show("Proszę podać przynajmniej jedno kryterium wyszukiwania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                queryBuilder.Append(string.Join(" AND ", conditions));
            }

            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(queryBuilder.ToString(), connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Użytkownik(cy) zostali usunięci.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nie znaleziono użytkownika(ów) spełniających podane kryteria.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();
            }
            RefreshUserList();
        }

        private void RefreshUserList()
        {
            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT Id, FirstName, LastName, Pesel, Age FROM Users", connection))
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
