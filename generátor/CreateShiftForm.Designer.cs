namespace generátor
{
    partial class CreateShiftForm
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
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.numericUpDownShiftLength = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.btnCreateShift = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftLength)).BeginInit();
            this.SuspendLayout();
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(48, 31);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(213, 20);
            this.txtShiftName.TabIndex = 0;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(57, 90);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // numericUpDownShiftLength
            // 
            this.numericUpDownShiftLength.Location = new System.Drawing.Point(57, 282);
            this.numericUpDownShiftLength.Name = "numericUpDownShiftLength";
            this.numericUpDownShiftLength.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownShiftLength.TabIndex = 2;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerStart.Location = new System.Drawing.Point(57, 323);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStart.TabIndex = 3;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(284, 323);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.ShowUpDown = true;
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEnd.TabIndex = 4;
            // 
            // btnCreateShift
            // 
            this.btnCreateShift.Location = new System.Drawing.Point(638, 390);
            this.btnCreateShift.Name = "btnCreateShift";
            this.btnCreateShift.Size = new System.Drawing.Size(92, 23);
            this.btnCreateShift.TabIndex = 5;
            this.btnCreateShift.Text = "Vytvořit směnu";
            this.btnCreateShift.UseVisualStyleBackColor = true;
            this.btnCreateShift.Click += new System.EventHandler(this.btnCreateShift_Click);
            // 
            // CreateShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateShift);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.numericUpDownShiftLength);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.txtShiftName);
            this.Name = "CreateShiftForm";
            this.Text = "CreateShiftForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.NumericUpDown numericUpDownShiftLength;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button btnCreateShift;
    }
}