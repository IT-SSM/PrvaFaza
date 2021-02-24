namespace SQLModifications.WindowsForms.Update
{
    partial class UpdateView
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
            this.cmbAllViews = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.clbLabel2 = new System.Windows.Forms.Label();
            this.clbLabel1 = new System.Windows.Forms.Label();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.btnUpdateView = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAllViews
            // 
            this.cmbAllViews.FormattingEnabled = true;
            this.cmbAllViews.Location = new System.Drawing.Point(284, 21);
            this.cmbAllViews.Name = "cmbAllViews";
            this.cmbAllViews.Size = new System.Drawing.Size(218, 24);
            this.cmbAllViews.TabIndex = 3;
            this.cmbAllViews.SelectedIndexChanged += new System.EventHandler(this.cmbAllViews_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Update View which you want to update:";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView.Location = new System.Drawing.Point(27, 61);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(652, 275);
            this.dataGridView.TabIndex = 4;
            // 
            // clbLabel2
            // 
            this.clbLabel2.AutoSize = true;
            this.clbLabel2.Location = new System.Drawing.Point(744, 178);
            this.clbLabel2.Name = "clbLabel2";
            this.clbLabel2.Size = new System.Drawing.Size(170, 17);
            this.clbLabel2.TabIndex = 12;
            this.clbLabel2.Text = "Columns of Second Table";
            // 
            // clbLabel1
            // 
            this.clbLabel1.AutoSize = true;
            this.clbLabel1.Location = new System.Drawing.Point(744, 9);
            this.clbLabel1.Name = "clbLabel1";
            this.clbLabel1.Size = new System.Drawing.Size(149, 17);
            this.clbLabel1.TabIndex = 11;
            this.clbLabel1.Text = "Columns of First Table";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(747, 208);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(279, 157);
            this.checkedListBox2.TabIndex = 10;
            // 
            // btnUpdateView
            // 
            this.btnUpdateView.Location = new System.Drawing.Point(747, 390);
            this.btnUpdateView.Name = "btnUpdateView";
            this.btnUpdateView.Size = new System.Drawing.Size(279, 51);
            this.btnUpdateView.TabIndex = 9;
            this.btnUpdateView.Text = "Update View";
            this.btnUpdateView.UseVisualStyleBackColor = true;
            this.btnUpdateView.Click += new System.EventHandler(this.btnUpdateView_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(747, 35);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(279, 140);
            this.checkedListBox1.TabIndex = 8;
            // 
            // UpdateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 462);
            this.Controls.Add(this.clbLabel2);
            this.Controls.Add(this.clbLabel1);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.btnUpdateView);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.cmbAllViews);
            this.Controls.Add(this.label1);
            this.Name = "UpdateView";
            this.Text = "UpdateView";
            this.Load += new System.EventHandler(this.UpdateView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAllViews;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label clbLabel2;
        private System.Windows.Forms.Label clbLabel1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button btnUpdateView;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}