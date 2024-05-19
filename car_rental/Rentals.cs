using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental
{
    public partial class Rentals : Form
    {
        public Rentals()
        {
            InitializeComponent();
            refresh();
            FlipPictureBoxHorizontally(guna2PictureBox2);
            Main_frame_Load(panel1);
            Main_frame_Load(panel2);
            ButtonsColor(guna2Button1);
            ButtonsColor(guna2Button2);
            header_color();
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
        public void ButtonsColor(Guna2Button button)
        {
            string hexColor = "#714A4A";
            Color buttonsColor = ColorTranslator.FromHtml(hexColor);
            button.BackColor = buttonsColor;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            main_frame main_frame = new main_frame();
            main_frame.FormClosed += (s, args) => this.Close();
            this.Hide();
            main_frame.Show();
        }

        private string connectionString = "Data Source=database.sqlite;Version=3;";

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
                    guna2DataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }


        private void btnRent_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("Musisz być zalogowany, aby wypożyczyć samochód.");
                return;
            }

            var currentUser = SessionManager.CurrentUser;
            Debug.WriteLine($"PESEL: {currentUser.Pesel}, Age: {currentUser.Age}, Driving License: {currentUser.DrivingLicense}");

            if (string.IsNullOrWhiteSpace(currentUser.Pesel))
            {
                MessageBox.Show("Musisz podać PESEL przed wypożyczeniem samochodu.");
                return;
            }

            if (currentUser.Age < 18)
            {
                MessageBox.Show("Musisz mieć co najmniej 18 lat przed wypożyczeniem samochodu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(currentUser.DrivingLicense))
            {
                MessageBox.Show("Musisz podać numer prawa jazdy przed wypożyczeniem samochodu.");
                return;
            }

            if (!ValidateInputs())
            {
                return;
            }

            Car car = GetCarByRegistrationNumber(Nr_rejs.Text);
            if (car == null)
            {
                MessageBox.Show("Nie znaleziono samochodu o podanym numerze rejestracyjnym.");
                return;
            }

            if (car.IsAvailable != "Tak")
            {
                MessageBox.Show("Samochód jest już wypożyczony.");
                return;
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            RentCar(car, startDate, endDate);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(Nr_rejs.Text))
            {
                MessageBox.Show("Numer rejestracyjny nie może być pusty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Model_aut.Text))
            {
                MessageBox.Show("Model nie może być pusty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Marka_auta.Text))
            {
                MessageBox.Show("Marka nie może być pusta.");
                return false;
            }

            if (!decimal.TryParse(Cena_auta.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Wprowadź poprawną cenę.");
                return false;
            }

            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Data rozpoczęcia rezerwacji musi być wcześniejsza niż data końca rezerwacji.");
                return false;
            }

            return true;
        }

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
                                IsAvailable = reader["IsAvailable"].ToString(),
                                Price = Convert.ToDouble(reader["Price"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        private void RentCar(Car car, DateTime startDate, DateTime endDate)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateCarQuery = "UPDATE Cars SET IsAvailable = 'Nie' WHERE CarId = @CarId";
                        using (var updateCarCommand = new SQLiteCommand(updateCarQuery, connection))
                        {
                            updateCarCommand.Parameters.AddWithValue("@CarId", car.CarId);
                            updateCarCommand.ExecuteNonQuery();
                        }

                        string insertRentalQuery = @"
                    INSERT INTO Rentals (UserId, CarId, StartDate, EndDate)
                    VALUES (@UserId, @CarId, @StartDate, @EndDate)";
                        using (var insertRentalCommand = new SQLiteCommand(insertRentalQuery, connection))
                        {
                            insertRentalCommand.Parameters.AddWithValue("@UserId", SessionManager.CurrentUser.Id);
                            insertRentalCommand.Parameters.AddWithValue("@CarId", car.CarId);
                            insertRentalCommand.Parameters.AddWithValue("@StartDate", startDate);
                            insertRentalCommand.Parameters.AddWithValue("@EndDate", endDate);
                            insertRentalCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Samochód został pomyślnie wypożyczony.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Wystąpił błąd podczas wypożyczania samochodu: " + ex.Message);
                    }
                }
                connection.Close();
            }
        }
    }
}
