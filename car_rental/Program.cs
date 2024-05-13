using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental
{
    internal static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
<<<<<<< HEAD
            Application.Run(new glowna());
=======
            Application.Run(new main_frame());
>>>>>>> 6f4d10743acebb65e4d76d60a09a06a2dd5b7944
=======
            Application.Run(new Form1());
>>>>>>> 6a2f760ad9393813803b81e40ee516e358a4e122
        }
    }
}
