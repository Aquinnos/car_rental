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
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Zwrot_Load(object sender, EventArgs e)
        {
            // Odbierz wartości z TextBoxów
            string rejstracja = Nr_rejs.Text;
            string Model = Model_aut.Text;
            string Marka = Marka_auta.Text;
            string cena = Cena_auta.Text;

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
