namespace SQLModifications.WindowsForms
{
    partial class ViewTable
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtView = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTabele1 = new System.Windows.Forms.ComboBox();
            this.comboBoxTabele2 = new System.Windows.Forms.ComboBox();
            this.btnKreirajView = new System.Windows.Forms.Button();
            this.comboBoxKoloneDrugeTabele = new System.Windows.Forms.ComboBox();
            this.comboBoxKolonePrveTabele = new System.Windows.Forms.ComboBox();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv novokreirane tabele: ";
            // 
            // txtView
            // 
            this.txtView.Location = new System.Drawing.Point(258, 30);
            this.txtView.Name = "txtView";
            this.txtView.Size = new System.Drawing.Size(300, 22);
            this.txtView.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Izaberi tabelu 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(640, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Izaberi tabelu 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kolone prve tabele:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Kolone druge tabele:";
            // 
            // comboBoxTabele1
            // 
            this.comboBoxTabele1.FormattingEnabled = true;
            this.comboBoxTabele1.Location = new System.Drawing.Point(808, 28);
            this.comboBoxTabele1.Name = "comboBoxTabele1";
            this.comboBoxTabele1.Size = new System.Drawing.Size(300, 24);
            this.comboBoxTabele1.TabIndex = 6;
            this.comboBoxTabele1.SelectedIndexChanged += new System.EventHandler(this.comboBoxTabele1_SelectedIndexChanged);
            // 
            // comboBoxTabele2
            // 
            this.comboBoxTabele2.FormattingEnabled = true;
            this.comboBoxTabele2.Location = new System.Drawing.Point(808, 75);
            this.comboBoxTabele2.Name = "comboBoxTabele2";
            this.comboBoxTabele2.Size = new System.Drawing.Size(300, 24);
            this.comboBoxTabele2.TabIndex = 7;
            this.comboBoxTabele2.SelectedIndexChanged += new System.EventHandler(this.comboBoxTabele2_SelectedIndexChanged);
            // 
            // btnKreirajView
            // 
            this.btnKreirajView.Location = new System.Drawing.Point(808, 166);
            this.btnKreirajView.Name = "btnKreirajView";
            this.btnKreirajView.Size = new System.Drawing.Size(300, 52);
            this.btnKreirajView.TabIndex = 10;
            this.btnKreirajView.Text = "Kreiraj view tabelu";
            this.btnKreirajView.UseVisualStyleBackColor = true;
            this.btnKreirajView.Click += new System.EventHandler(this.btnKreirajView_Click);
            // 
            // comboBoxKoloneDrugeTabele
            // 
            this.comboBoxKoloneDrugeTabele.FormattingEnabled = true;
            this.comboBoxKoloneDrugeTabele.Location = new System.Drawing.Point(258, 136);
            this.comboBoxKoloneDrugeTabele.Name = "comboBoxKoloneDrugeTabele";
            this.comboBoxKoloneDrugeTabele.Size = new System.Drawing.Size(300, 24);
            this.comboBoxKoloneDrugeTabele.TabIndex = 9;
            // 
            // comboBoxKolonePrveTabele
            // 
            this.comboBoxKolonePrveTabele.FormattingEnabled = true;
            this.comboBoxKolonePrveTabele.Location = new System.Drawing.Point(258, 82);
            this.comboBoxKolonePrveTabele.Name = "comboBoxKolonePrveTabele";
            this.comboBoxKolonePrveTabele.Size = new System.Drawing.Size(300, 24);
            this.comboBoxKolonePrveTabele.TabIndex = 8;
            // 
            // checkedListBox
            // 
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(42, 208);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(221, 140);
            this.checkedListBox.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(368, 208);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(221, 140);
            this.checkedListBox1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Izaberite kolone tabele 1:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Izaberite kolone tabele 2:";
            // 
            // ViewTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 371);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.btnKreirajView);
            this.Controls.Add(this.comboBoxKoloneDrugeTabele);
            this.Controls.Add(this.comboBoxKolonePrveTabele);
            this.Controls.Add(this.comboBoxTabele2);
            this.Controls.Add(this.comboBoxTabele1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtView);
            this.Controls.Add(this.label1);
            this.Name = "ViewTable";
            this.Text = "ViewTable";
            this.Load += new System.EventHandler(this.ViewTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTabele1;
        private System.Windows.Forms.ComboBox comboBoxTabele2;
        private System.Windows.Forms.Button btnKreirajView;
        private System.Windows.Forms.ComboBox comboBoxKoloneDrugeTabele;
        private System.Windows.Forms.ComboBox comboBoxKolonePrveTabele;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}