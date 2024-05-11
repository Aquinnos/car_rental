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
    public partial class samochody : Form
    {
        public samochody()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(guna2PictureBox2);
            ButtonsColor(guna2Button1);
            ButtonsColor(guna2Button2);
            Main_frame_Load(panel1);
            Main_frame_Load(panel2);
            heder_color();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
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

        public void ButtonsColor(Guna2Button button)
        {
            string hexColor = "#714A4A";
            Color buttonsColor = ColorTranslator.FromHtml(hexColor);
            button.BackColor = buttonsColor;
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

        private void wyszukaj_Click(object sender, EventArgs e)
        {
            // Odbierz wartości z TextBoxów
            string rejstracja = Nr_rejs.Text;
            string Model = Model_aut.Text;
            string Marka = Marka_auta.Text;
            string cena = Cena_auta.Text;
            string dostempnosc = comboBox1.Text;

            // Buduj zapytanie SQL z wykorzystaniem filtrów
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Cars WHERE 1=1");
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
            if (!string.IsNullOrWhiteSpace(dostempnosc))
            {
                queryBuilder.Append(" AND IsAvailable = @dostempnosc");
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
                    if (!string.IsNullOrWhiteSpace(dostempnosc))
                    {
                        command.Parameters.AddWithValue("@dostempnosc", dostempnosc);
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
            /*
            if (Nr_rejs.Text == "" && Model_aut.Text == "" && Marka_auta.Text == "" && Cena_auta.Text == "")
            {
                MessageBox.Show("za mało informacji");
            }
            else
            {
                
                try
                { 
                    
                
                }
                catch(Exception Myexe) 
                {
                    MessageBox.Show(Myexe.Message);
                }
                
                string connectionString = "Data Source=database.sqlite;Version=3;";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Wartość, którą chcemy wyszukać
                    string rejstracja = Nr_rejs.Text;
                    string model = Model_aut.Text;
                    string marka = Marka_auta.Text;
                    string cena = Cena_auta.Text;
                    string dostempnosc = comboBox1.Text;
                    string sql = "SELECT * FROM Cars WHERE RegistrationNumber = @rejstracja AND Brand = @marka AND Model = @model AND IsAvailable = @dostempnosc";
                    // string sql = "SELECT * FROM Cars JOIN Rentals ON Cars.CarId = Rentals.CarId WHERE RegistrationNumber = @rejstracja AND Brand = @marka AND Model = @model AND Price = @cena AND IsAvailable = @dostempnosc";
                    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@rejstracja", rejstracja);
                        command.Parameters.AddWithValue("@marka", marka);
                        //command.Parameters.AddWithValue("@cena", cena);
                        command.Parameters.AddWithValue("@model", model);
                        command.Parameters.AddWithValue("@dostempnosc", dostempnosc);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                            {
                                adapter.Fill(dataTable);
                            }

                            // Ustaw wyniki jako źródło danych dla DataGridView
                            guna2DataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
        */
        }

        private void samochody_Load(object sender, EventArgs e)
        {
            // Odbierz wartości z TextBoxów
            string rejstracja = Nr_rejs.Text;
            string Model = Model_aut.Text;
            string Marka = Marka_auta.Text;
            string cena = Cena_auta.Text;
            string dostempnosc = comboBox1.Text;

            // Buduj zapytanie SQL z wykorzystaniem filtrów
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Cars WHERE 1=1");
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
            if (!string.IsNullOrWhiteSpace(dostempnosc))
            {
                queryBuilder.Append(" AND IsAvailable = @dostempnosc");
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
                    if (!string.IsNullOrWhiteSpace(dostempnosc))
                    {
                        command.Parameters.AddWithValue("@dostempnosc", dostempnosc);
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

