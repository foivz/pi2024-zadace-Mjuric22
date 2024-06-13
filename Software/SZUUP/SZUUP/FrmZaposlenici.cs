using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZUUP.Models;
using SZUUP.Repozitoris;

namespace SZUUP
{
    public partial class FrmZaposlenici : Form
    {
        public FrmZaposlenici()
        {
            InitializeComponent();
        }

        private void FrmZaposlenici_Load(object sender, EventArgs e)
        {
            ShowZaposlenici();
        }

        private void ShowZaposlenici()
        {
            List<Zaposlenik> zaposlenici = ZaposlenikRepozitorij.GetZaposlenici();
            dgvZaposlenici.DataSource = zaposlenici;
            dgvZaposlenici.Columns["Id_zaposlenika"].DisplayIndex = 0;
            dgvZaposlenici.Columns["KorisnickoIme"].DisplayIndex = 1;
            dgvZaposlenici.Columns["Lozinka"].DisplayIndex = 2;
            dgvZaposlenici.Columns["GodineIskustva"].DisplayIndex = 3;
            dgvZaposlenici.Columns["RadnoMjesto"].DisplayIndex = 4;
        }
    }
}
