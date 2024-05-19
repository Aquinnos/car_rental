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
    public partial class Return : Form
    {
        public Return()
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
            guna2DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = buttonsColor;
        }
        private void Main_frame_Load(Panel panel)
        {
            string hexColor = "#FFFAE2";
            Color myColor = ColorTranslator.FromHtml(hexColor);
            panel.BackColor = myColor;
            LoadRentedCars();
            LoadReturnedCars();
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
                Bitmap bmp = new Bitmap(pictureBox.Image);
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBox.Image = bmp;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            main_frame main_Frame = new main_frame();
            main_Frame.FormClosed += (s, args) => this.Close();
            this.Hide();
            main_Frame.Show();
        }

        private string connectionString = "Data Source=database.sqlite;Version=3;";

        private Car GetCarByRegistrationNumber(string registrationNumber)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cars WHERE RegistrationNumber = @RegistrationNumber";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RegistrationNumber", registrationNumber);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Car
                            {
                                CarId = Convert.ToInt32(reader["CarId"]),
                                Brand = reader["Brand"].ToString(),
                                Model = reader["Model"].ToString(),
                                RegistrationNumber = reader["RegistrationNumber"].ToString(),
                                Price = Convert.ToDouble(reader["Price"]),
                                IsAvailable = reader["IsAvailable"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("Musisz być zalogowany, aby wypożyczać i oddawać samochód.");
                return;
            }
            if (!ValidateReturnInputs())
            {
                return;
            }

            Car car = GetCarByRegistrationNumber(Nr_rejs.Text);
            if (car == null)
            {
                MessageBox.Show("Nie znaleziono samochodu o podanym numerze rejestracyjnym.");
                return;
            }

            ReturnCar(car);

            LoadRentedCars();
            LoadReturnedCars();
        }

        private bool ValidateReturnInputs()
        {
            if (string.IsNullOrWhiteSpace(Nr_rejs.Text))
            {
                MessageBox.Show("Numer rejestracyjny nie może być pusty.");
                return false;
            }

            return true;
        }
        private void ReturnCar(Car car)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Zaktualizuj dostępność samochodu
                        string updateCarQuery = "UPDATE Cars SET IsAvailable = 'Tak' WHERE CarId = @CarId";
                        using (var updateCarCommand = new SQLiteCommand(updateCarQuery, connection))
                        {
                            updateCarCommand.Parameters.AddWithValue("@CarId", car.CarId);
                            updateCarCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Samochód został pomyślnie zwrócony.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Wystąpił błąd podczas zwrotu samochodu: " + ex.Message);
                    }
                }
                connection.Close();
            }
        }

        private void LoadRentedCars()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT r.RentalId, r.UserId, r.CarId, r.StartDate, r.EndDate, c.Brand, c.Model, c.RegistrationNumber
            FROM Rentals r
            JOIN Cars c ON r.CarId = c.CarId
            WHERE r.UserId = @UserId AND c.IsAvailable = 'Nie'";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        guna2DataGridView1.DataSource = dt;
                    }
                }
                connection.Close();
            }
        }

        private void LoadReturnedCars()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT r.RentalId, r.UserId, r.CarId, r.StartDate, r.EndDate, c.Brand, c.Model, c.RegistrationNumber
            FROM Rentals r
            JOIN Cars c ON r.CarId = c.CarId
            WHERE r.UserId = @UserId AND c.IsAvailable = 'Tak'";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                    using (var reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        guna2DataGridView2.DataSource = dt;
                    }
                }
                connection.Close();
            }
        }
    }
}
