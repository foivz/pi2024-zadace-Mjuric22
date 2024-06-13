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
        private string predefinedUsername = "nastavnik";
        private string predefinedPassword = "test";

        public FrmPrijava()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Pretpostavimo da je username zapravo ID koji je integer
            if (int.TryParse(username, out int userId))
            {
                // Provjera korisničkih podataka
                var zaposlenik = ZaposlenikRepozitorij.GetZaposlenik(userId);

                if (zaposlenik != null && zaposlenik.Lozinka == password)
                {
                    // Uspješna prijava
                    MessageBox.Show("Login successful!");

                    // Otvorite FrmZaposlenici formu
                    FrmZaposlenici frmZaposlenici = new FrmZaposlenici();
                    frmZaposlenici.Show();

                    // Sakrijte trenutnu formu
                    this.Hide();
                }
                else
                {
                    // Neuspješna prijava
                    MessageBox.Show("Invalid username or password!");
                }
            }
            else
            {
                MessageBox.Show("Invalid username format! Username should be a number.");
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
                if (txtUsername.Text == predefinedUsername && txtPassword.Text == predefinedPassword)
                {
                    MessageBox.Show("Dobrodošli!", "Prijavljeni ste",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Otvorite FrmZaposlenici formu
                    FrmZaposlenici frmZaposlenici = new FrmZaposlenici();
                    frmZaposlenici.Show();
                    this.Hide(); // Sakrijte trenutnu formu za prijavu
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
