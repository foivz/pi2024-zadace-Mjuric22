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
        private string unaprijedDefiniranoKorisnickoIme = "nastavnik";
        private string unaprijedDefiniranaLozinka = "test";

        public FrmPrijava()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string korisnickoIme = txtUsername.Text;
            string lozinka = txtPassword.Text;

            // Pretpostavimo da je korisničko ime zapravo ID koji je integer
            if (int.TryParse(korisnickoIme, out int korisnikId))
            {
                // Provjera korisničkih podataka
                var zaposlenik = ZaposlenikRepozitorij.GetZaposlenik(korisnikId);

                if (zaposlenik != null && zaposlenik.Lozinka == lozinka)
                {
                    // Uspješna prijava
                    MessageBox.Show("Prijava uspješna!");

                    // Otvorite FrmPopisJela formu
                    FrmPopisJela frmPopisJela = new FrmPopisJela();
                    frmPopisJela.Show();

                    // Sakrijte trenutnu formu
                    this.Hide();
                }
                else
                {
                    // Neuspješna prijava
                    MessageBox.Show("Neispravno korisničko ime ili lozinka!");
                }
            }
            else
            {
                MessageBox.Show("Neispravan format korisničkog imena! Korisničko ime treba biti broj.");
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
                if (txtUsername.Text == unaprijedDefiniranoKorisnickoIme && txtPassword.Text == unaprijedDefiniranaLozinka)
                {
                    MessageBox.Show("Dobrodošli!", "Prijavljeni ste",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Otvorite FrmPopisJela formu
                    FrmPopisJela frmPopisJela = new FrmPopisJela();
                    frmPopisJela.Show();

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
