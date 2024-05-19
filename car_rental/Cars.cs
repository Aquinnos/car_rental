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
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(guna2PictureBox2);
            ButtonsColor(guna2Button1);
            ButtonsColor(guna2Button2);
            Main_frame_Load(panel1);
            Main_frame_Load(panel2);
            header_color();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            main_frame main_frame = new main_frame();
            main_frame.FormClosed += (s, args) => this.Close();
            this.Hide();
            main_frame.Show();
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

        public void ButtonsColor(Guna2Button button)
        {
            string hexColor = "#714A4A";
            Color buttonsColor = ColorTranslator.FromHtml(hexColor);
            button.BackColor = buttonsColor;
        }

        private void header_color()
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

        private string connectionString = "Data Source=database.sqlite;Version=3;";
        private void wyszukaj_Click(object sender, EventArgs e)
        {
            string rejstracja = Nr_rejs.Text;
            string Model = Model_aut.Text;
            string Marka = Marka_auta.Text;
            string cena = Cena_auta.Text;
            string dostempnosc = comboBox1.Text;

            {
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
                        guna2DataGridView1.DataSource = dataTable;
                    }
                    connection.Close();
                }
            }
        }

        private void samochody_Load(object sender, EventArgs e)
        {
            string rejestracja = Nr_rejs.Text;
            string Model = Model_aut.Text;
            string Marka = Marka_auta.Text;
            string cena = Cena_auta.Text;
            string dostepnosc = comboBox1.Text;

            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Cars WHERE 1=1");
            if (!string.IsNullOrWhiteSpace(rejestracja))
            {
                queryBuilder.Append(" AND RegistrationNumber = @rejestracja");
            }
            if (!string.IsNullOrWhiteSpace(Model))
            {
                queryBuilder.Append(" AND Model LIKE @Model");
            }
            if (!string.IsNullOrWhiteSpace(Marka))
            {
                queryBuilder.Append(" AND Brand LIKE @Marka");
            }
            if (!string.IsNullOrWhiteSpace(dostepnosc))
            {
                queryBuilder.Append(" AND IsAvailable = @dostepnosc");
            }
            if (!string.IsNullOrWhiteSpace(cena))
            {
                queryBuilder.Append(" AND Price = @cena");
            }

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(queryBuilder.ToString(), connection))
                {
                    if (!string.IsNullOrWhiteSpace(rejestracja))
                    {
                        command.Parameters.AddWithValue("@rejstracja", rejestracja);
                    }
                    if (!string.IsNullOrWhiteSpace(Model))
                    {
                        command.Parameters.AddWithValue("@Model", $"%{Model}%");
                    }
                    if (!string.IsNullOrWhiteSpace(Marka))
                    {
                        command.Parameters.AddWithValue("@Marka", $"%{Marka}%");
                    }
                    if (!string.IsNullOrWhiteSpace(dostepnosc))
                    {
                        command.Parameters.AddWithValue("@dostepnosc", dostepnosc);
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
                    guna2DataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }
    }
}

