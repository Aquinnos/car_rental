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
    public partial class Zwrot : Form
    {
        public Zwrot()
        {
            InitializeComponent();
            FlipPictureBoxHorizontally(guna2PictureBox2);
            refresh();
            Main_frame_Load(panel1);
            Main_frame_Load(panel2);
            ButtonsColor(guna2Button1);
            ButtonsColor(guna2Button2);
            heder_color();
        }
        private void heder_color()
        {
            string hexColor = "#714A4A";
            Color buttonsColor = ColorTranslator.FromHtml(hexColor);
            guna2DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = buttonsColor;
            guna2DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = buttonsColor;
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }
        private void refresh()
        {
            // Odbierz wartości z TextBoxów
            string rejstracja = "";
            string Model = "";
            string Marka = "";
            string cena = "";
            
            string userID = ""; // to dać metodę zdobycia ID uzytkownika
            string id = "";
            string data_start = "";
            string data_end = "";

            //tutaj dać zapytanie takie by spełniało figme

            // Buduj zapytanie SQL z wykorzystaniem filtrów
            StringBuilder queryBuilder = new StringBuilder("SELECT * FROM Rentals WHERE 1=1"); // Zamienć select na update by zmienić wart
            if (!string.IsNullOrWhiteSpace(userID))
            {
                queryBuilder.Append(" AND UserID = @userID");
            }
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryBuilder.Append(" AND CarId LIKE @id");
            }
            if (!string.IsNullOrWhiteSpace(data_start))
            {
                queryBuilder.Append(" AND StartDate LIKE @data_start");
            }
            if (!string.IsNullOrWhiteSpace(data_end))
            {
                queryBuilder.Append(" AND EndDate = @data_end");
            }

            string connectionString = "Data Source=database.sqlite;Version=3;";
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
                    if (!string.IsNullOrWhiteSpace(data_start))
                    {
                        command.Parameters.AddWithValue("@data_start", $"%{data_start}%");
                    }
                    if (!string.IsNullOrWhiteSpace(data_end))
                    {
                        command.Parameters.AddWithValue("@data_end", data_end);
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

            // jeszcze rz to samo ale ustawia 2 datagrid (historie)
            //tutaj dać zapytanie takie by spełniało figme
            queryBuilder = new StringBuilder("SELECT * FROM Rentals WHERE 1=1"); 
            if (!string.IsNullOrWhiteSpace(userID))
            {
                queryBuilder.Append(" AND UserID = @userID");
            }
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryBuilder.Append(" AND CarId LIKE @id");
            }
            if (!string.IsNullOrWhiteSpace(data_start))
            {
                queryBuilder.Append(" AND StartDate LIKE @data_start");
            }
            if (!string.IsNullOrWhiteSpace(data_end))
            {
                queryBuilder.Append(" AND EndDate = @data_end");
            }

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
                    if (!string.IsNullOrWhiteSpace(data_start))
                    {
                        command.Parameters.AddWithValue("@data_start", $"%{data_start}%");
                    }
                    if (!string.IsNullOrWhiteSpace(data_end))
                    {
                        command.Parameters.AddWithValue("@data_end", data_end);
                    }

                    DataTable dataTable = new DataTable();
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Ustaw wyniki jako źródło danych dla DataGridView
                    guna2DataGridView2.DataSource = dataTable;
                }

                connection.Close();
            }
        }

        private void oddaj_i_zaplac_Click(object sender, EventArgs e)
        {
            string userID = ""; // to dać metodę zdobycia ID uzytkownika
            string id = ID_AUTA.Text;
            string rejstracja = Nr_rejs.Text;
            string Model = Model_aut.Text;
            string Marka = Marka_auta.Text;
            string cena = Cena_auta.Text;
            string data_start = "";
            string data_end = "";

            // zmiana wartości dostępności w cars 

            if (rejstracja == "" || Model == "" || Marka == "" || cena == "" || id == "" )
            {
                MessageBox.Show("Błędne dane");
                return;
            }
            StringBuilder queryBuilder = new StringBuilder("UPDATE Cars set IsAvailable = 1 where Id = @id;"); // Zamienć select na update by zmienić wart

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

            //tutaj zmienia status Rentala na zakończony by pokazywał się w histori jakoś

            refresh();

        }
    }
}
