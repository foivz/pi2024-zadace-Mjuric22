using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SZUUP.Models;
using SZUUP.Repozitoris;

namespace SZUUP
{
    public partial class FrmPopisJela : Form
    {
        private List<Jelo> allJela; // To store all meals

        public FrmPopisJela()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FrmPopisJela_Load);

            // Add event handlers for the buttons
            btnDodajJelo.Click += new EventHandler(this.btnDodajJelo_Click);
            btnPretraziJelo.Click += new EventHandler(this.btnPretraziJelo_Click);
            btnUrediJelo.Click += new EventHandler(this.btnUrediJelo_Click);
            btnObrisiJelo.Click += new EventHandler(this.btnObrisiJelo_Click);
            btnZaposlenici.Click += new EventHandler(this.btnZaposlenici_Click);
            btnSvaJela.Click += new EventHandler(this.btnSvaJela_Click); // Added this line
        }

        private void FrmPopisJela_Load(object sender, EventArgs e)
        {
            ShowJela();
        }

        private void ShowJela()
        {
            allJela = JeloRepozitorij.GetJela(); // Get all meals and store them
            if (allJela != null && allJela.Count > 0)
            {
                dgvJela.DataSource = allJela;
                dgvJela.Columns["Id_jelo"].DisplayIndex = 0;
                dgvJela.Columns["Id_Kategorija"].DisplayIndex = 1;
                dgvJela.Columns["Naziv"].DisplayIndex = 2;
                dgvJela.Columns["Cijena"].DisplayIndex = 3;
                dgvJela.Columns["Detalji"].DisplayIndex = 4;
            }
            // Removed the MessageBox for no data scenario
        }

        private void btnDodajJelo_Click(object sender, EventArgs e)
        {
            FrmUnos frmUnos = new FrmUnos();
            if (frmUnos.ShowDialog() == DialogResult.OK)
            {
                ShowJela(); // Refresh the list of meals
            }
        }

        private void btnPretraziJelo_Click(object sender, EventArgs e)
        {
            string searchQuery = txtPretrazi.Text.Trim();

            if (string.IsNullOrEmpty(searchQuery))
            {
                MessageBox.Show("Unesite naziv jela za pretragu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filteredJela = allJela.Where(j => j.Naziv.Equals(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filteredJela.Count > 0)
            {
                dgvJela.DataSource = filteredJela;
            }
            else
            {
                MessageBox.Show("Jelo nije pronađeno.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSvaJela_Click(object sender, EventArgs e)
        {
            dgvJela.DataSource = allJela; // Reset to show all meals
        }

        private void btnUrediJelo_Click(object sender, EventArgs e)
        {
            if (dgvJela.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite jelo za uređivanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowIndex = dgvJela.SelectedRows[0].Index;
            int selectedJeloId = (int)dgvJela.Rows[selectedRowIndex].Cells["Id_jelo"].Value;

            Jelo selectedJelo = JeloRepozitorij.GetJelo(selectedJeloId);

            using (FrmUnos frmUnos = new FrmUnos(selectedJelo))
            {
                if (frmUnos.ShowDialog() == DialogResult.OK)
                {
                    ShowJela(); // Refresh the list after editing
                }
            }
        }

        private void btnObrisiJelo_Click(object sender, EventArgs e)
        {
            if (dgvJela.SelectedRows.Count == 0)
            {
                MessageBox.Show("Odaberite jelo za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedRowIndex = dgvJela.SelectedRows[0].Index;
            int selectedJeloId = (int)dgvJela.Rows[selectedRowIndex].Cells["Id_jelo"].Value;

            var result = MessageBox.Show("Jeste li sigurni da želite obrisati odabrano jelo?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                JeloRepozitorij.ObrisiJelo(selectedJeloId);
                ShowJela(); // Refresh the list after deletion
            }
        }

        private void dgvPopisJela_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }

        private void FrmPopisJela_Load_1(object sender, EventArgs e)
        {
            // Handle form load event if needed
        }

        private void btnZaposlenici_Click(object sender, EventArgs e)
        {
            FrmZaposlenici frmZaposlenici = new FrmZaposlenici();
            frmZaposlenici.ShowDialog();
        }
    }
}
