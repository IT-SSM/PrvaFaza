namespace SQLModifications.WindowsForms.Escalation
{
    partial class CreateEscalation
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
            this.cmbAssociatedForms = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEscalationType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinutes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboActionType = new System.Windows.Forms.ComboBox();
            this.btnCreateEscalation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Associated Forms:";
            // 
            // cmbAssociatedForms
            // 
            this.cmbAssociatedForms.FormattingEnabled = true;
            this.cmbAssociatedForms.Location = new System.Drawing.Point(209, 29);
            this.cmbAssociatedForms.Name = "cmbAssociatedForms";
            this.cmbAssociatedForms.Size = new System.Drawing.Size(239, 24);
            this.cmbAssociatedForms.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Execution Options:";
            // 
            // comboEscalationType
            // 
            this.comboEscalationType.FormattingEnabled = true;
            this.comboEscalationType.Items.AddRange(new object[] {
            "Time",
            "Interval"});
            this.comboEscalationType.Location = new System.Drawing.Point(209, 81);
            this.comboEscalationType.Name = "comboEscalationType";
            this.comboEscalationType.Size = new System.Drawing.Size(239, 24);
            this.comboEscalationType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Days:";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(269, 128);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(56, 22);
            this.txtDays.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hours:";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(418, 128);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(62, 22);
            this.txtHours.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Minutes:";
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(575, 128);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(69, 22);
            this.txtMinutes.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Run If Qualification:";
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(209, 174);
            this.txtCondition.Multiline = true;
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(435, 63);
            this.txtCondition.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Action:";
            // 
            // comboActionType
            // 
            this.comboActionType.FormattingEnabled = true;
            this.comboActionType.Items.AddRange(new object[] {
            "SetFields",
            "PushFields"});
            this.comboActionType.Location = new System.Drawing.Point(277, 256);
            this.comboActionType.Name = "comboActionType";
            this.comboActionType.Size = new System.Drawing.Size(121, 24);
            this.comboActionType.TabIndex = 13;
            // 
            // btnCreateEscalation
            // 
            this.btnCreateEscalation.Location = new System.Drawing.Point(418, 292);
            this.btnCreateEscalation.Name = "btnCreateEscalation";
            this.btnCreateEscalation.Size = new System.Drawing.Size(226, 64);
            this.btnCreateEscalation.TabIndex = 14;
            this.btnCreateEscalation.Text = "Create Escalation";
            this.btnCreateEscalation.UseVisualStyleBackColor = true;
            // 
            // CreateEscalation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 375);
            this.Controls.Add(this.btnCreateEscalation);
            this.Controls.Add(this.comboActionType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCondition);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMinutes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboEscalationType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAssociatedForms);
            this.Controls.Add(this.label1);
            this.Name = "CreateEscalation";
            this.Text = "Create Escalation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAssociatedForms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEscalationType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMinutes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboActionType;
        private System.Windows.Forms.Button btnCreateEscalation;
    }
}