using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZUUP
{
    public partial class FrmUnos : Form
    {
        public FrmUnos()
        {
            InitializeComponent();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            var result = MessageBox.Show("Jeste li sigurni da želite spremiti podatke?", "Potvrda",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks "Yes" or "No," do nothing and return to the current form
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Podaci su uspješno spremljeni.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            var result = MessageBox.Show("Odustajete od unosa jela?", "Potvrda",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks "Yes," close the current form and show the login form
            if (result == DialogResult.Yes)
            {
                FrmPrijava frmPrijava = new FrmPrijava();
                frmPrijava.Show();
                this.Close(); // Close the current form
            }
            // If the user clicks "No," do nothing and return to the current form
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            // Edit button click event handler
        }

        private void FrmUnos_Load(object sender, EventArgs e)
        {
            // Form load event handler
        }

        private void cmbKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtDetalji_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
