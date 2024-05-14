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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public int Age { get; set; }
        public string isAdmin { get; set; }
        // Możesz dodać więcej właściwości zależnie od potrzeb
    }
}
