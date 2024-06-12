namespace SZUUP
{
    partial class frmPopisJela
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
            this.dgvPopis = new System.Windows.Forms.DataGridView();
            this.btnUredi = new System.Windows.Forms.Button();
            this.btnDodajJelo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopis)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPopis
            // 
            this.dgvPopis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopis.Location = new System.Drawing.Point(29, 31);
            this.dgvPopis.Name = "dgvPopis";
            this.dgvPopis.RowHeadersWidth = 62;
            this.dgvPopis.RowTemplate.Height = 28;
            this.dgvPopis.Size = new System.Drawing.Size(734, 297);
            this.dgvPopis.TabIndex = 0;
            this.dgvPopis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPopis_CellContentClick);
            // 
            // btnUredi
            // 
            this.btnUredi.Location = new System.Drawing.Point(29, 374);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(185, 46);
            this.btnUredi.TabIndex = 1;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = true;
            // 
            // btnDodajJelo
            // 
            this.btnDodajJelo.Location = new System.Drawing.Point(255, 374);
            this.btnDodajJelo.Name = "btnDodajJelo";
            this.btnDodajJelo.Size = new System.Drawing.Size(185, 46);
            this.btnDodajJelo.TabIndex = 2;
            this.btnDodajJelo.Text = "Dodaj jelo";
            this.btnDodajJelo.UseVisualStyleBackColor = true;
            // 
            // frmPopisJela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDodajJelo);
            this.Controls.Add(this.btnUredi);
            this.Controls.Add(this.dgvPopis);
            this.Name = "frmPopisJela";
            this.Text = "frmPopisJela";
            this.Load += new System.EventHandler(this.frmPopisJela_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPopis;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.Button btnDodajJelo;
    }
}