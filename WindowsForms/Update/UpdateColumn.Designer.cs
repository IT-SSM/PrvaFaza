namespace SQLModifications.WindowsForms.Update
{
    partial class UpdateColumn
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
            this.comboBoxTabele = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonIzmenaNazivaKolone = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxKolone = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNoviNazivKolone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTipKolone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxTabele
            // 
            this.comboBoxTabele.FormattingEnabled = true;
            this.comboBoxTabele.Location = new System.Drawing.Point(220, 51);
            this.comboBoxTabele.Name = "comboBoxTabele";
            this.comboBoxTabele.Size = new System.Drawing.Size(291, 24);
            this.comboBoxTabele.TabIndex = 4;
            this.comboBoxTabele.SelectedIndexChanged += new System.EventHandler(this.comboBoxTabele_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Izaberi tabelu: ";
            // 
            // buttonIzmenaNazivaKolone
            // 
            this.buttonIzmenaNazivaKolone.Location = new System.Drawing.Point(327, 300);
            this.buttonIzmenaNazivaKolone.Name = "buttonIzmenaNazivaKolone";
            this.buttonIzmenaNazivaKolone.Size = new System.Drawing.Size(184, 64);
            this.buttonIzmenaNazivaKolone.TabIndex = 9;
            this.buttonIzmenaNazivaKolone.Text = "Izmeni naziv kolone";
            this.buttonIzmenaNazivaKolone.UseVisualStyleBackColor = true;
            this.buttonIzmenaNazivaKolone.Click += new System.EventHandler(this.buttonIzmenaNazivaKolone_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Izaberi kolonu:";
            // 
            // comboBoxKolone
            // 
            this.comboBoxKolone.FormattingEnabled = true;
            this.comboBoxKolone.Location = new System.Drawing.Point(220, 102);
            this.comboBoxKolone.Name = "comboBoxKolone";
            this.comboBoxKolone.Size = new System.Drawing.Size(291, 24);
            this.comboBoxKolone.TabIndex = 12;
            this.comboBoxKolone.SelectedIndexChanged += new System.EventHandler(this.comboBoxKolone_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Unesi novi naziv kolone:";
            // 
            // textBoxNoviNazivKolone
            // 
            this.textBoxNoviNazivKolone.Location = new System.Drawing.Point(220, 202);
            this.textBoxNoviNazivKolone.Name = "textBoxNoviNazivKolone";
            this.textBoxNoviNazivKolone.Size = new System.Drawing.Size(291, 22);
            this.textBoxNoviNazivKolone.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tip kolone:";
            // 
            // textBoxTipKolone
            // 
            this.textBoxTipKolone.Location = new System.Drawing.Point(220, 155);
            this.textBoxTipKolone.Name = "textBoxTipKolone";
            this.textBoxTipKolone.ReadOnly = true;
            this.textBoxTipKolone.Size = new System.Drawing.Size(291, 22);
            this.textBoxTipKolone.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Izaberi tip polja: ";
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(220, 249);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(291, 24);
            this.comboBoxTypes.TabIndex = 18;
            // 
            // UpdateColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 428);
            this.Controls.Add(this.comboBoxTypes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTipKolone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNoviNazivKolone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxKolone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonIzmenaNazivaKolone);
            this.Controls.Add(this.comboBoxTabele);
            this.Controls.Add(this.label1);
            this.Name = "UpdateColumn";
            this.Text = "UpdateColumn";
            this.Load += new System.EventHandler(this.UpdateColumn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTabele;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonIzmenaNazivaKolone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxKolone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNoviNazivKolone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTipKolone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTypes;
    }
}