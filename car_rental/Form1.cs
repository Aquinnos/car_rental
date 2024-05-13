using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            samochody form = new samochody();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wyporzyczanie form = new wyporzyczanie();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Zwrot form = new Zwrot();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Klient form = new Klient();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }
    }
}
