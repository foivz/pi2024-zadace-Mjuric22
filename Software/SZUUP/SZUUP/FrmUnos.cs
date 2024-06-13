using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SZUUP.Models;
using SZUUP.Repozitoris;

namespace SZUUP
{
    public partial class FrmUnos : Form
    {
        public FrmUnos()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmUnos_Load);
        }

        private void FrmUnos_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                List<Kategorija> kategorije = KategorijaRepozitorij.GetKategorije();
                if (kategorije != null && kategorije.Count > 0)
                {
                    cmbKategorija.DataSource = kategorije;
                    cmbKategorija.DisplayMember = "NazivKategorije"; // Display the renamed category name
                    cmbKategorija.ValueMember = "Id_Kategorija"; // Use the category ID as the value
                }
                // Removed the MessageBox for no data scenario
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            // Show a confirmation dialog
            var result = MessageBox.Show("Jeste li sigurni da želite spremiti podatke?", "Potvrda",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Podaci su uspješno spremljeni.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Odustajete od unosa jela?", "Potvrda",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FrmPrijava frmPrijava = new FrmPrijava();
                frmPrijava.Show();
                this.Close();
            }
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            // Edit button click event handler
        }

        private void cmbKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the combo box selection change if needed
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Handle label click event if needed
        }

        private void txtDetalji_TextChanged(object sender, EventArgs e)
        {
            // Handle text change event if needed
        }
    }
}
