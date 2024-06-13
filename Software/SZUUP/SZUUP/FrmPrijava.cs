using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZUUP.Repozitoris;

namespace SZUUP
{
    public partial class FrmPrijava : Form
    {
        // Deklaracija varijabli na razini klase
        private string username = "nastavnik";
        private string password = "test";

        public FrmPrijava()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Provjera korisničkih podataka
            var zaposlenik = RepozitorijZaposlenik.GetZaposlenik(username);

            if (zaposlenik != null && zaposlenik.Password == password)
            {
                // Uspješna prijava
                MessageBox.Show("Login successful!");

                // Otvorite MainForm
                MainForm mainForm = new MainForm();
                mainForm.Show();

                // Sakrijte trenutnu formu
                this.Hide();
            }
            else
            {
                // Neuspješna prijava
                MessageBox.Show("Invalid username or password!");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Korisničko ime nije uneseno!", "Problem",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Lozinka nije unesena!", "Problem", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else
            {
                if (txtUsername.Text == username && txtPassword.Text == password)
                {
                    MessageBox.Show("Dobrodošli!", "Prijavljeni ste",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the FrmUnos form
                    frmPopisJela frmPopisJela = new frmPopisJela();
                    frmPopisJela.Show();
                    this.Hide(); // Hide the current login form
                }
                else
                {
                    MessageBox.Show("Krivi podaci!", "Problem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
