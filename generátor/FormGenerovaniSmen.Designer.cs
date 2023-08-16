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
            this.prvosled1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kyselka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kyselka1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dozorčí = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dozorčí1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zpracovatel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Okrskář = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pomocník = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hlídkař = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ostatni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zbyvajici = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNacistData = new System.Windows.Forms.Button();
            this.btnUlozitDoExcelu = new System.Windows.Forms.Button();
            this.BtnGenerovatSluzbyNaCelyMesic = new System.Windows.Forms.Button();
            this.btnManageShifts = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jmeno,
            this.Hodnost,
            this.PocetHodin,
            this.Prvosled,
            this.prvosled1,
            this.Kyselka,
            this.kyselka1,
            this.Dozorčí,
            this.Dozorčí1,
            this.Zpracovatel,
            this.Okrskář,
            this.Pomocník,
            this.Hlídkař,
            this.ostatni,
            this.zbyvajici});
            this.dataGridView1.Location = new System.Drawing.Point(64, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1006, 301);
            this.dataGridView1.TabIndex = 0;
            // 
            // Jmeno
            // 
            this.Jmeno.HeaderText = "Jmeno";
            this.Jmeno.Name = "Jmeno";
            this.Jmeno.Width = 63;
            // 
            // Hodnost
            // 
            this.Hodnost.HeaderText = "Hodnost";
            this.Hodnost.Name = "Hodnost";
            this.Hodnost.Width = 72;
            // 
            // PocetHodin
            // 
            this.PocetHodin.HeaderText = "Počet hodin v měsíci";
            this.PocetHodin.Name = "PocetHodin";
            this.PocetHodin.Width = 132;
            // 
            // Prvosled
            // 
            this.Prvosled.HeaderText = "Prvosled denní";
            this.Prvosled.Name = "Prvosled";
            this.Prvosled.Width = 104;
            // 
            // prvosled1
            // 
            this.prvosled1.HeaderText = "Prvosled noční";
            this.prvosled1.Name = "prvosled1";
            this.prvosled1.Width = 104;
            // 
            // Kyselka
            // 
            this.Kyselka.HeaderText = "Kyselka denní";
            this.Kyselka.Name = "Kyselka";
            // 
            // kyselka1
            // 
            this.kyselka1.HeaderText = "Kyselka noční";
            this.kyselka1.Name = "kyselka1";
            // 
            // Dozorčí
            // 
            this.Dozorčí.HeaderText = "Dozorčí denní";
            this.Dozorčí.Name = "Dozorčí";
            this.Dozorčí.Width = 101;
            // 
            // Dozorčí1
            // 
            this.Dozorčí1.HeaderText = "Dozorčí noční";
            this.Dozorčí1.Name = "Dozorčí1";
            this.Dozorčí1.Width = 101;
            // 
            // Zpracovatel
            // 
            this.Zpracovatel.HeaderText = "Zpracovatel";
            this.Zpracovatel.Name = "Zpracovatel";
            this.Zpracovatel.Width = 89;
            // 
            // Okrskář
            // 
            this.Okrskář.HeaderText = "Okrskář";
            this.Okrskář.Name = "Okrskář";
            this.Okrskář.Width = 70;
            // 
            // Pomocník
            // 
            this.Pomocník.HeaderText = "Pomocník";
            this.Pomocník.Name = "Pomocník";
            this.Pomocník.Width = 81;
            // 
            // Hlídkař
            // 
            this.Hlídkař.HeaderText = "Hlídkař";
            this.Hlídkař.Name = "Hlídkař";
            this.Hlídkař.Width = 68;
            // 
            // ostatni
            // 
            this.ostatni.HeaderText = "Ostatní služby";
            this.ostatni.Name = "ostatni";
            this.ostatni.Width = 99;
            // 
            // zbyvajici
            // 
            this.zbyvajici.HeaderText = "Zbývající hodiny";
            this.zbyvajici.Name = "zbyvajici";
            this.zbyvajici.Width = 112;
            // 
            // btnNacistData
            // 
            this.btnNacistData.Location = new System.Drawing.Point(1129, 51);
            this.btnNacistData.Name = "btnNacistData";
            this.btnNacistData.Size = new System.Drawing.Size(75, 23);
            this.btnNacistData.TabIndex = 1;
            this.btnNacistData.Text = "Nacti soubor";
            this.btnNacistData.UseVisualStyleBackColor = true;
            this.btnNacistData.Click += new System.EventHandler(this.btnNacistData_Click);
            // 
            // btnUlozitDoExcelu
            // 
            this.btnUlozitDoExcelu.Location = new System.Drawing.Point(1106, 105);
            this.btnUlozitDoExcelu.Name = "btnUlozitDoExcelu";
            this.btnUlozitDoExcelu.Size = new System.Drawing.Size(98, 23);
            this.btnUlozitDoExcelu.TabIndex = 2;
            this.btnUlozitDoExcelu.Text = "Ulož do excelu";
            this.btnUlozitDoExcelu.UseVisualStyleBackColor = true;
            this.btnUlozitDoExcelu.Click += new System.EventHandler(this.btnUlozitDoExcelu_Click);
            // 
            // BtnGenerovatSluzbyNaCelyMesic
            // 
            this.BtnGenerovatSluzbyNaCelyMesic.Location = new System.Drawing.Point(1129, 159);
            this.BtnGenerovatSluzbyNaCelyMesic.Name = "BtnGenerovatSluzbyNaCelyMesic";
            this.BtnGenerovatSluzbyNaCelyMesic.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerovatSluzbyNaCelyMesic.TabIndex = 3;
            this.BtnGenerovatSluzbyNaCelyMesic.Text = "button1";
            this.BtnGenerovatSluzbyNaCelyMesic.UseVisualStyleBackColor = true;
            this.BtnGenerovatSluzbyNaCelyMesic.Click += new System.EventHandler(this.BtnGenerovatSluzbyNaCelyMesic_Click);
            // 
            // btnManageShifts
            // 
            this.btnManageShifts.Location = new System.Drawing.Point(377, 393);
            this.btnManageShifts.Name = "btnManageShifts";
            this.btnManageShifts.Size = new System.Drawing.Size(75, 23);
            this.btnManageShifts.TabIndex = 4;
            this.btnManageShifts.Text = "button1";
            this.btnManageShifts.UseVisualStyleBackColor = true;
            this.btnManageShifts.Click += new System.EventHandler(this.btnManageShifts_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(1129, 381);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportToExcel.TabIndex = 5;
            this.btnExportToExcel.Text = "button1";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // FormGenerovaniSmen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 442);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.btnManageShifts);
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
        private System.Windows.Forms.Button btnUlozitDoExcelu;
        private System.Windows.Forms.Button BtnGenerovatSluzbyNaCelyMesic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jmeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hodnost;
        private System.Windows.Forms.DataGridViewTextBoxColumn PocetHodin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prvosled;
        private System.Windows.Forms.DataGridViewTextBoxColumn prvosled1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kyselka;
        private System.Windows.Forms.DataGridViewTextBoxColumn kyselka1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dozorčí;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dozorčí1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zpracovatel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Okrskář;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pomocník;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hlídkař;
        private System.Windows.Forms.DataGridViewTextBoxColumn ostatni;
        private System.Windows.Forms.DataGridViewTextBoxColumn zbyvajici;
        private System.Windows.Forms.Button btnManageShifts;
        private System.Windows.Forms.Button btnExportToExcel;
    }
}