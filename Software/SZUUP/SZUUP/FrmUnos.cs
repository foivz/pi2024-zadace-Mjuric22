using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SZUUP.Models;
using SZUUP.Repozitoris;

namespace SZUUP
{
    public partial class FrmUnos : Form
    {
        private Jelo _jeloToEdit;

        public FrmUnos()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmUnos_Load);
            this.cmbKategorija.SelectedIndexChanged += new EventHandler(cmbKategorija_SelectedIndexChanged);
            this.txtDetalji.TextChanged += new EventHandler(txtDetalji_TextChanged);
            this.label3.Click += new EventHandler(label3_Click);
        }

        public FrmUnos(Jelo jelo) : this()
        {
            _jeloToEdit = jelo;
            PopulateFormFields(jelo);
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
                    cmbKategorija.DisplayMember = "NazivKategorije";
                    cmbKategorija.ValueMember = "Id_Kategorija";

                    if (_jeloToEdit != null)
                    {
                        cmbKategorija.SelectedValue = _jeloToEdit.Id_Kategorija;
                    }
                }
                else
                {
                    MessageBox.Show("No categories found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateFormFields(Jelo jelo)
        {
            txtNaziv.Text = jelo.Naziv;
            txtCijena.Text = jelo.Cijena.ToString();
            txtDetalji.Text = jelo.Detalji;
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            try
            {
                // Validacija unosa
                if (!ValidateInput())
                {
                    return;
                }

                var selectedCategory = cmbKategorija.SelectedItem as Kategorija;
                if (selectedCategory == null)
                {
                    MessageBox.Show("Odaberite ispravnu kategoriju jela.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_jeloToEdit == null)
                {
                    _jeloToEdit = new Jelo();
                }

                _jeloToEdit.Id_Kategorija = selectedCategory.Id_Kategorija;
                _jeloToEdit.Naziv = txtNaziv.Text;
                _jeloToEdit.Cijena = float.Parse(txtCijena.Text);
                _jeloToEdit.Detalji = txtDetalji.Text;

                if (_jeloToEdit.Id_jelo == 0)
                {
                    JeloRepozitorij.DodajJelo(_jeloToEdit);
                }
                else
                {
                    JeloRepozitorij.UpdateJelo(_jeloToEdit); // Assuming you have an UpdateJelo method in your repository
                }

                MessageBox.Show("Podaci su uspješno spremljeni.", "Uspjeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Set dialog result to OK to indicate successful save
                this.Close(); // Close the form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cmbKategorija.SelectedItem == null)
            {
                MessageBox.Show("Odaberite kategoriju jela.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Unesite naziv jela.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!float.TryParse(txtCijena.Text, out float cijena) || cijena <= 0)
            {
                MessageBox.Show("Unesite ispravnu cijenu jela.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Ostatku validacije možete dodati prema potrebi (npr. za detalje jela)

            return true;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Odustajete od unosa jela?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cmbKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Add code to handle selected index change if needed
        }

        private void txtDetalji_TextChanged(object sender, EventArgs e)
        {
            // Add code to handle text changed if needed
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Add code to handle label click if needed
        }

        // Ostale event handler metode možete dodati prema potrebi
    }
}
