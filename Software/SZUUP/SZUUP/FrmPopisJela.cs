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
            frmUnos.ShowDialog();
        }

        private void btnPretraziJelo_Click(object sender, EventArgs e)
        {
            // Code to handle search functionality
        }

        private void btnUrediJelo_Click(object sender, EventArgs e)
        {
            // Code to handle edit functionality
        }

        private void btnObrisiJelo_Click(object sender, EventArgs e)
        {
            // Code to handle delete functionality
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
