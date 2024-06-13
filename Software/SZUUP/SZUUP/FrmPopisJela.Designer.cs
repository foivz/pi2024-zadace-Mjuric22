namespace SZUUP
{
    partial class FrmPopisJela
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvJela = new System.Windows.Forms.DataGridView();
            this.btnDodajJelo = new System.Windows.Forms.Button();
            this.btnUrediJelo = new System.Windows.Forms.Button();
            this.btnObrisiJelo = new System.Windows.Forms.Button();
            this.btnPretraziJelo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJela)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvJela
            // 
            this.dgvJela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvJela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJela.Location = new System.Drawing.Point(24, 24);
            this.dgvJela.Name = "dgvJela";
            this.dgvJela.RowHeadersWidth = 62;
            this.dgvJela.RowTemplate.Height = 28;
            this.dgvJela.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJela.Size = new System.Drawing.Size(1075, 502);
            this.dgvJela.TabIndex = 0;
            this.dgvJela.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPopisJela_CellContentClick);
            // 
            // btnDodajJelo
            // 
            this.btnDodajJelo.Location = new System.Drawing.Point(488, 563);
            this.btnDodajJelo.Name = "btnDodajJelo";
            this.btnDodajJelo.Size = new System.Drawing.Size(146, 43);
            this.btnDodajJelo.TabIndex = 1;
            this.btnDodajJelo.Text = "Dodaj jelo";
            this.btnDodajJelo.UseVisualStyleBackColor = true;
            // 
            // btnUrediJelo
            // 
            this.btnUrediJelo.Location = new System.Drawing.Point(792, 563);
            this.btnUrediJelo.Name = "btnUrediJelo";
            this.btnUrediJelo.Size = new System.Drawing.Size(146, 43);
            this.btnUrediJelo.TabIndex = 2;
            this.btnUrediJelo.Text = "Uredi jelo";
            this.btnUrediJelo.UseVisualStyleBackColor = true;
            // 
            // btnObrisiJelo
            // 
            this.btnObrisiJelo.Location = new System.Drawing.Point(944, 563);
            this.btnObrisiJelo.Name = "btnObrisiJelo";
            this.btnObrisiJelo.Size = new System.Drawing.Size(146, 43);
            this.btnObrisiJelo.TabIndex = 3;
            this.btnObrisiJelo.Text = "Obriši jelo";
            this.btnObrisiJelo.UseVisualStyleBackColor = true;
            // 
            // btnPretraziJelo
            // 
            this.btnPretraziJelo.Location = new System.Drawing.Point(640, 563);
            this.btnPretraziJelo.Name = "btnPretraziJelo";
            this.btnPretraziJelo.Size = new System.Drawing.Size(146, 43);
            this.btnPretraziJelo.TabIndex = 4;
            this.btnPretraziJelo.Text = "Pretraži jelo";
            this.btnPretraziJelo.UseVisualStyleBackColor = true;
            // 
            // FrmPopisJela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 632);
            this.Controls.Add(this.btnPretraziJelo);
            this.Controls.Add(this.btnObrisiJelo);
            this.Controls.Add(this.btnUrediJelo);
            this.Controls.Add(this.btnDodajJelo);
            this.Controls.Add(this.dgvJela);
            this.Name = "FrmPopisJela";
            this.Text = "FrmPopisJela";
            this.Load += new System.EventHandler(this.FrmPopisJela_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJela)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJela;
        private System.Windows.Forms.Button btnDodajJelo;
        private System.Windows.Forms.Button btnUrediJelo;
        private System.Windows.Forms.Button btnObrisiJelo;
        private System.Windows.Forms.Button btnPretraziJelo;
    }
}