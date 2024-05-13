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
    public partial class wyporzyczanie : Form
    {
        public wyporzyczanie()
        {
            InitializeComponent();
            refresh();
            FlipPictureBoxHorizontally(guna2PictureBox2);
            Main_frame_Load(panel1);
            Main_frame_Load(panel2);
            ButtonsColor(guna2Button1);
            ButtonsColor(guna2Button2);
            heder_color();
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
        private void heder_color()
        {
            string hexColor = "#714A4A";
            Color buttonsColor = ColorTranslator.FromHtml(hexColor);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = buttonsColor;
        }
        private void Main_frame_Load(Panel panel)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            panel.BackColor = myColor;
        }
        public void ButtonsColor(Guna2Button button)
        {
            string hexColor = "#714A4A";
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


        private void rezerwuj_Click(object sender, EventArgs e)
        {
            string userID = ""; // to dać metodę zdobycia ID uzytkownika
            string id = ID_AUTA.Text;
            string rejstracja = Nr_rejs.Text;
            string Model = Model_aut.Text;
            string Marka = Marka_auta.Text;
            string cena = Cena_auta.Text;
            DateTime data_start = dateTimePicker1.Value;
            DateTime data_end = dateTimePicker2.Value;

            // zmiana wartości dostępności w cars 

            if (rejstracja=="" || Model=="" || Marka=="" || cena=="" || id=="" || data_end<=data_start)
            {
                MessageBox.Show("Błędne dane");
                return;
            }
            StringBuilder queryBuilder = new StringBuilder("UPDATE Cars set IsAvailable = 0 where Id = @id;"); // Zamienć select na update by zmienić wart

            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(queryBuilder.ToString(), connection))
                {
                    // Dodaj parametry jeśli istnieją
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        command.Parameters.AddWithValue("@id", id);
                    }
                    
                    DataTable dataTable = new DataTable();
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Ustaw wyniki jako źródło danych dla DataGridView
                    //guna2DataGridView1.DataSource = dataTable;
                    
                }

                connection.Close();
            }
            refresh();

            queryBuilder = new StringBuilder("INSERT INTO Rentals(UserId, CarId, StartDate, EndDate) values('@userID', '@id', '@data_start', '@data_end');"); // Zamienć select na update by zmienić wart

            connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(queryBuilder.ToString(), connection))
                {
                    // Dodaj parametry jeśli istnieją
                    if (!string.IsNullOrWhiteSpace(userID))
                    {
                        command.Parameters.AddWithValue("@userID", userID);
                    }
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        command.Parameters.AddWithValue("@id", $"%{id}%");
                    }
                        command.Parameters.AddWithValue("@data_start", $"%{data_start}%");
                        command.Parameters.AddWithValue("@data_end", data_end);
                    

                    DataTable dataTable = new DataTable();
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Ustaw wyniki jako źródło danych dla DataGridView
                    //guna2DataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }
        private void refresh()
        {
            // Odbierz wartości z TextBoxów
            string rejstracja = "";
            string Model = "";
            string Marka = "";
            string cena = "";

            // Buduj zapytanie SQL z wykorzystaniem filtrów
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Cars WHERE 1=1"); // Zamienć select na update by zmienić wart
            if (!string.IsNullOrWhiteSpace(rejstracja))
            {
                queryBuilder.Append(" AND RegistrationNumber = @rejstracja");
            }
            if (!string.IsNullOrWhiteSpace(Model))
            {
                queryBuilder.Append(" AND Model LIKE @Model");
            }
            if (!string.IsNullOrWhiteSpace(Marka))
            {
                queryBuilder.Append(" AND Brand LIKE @Marka");
            }
            if (!string.IsNullOrWhiteSpace(cena))
            {
                queryBuilder.Append(" AND Price = @cena");
            }

            string connectionString = "Data Source=database.sqlite;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(queryBuilder.ToString(), connection))
                {
                    // Dodaj parametry jeśli istnieją
                    if (!string.IsNullOrWhiteSpace(rejstracja))
                    {
                        command.Parameters.AddWithValue("@rejstracja", rejstracja);
                    }
                    if (!string.IsNullOrWhiteSpace(Model))
                    {
                        command.Parameters.AddWithValue("@Model", $"%{Model}%");
                    }
                    if (!string.IsNullOrWhiteSpace(Marka))
                    {
                        command.Parameters.AddWithValue("@Marka", $"%{Marka}%");
                    }
                    if (!string.IsNullOrWhiteSpace(cena))
                    {
                        command.Parameters.AddWithValue("@cena", cena);
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
    }
}
