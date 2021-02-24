namespace SQLModifications.WindowsForms.Update
{
    partial class UpdateTable
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTabele = new System.Windows.Forms.ComboBox();
            this.textBoxNoviNazivTabele = new System.Windows.Forms.TextBox();
            this.btnPromenaNaziva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izaberi tabelu: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unesi novi naziv tabele:";
            // 
            // comboBoxTabele
            // 
            this.comboBoxTabele.FormattingEnabled = true;
            this.comboBoxTabele.Location = new System.Drawing.Point(259, 32);
            this.comboBoxTabele.Name = "comboBoxTabele";
            this.comboBoxTabele.Size = new System.Drawing.Size(291, 24);
            this.comboBoxTabele.TabIndex = 2;
            // 
            // textBoxNoviNazivTabele
            // 
            this.textBoxNoviNazivTabele.Location = new System.Drawing.Point(259, 99);
            this.textBoxNoviNazivTabele.Name = "textBoxNoviNazivTabele";
            this.textBoxNoviNazivTabele.Size = new System.Drawing.Size(291, 22);
            this.textBoxNoviNazivTabele.TabIndex = 3;
            // 
            // btnPromenaNaziva
            // 
            this.btnPromenaNaziva.Location = new System.Drawing.Point(259, 157);
            this.btnPromenaNaziva.Name = "btnPromenaNaziva";
            this.btnPromenaNaziva.Size = new System.Drawing.Size(291, 54);
            this.btnPromenaNaziva.TabIndex = 4;
            this.btnPromenaNaziva.Text = "Promena naziva tabele";
            this.btnPromenaNaziva.UseVisualStyleBackColor = true;
            this.btnPromenaNaziva.Click += new System.EventHandler(this.btnPromenaNaziva_Click);
            // 
            // UpdateTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 227);
            this.Controls.Add(this.btnPromenaNaziva);
            this.Controls.Add(this.textBoxNoviNazivTabele);
            this.Controls.Add(this.comboBoxTabele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateTable";
            this.Text = "UpdateTable";
            this.Load += new System.EventHandler(this.UpdateTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTabele;
        private System.Windows.Forms.TextBox textBoxNoviNazivTabele;
        private System.Windows.Forms.Button btnPromenaNaziva;
    }
}