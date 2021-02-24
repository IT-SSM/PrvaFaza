namespace SQLModifications.WindowsForms
{
    partial class CreateColumn
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxKolona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTipPolja = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAtribut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxTabele
            // 
            this.comboBoxTabele.FormattingEnabled = true;
            this.comboBoxTabele.Location = new System.Drawing.Point(167, 28);
            this.comboBoxTabele.Name = "comboBoxTabele";
            this.comboBoxTabele.Size = new System.Drawing.Size(280, 24);
            this.comboBoxTabele.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Izaberi tabelu: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Naziv kolone:";
            // 
            // textBoxKolona
            // 
            this.textBoxKolona.Location = new System.Drawing.Point(167, 102);
            this.textBoxKolona.Name = "textBoxKolona";
            this.textBoxKolona.Size = new System.Drawing.Size(280, 22);
            this.textBoxKolona.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tip polja:";
            // 
            // comboBoxTipPolja
            // 
            this.comboBoxTipPolja.FormattingEnabled = true;
            this.comboBoxTipPolja.Location = new System.Drawing.Point(167, 172);
            this.comboBoxTipPolja.Name = "comboBoxTipPolja";
            this.comboBoxTipPolja.Size = new System.Drawing.Size(280, 24);
            this.comboBoxTipPolja.TabIndex = 5;
            this.comboBoxTipPolja.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipPolja_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 66);
            this.button1.TabIndex = 6;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duzina karaktera:";
            this.label4.Visible = false;
            // 
            // textBoxAtribut
            // 
            this.textBoxAtribut.Location = new System.Drawing.Point(167, 237);
            this.textBoxAtribut.Name = "textBoxAtribut";
            this.textBoxAtribut.Size = new System.Drawing.Size(280, 22);
            this.textBoxAtribut.TabIndex = 8;
            this.textBoxAtribut.Visible = false;
            // 
            // CreateColumn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 450);
            this.Controls.Add(this.textBoxAtribut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxTipPolja);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxKolona);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTabele);
            this.Name = "CreateColumn";
            this.Text = "CreateColumn";
            this.Load += new System.EventHandler(this.CreateColumn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTabele;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxKolona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTipPolja;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAtribut;
    }
}