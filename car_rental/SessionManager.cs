using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public int Age { get; set; }
        public string DrivingLicense { get; set; }
        public string isAdmin { get; set; } 
        public bool IsAdmin => this.isAdmin == "Tak";
    }

    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string RegistrationNumber { get; set; }
        public string IsAvailable { get; set; }
    }
}
