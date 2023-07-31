namespace generátor
{
    partial class FormGenerovaniSmen
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Jmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hodnost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PocetHodin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prvosled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kyselka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hlídkař = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zpracovatel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Okrskář = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pomocník = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dozorčí = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNacistData = new System.Windows.Forms.Button();
            this.btnUlozitDoExcelu = new System.Windows.Forms.Button();
            this.BtnGenerovatSluzbyNaCelyMesic = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jmeno,
            this.Hodnost,
            this.PocetHodin,
            this.Prvosled,
            this.Kyselka,
            this.Hlídkař,
            this.Zpracovatel,
            this.Okrskář,
            this.Pomocník,
            this.Dozorčí});
            this.dataGridView1.Location = new System.Drawing.Point(64, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(532, 301);
            this.dataGridView1.TabIndex = 0;
            // 
            // Jmeno
            // 
            this.Jmeno.HeaderText = "Jmeno";
            this.Jmeno.Name = "Jmeno";
            // 
            // Hodnost
            // 
            this.Hodnost.HeaderText = "Hodnost";
            this.Hodnost.Name = "Hodnost";
            // 
            // PocetHodin
            // 
            this.PocetHodin.HeaderText = "Počet hodin v měsíci";
            this.PocetHodin.Name = "PocetHodin";
            // 
            // Prvosled
            // 
            this.Prvosled.HeaderText = "Prvosled";
            this.Prvosled.Name = "Prvosled";
            // 
            // Kyselka
            // 
            this.Kyselka.HeaderText = "Kyselka";
            this.Kyselka.Name = "Kyselka";
            // 
            // Hlídkař
            // 
            this.Hlídkař.HeaderText = "Hlídkař";
            this.Hlídkař.Name = "Hlídkař";
            // 
            // Zpracovatel
            // 
            this.Zpracovatel.HeaderText = "Zpracovatel";
            this.Zpracovatel.Name = "Zpracovatel";
            // 
            // Okrskář
            // 
            this.Okrskář.HeaderText = "Okrskář";
            this.Okrskář.Name = "Okrskář";
            // 
            // Pomocník
            // 
            this.Pomocník.HeaderText = "Pomocník";
            this.Pomocník.Name = "Pomocník";
            // 
            // Dozorčí
            // 
            this.Dozorčí.HeaderText = "Dozorčí";
            this.Dozorčí.Name = "Dozorčí";
            // 
            // btnNacistData
            // 
            this.btnNacistData.Location = new System.Drawing.Point(626, 51);
            this.btnNacistData.Name = "btnNacistData";
            this.btnNacistData.Size = new System.Drawing.Size(75, 23);
            this.btnNacistData.TabIndex = 1;
            this.btnNacistData.Text = "Nacti soubor";
            this.btnNacistData.UseVisualStyleBackColor = true;
            this.btnNacistData.Click += new System.EventHandler(this.btnNacistData_Click);
            // 
            // btnUlozitDoExcelu
            // 
            this.btnUlozitDoExcelu.Location = new System.Drawing.Point(626, 124);
            this.btnUlozitDoExcelu.Name = "btnUlozitDoExcelu";
            this.btnUlozitDoExcelu.Size = new System.Drawing.Size(98, 23);
            this.btnUlozitDoExcelu.TabIndex = 2;
            this.btnUlozitDoExcelu.Text = "Ulož do excelu";
            this.btnUlozitDoExcelu.UseVisualStyleBackColor = true;
            this.btnUlozitDoExcelu.Click += new System.EventHandler(this.btnUlozitDoExcelu_Click);
            // 
            // BtnGenerovatSluzbyNaCelyMesic
            // 
            this.BtnGenerovatSluzbyNaCelyMesic.Location = new System.Drawing.Point(626, 182);
            this.BtnGenerovatSluzbyNaCelyMesic.Name = "BtnGenerovatSluzbyNaCelyMesic";
            this.BtnGenerovatSluzbyNaCelyMesic.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerovatSluzbyNaCelyMesic.TabIndex = 3;
            this.BtnGenerovatSluzbyNaCelyMesic.Text = "button1";
            this.BtnGenerovatSluzbyNaCelyMesic.UseVisualStyleBackColor = true;
            this.BtnGenerovatSluzbyNaCelyMesic.Click += new System.EventHandler(this.BtnGenerovatSluzbyNaCelyMesic_Click);
            // 
            // FormGenerovaniSmen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnGenerovatSluzbyNaCelyMesic);
            this.Controls.Add(this.btnUlozitDoExcelu);
            this.Controls.Add(this.btnNacistData);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormGenerovaniSmen";
            this.Text = "FormGenerovaniSmen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNacistData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jmeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hodnost;
        private System.Windows.Forms.DataGridViewTextBoxColumn PocetHodin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prvosled;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kyselka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hlídkař;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zpracovatel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Okrskář;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pomocník;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dozorčí;
        private System.Windows.Forms.Button btnUlozitDoExcelu;
        private System.Windows.Forms.Button BtnGenerovatSluzbyNaCelyMesic;
    }
}