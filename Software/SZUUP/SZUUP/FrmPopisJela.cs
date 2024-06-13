using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SZUUP.Models;
using SZUUP.Repozitoris;

namespace SZUUP
{
    public partial class FrmPopisJela : Form
    {
        public FrmPopisJela()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FrmPopisJela_Load);

            // Add event handlers for the buttons
            btnDodajJelo.Click += new EventHandler(this.btnDodajJelo_Click);
            btnPretraziJelo.Click += new EventHandler(this.btnPretraziJelo_Click);
            btnUrediJelo.Click += new EventHandler(this.btnUrediJelo_Click);
            btnObrisiJelo.Click += new EventHandler(this.btnObrisiJelo_Click);
        }

        private void FrmPopisJela_Load(object sender, EventArgs e)
        {
            ShowJela();
        }

        private void ShowJela()
        {
            List<Jelo> jela = JeloRepozitorij.GetJela();
            if (jela != null && jela.Count > 0)
            {
                dgvJela.DataSource = jela;
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

            bool found = false;
            foreach (DataGridViewRow row in dgvJela.Rows)
            {
                if (row.Cells["Naziv"].Value != null && row.Cells["Naziv"].Value.ToString().Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvJela.FirstDisplayedScrollingRowIndex = row.Index; // Scroll to the selected row
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Jelo nije pronađeno.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
    }
}
