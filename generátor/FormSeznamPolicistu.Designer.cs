namespace generátor
{
    partial class FormSeznamPolicistu
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Jmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hodnost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formSeznamPolicistuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formSeznamPolicistuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnUlozitZmeny = new System.Windows.Forms.Button();
            this.btnNacistData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formSeznamPolicistuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formSeznamPolicistuBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Jmeno,
            this.Hodnost,
            this.Role});
            this.dataGridView1.Location = new System.Drawing.Point(84, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(930, 364);
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
            // Role
            // 
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            this.Role.Width = 54;
            // 
            // formSeznamPolicistuBindingSource
            // 
            this.formSeznamPolicistuBindingSource.DataSource = this.formSeznamPolicistuBindingSource1;
            // 
            // formSeznamPolicistuBindingSource1
            // 
            this.formSeznamPolicistuBindingSource1.DataSource = typeof(generátor.FormSeznamPolicistu);
            // 
            // btnUlozitZmeny
            // 
            this.btnUlozitZmeny.Location = new System.Drawing.Point(1067, 392);
            this.btnUlozitZmeny.Name = "btnUlozitZmeny";
            this.btnUlozitZmeny.Size = new System.Drawing.Size(75, 23);
            this.btnUlozitZmeny.TabIndex = 2;
            this.btnUlozitZmeny.Text = "Uložit";
            this.btnUlozitZmeny.UseVisualStyleBackColor = true;
            this.btnUlozitZmeny.Click += new System.EventHandler(this.btnUlozitZmeny_Click);
            // 
            // btnNacistData
            // 
            this.btnNacistData.Location = new System.Drawing.Point(1178, 392);
            this.btnNacistData.Name = "btnNacistData";
            this.btnNacistData.Size = new System.Drawing.Size(75, 23);
            this.btnNacistData.TabIndex = 3;
            this.btnNacistData.Text = "Načíst";
            this.btnNacistData.UseVisualStyleBackColor = true;
            this.btnNacistData.Click += new System.EventHandler(this.btnNacistData_Click);
            // 
            // FormSeznamPolicistu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 450);
            this.Controls.Add(this.btnNacistData);
            this.Controls.Add(this.btnUlozitZmeny);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSeznamPolicistu";
            this.Text = "FormSeznamPolicistu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formSeznamPolicistuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formSeznamPolicistuBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUlozitZmeny;
        private System.Windows.Forms.Button btnNacistData;
        private System.Windows.Forms.BindingSource formSeznamPolicistuBindingSource;
        private System.Windows.Forms.BindingSource formSeznamPolicistuBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jmeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hodnost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
    }
}