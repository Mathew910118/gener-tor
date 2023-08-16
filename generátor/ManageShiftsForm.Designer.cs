namespace generátor
{
    partial class ManageShiftsForm
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.clbPolicists = new System.Windows.Forms.CheckedListBox();
            this.btnCreateShift = new System.Windows.Forms.Button();
            this.lstShifts = new System.Windows.Forms.ListBox();
            this.btnDeleteShift = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditShift = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(45, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // clbPolicists
            // 
            this.clbPolicists.FormattingEnabled = true;
            this.clbPolicists.Location = new System.Drawing.Point(45, 77);
            this.clbPolicists.Name = "clbPolicists";
            this.clbPolicists.Size = new System.Drawing.Size(191, 199);
            this.clbPolicists.TabIndex = 1;
            this.clbPolicists.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbPolicists_ItemCheck);
            // 
            // btnCreateShift
            // 
            this.btnCreateShift.Location = new System.Drawing.Point(278, 298);
            this.btnCreateShift.Name = "btnCreateShift";
            this.btnCreateShift.Size = new System.Drawing.Size(59, 36);
            this.btnCreateShift.TabIndex = 2;
            this.btnCreateShift.Text = "vytvořit směnu";
            this.btnCreateShift.UseVisualStyleBackColor = true;
            this.btnCreateShift.Click += new System.EventHandler(this.btnCreateShift_Click);
            // 
            // lstShifts
            // 
            this.lstShifts.FormattingEnabled = true;
            this.lstShifts.Location = new System.Drawing.Point(278, 77);
            this.lstShifts.Name = "lstShifts";
            this.lstShifts.Size = new System.Drawing.Size(187, 199);
            this.lstShifts.TabIndex = 3;
            // 
            // btnDeleteShift
            // 
            this.btnDeleteShift.Location = new System.Drawing.Point(343, 298);
            this.btnDeleteShift.Name = "btnDeleteShift";
            this.btnDeleteShift.Size = new System.Drawing.Size(59, 36);
            this.btnDeleteShift.TabIndex = 4;
            this.btnDeleteShift.Text = "Smazat směnu";
            this.btnDeleteShift.UseVisualStyleBackColor = true;
            this.btnDeleteShift.Click += new System.EventHandler(this.btnDeleteShift_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "vyhledávaní policistů";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Seznam policistů";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seznam vytvořených služeb";
            // 
            // btnEditShift
            // 
            this.btnEditShift.Location = new System.Drawing.Point(409, 298);
            this.btnEditShift.Name = "btnEditShift";
            this.btnEditShift.Size = new System.Drawing.Size(56, 36);
            this.btnEditShift.TabIndex = 8;
            this.btnEditShift.Text = "Upravit směnu";
            this.btnEditShift.UseVisualStyleBackColor = true;
            this.btnEditShift.Click += new System.EventHandler(this.btnEditShift_Click);
            // 
            // ManageShiftsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEditShift);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteShift);
            this.Controls.Add(this.lstShifts);
            this.Controls.Add(this.btnCreateShift);
            this.Controls.Add(this.clbPolicists);
            this.Controls.Add(this.txtSearch);
            this.Name = "ManageShiftsForm";
            this.Text = "ManageShiftsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckedListBox clbPolicists;
        private System.Windows.Forms.Button btnCreateShift;
        private System.Windows.Forms.ListBox lstShifts;
        private System.Windows.Forms.Button btnDeleteShift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditShift;
    }
}