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
            this.label8 = new System.Windows.Forms.Label();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.btnRunEscalation = new System.Windows.Forms.Button();
            this.lblDaysOfWeek = new System.Windows.Forms.Label();
            this.cmbDaysOfWeek = new System.Windows.Forms.ComboBox();
            this.mntCalendar = new System.Windows.Forms.MonthCalendar();
            this.txtMessage = new System.Windows.Forms.TextBox();
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
            "Timer",
            "Interval"});
            this.comboEscalationType.Location = new System.Drawing.Point(209, 81);
            this.comboEscalationType.Name = "comboEscalationType";
            this.comboEscalationType.Size = new System.Drawing.Size(239, 24);
            this.comboEscalationType.TabIndex = 3;
            this.comboEscalationType.SelectedIndexChanged += new System.EventHandler(this.comboEscalationType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Days:";
            this.label3.Visible = false;
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(276, 159);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(69, 22);
            this.txtDays.TabIndex = 5;
            this.txtDays.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hours:";
            this.label4.Visible = false;
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(276, 203);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(69, 22);
            this.txtHours.TabIndex = 7;
            this.txtHours.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Minutes:";
            this.label5.Visible = false;
            // 
            // txtMinutes
            // 
            this.txtMinutes.Location = new System.Drawing.Point(483, 176);
            this.txtMinutes.Name = "txtMinutes";
            this.txtMinutes.Size = new System.Drawing.Size(69, 22);
            this.txtMinutes.TabIndex = 9;
            this.txtMinutes.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Run If Qualification:";
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(209, 289);
            this.txtCondition.Multiline = true;
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(538, 63);
            this.txtCondition.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(444, 364);
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
            this.comboActionType.Location = new System.Drawing.Point(523, 361);
            this.comboActionType.Name = "comboActionType";
            this.comboActionType.Size = new System.Drawing.Size(121, 24);
            this.comboActionType.TabIndex = 13;
            // 
            // btnCreateEscalation
            // 
            this.btnCreateEscalation.Location = new System.Drawing.Point(298, 500);
            this.btnCreateEscalation.Name = "btnCreateEscalation";
            this.btnCreateEscalation.Size = new System.Drawing.Size(239, 64);
            this.btnCreateEscalation.TabIndex = 14;
            this.btnCreateEscalation.Text = "Create Escalation";
            this.btnCreateEscalation.UseVisualStyleBackColor = true;
            this.btnCreateEscalation.Click += new System.EventHandler(this.btnCreateEscalation_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 437);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Condition for Action:";
            // 
            // txtAction
            // 
            this.txtAction.Location = new System.Drawing.Point(209, 404);
            this.txtAction.Multiline = true;
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(538, 76);
            this.txtAction.TabIndex = 17;
            // 
            // btnRunEscalation
            // 
            this.btnRunEscalation.Location = new System.Drawing.Point(614, 500);
            this.btnRunEscalation.Name = "btnRunEscalation";
            this.btnRunEscalation.Size = new System.Drawing.Size(239, 64);
            this.btnRunEscalation.TabIndex = 18;
            this.btnRunEscalation.Text = "Run Escalation";
            this.btnRunEscalation.UseVisualStyleBackColor = true;
            this.btnRunEscalation.Click += new System.EventHandler(this.btnRunEscalation_Click);
            // 
            // lblDaysOfWeek
            // 
            this.lblDaysOfWeek.AutoSize = true;
            this.lblDaysOfWeek.Location = new System.Drawing.Point(206, 124);
            this.lblDaysOfWeek.Name = "lblDaysOfWeek";
            this.lblDaysOfWeek.Size = new System.Drawing.Size(100, 17);
            this.lblDaysOfWeek.TabIndex = 19;
            this.lblDaysOfWeek.Text = "Days of Week:";
            this.lblDaysOfWeek.Visible = false;
            // 
            // cmbDaysOfWeek
            // 
            this.cmbDaysOfWeek.FormattingEnabled = true;
            this.cmbDaysOfWeek.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbDaysOfWeek.Location = new System.Drawing.Point(326, 117);
            this.cmbDaysOfWeek.Name = "cmbDaysOfWeek";
            this.cmbDaysOfWeek.Size = new System.Drawing.Size(141, 24);
            this.cmbDaysOfWeek.TabIndex = 20;
            this.cmbDaysOfWeek.Visible = false;
            // 
            // mntCalendar
            // 
            this.mntCalendar.Location = new System.Drawing.Point(591, 19);
            this.mntCalendar.Name = "mntCalendar";
            this.mntCalendar.TabIndex = 21;
            this.mntCalendar.Visible = false;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(409, 238);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(444, 37);
            this.txtMessage.TabIndex = 22;
            this.txtMessage.Visible = false;
            // 
            // CreateEscalation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 604);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.mntCalendar);
            this.Controls.Add(this.cmbDaysOfWeek);
            this.Controls.Add(this.lblDaysOfWeek);
            this.Controls.Add(this.btnRunEscalation);
            this.Controls.Add(this.txtAction);
            this.Controls.Add(this.label8);
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
            this.Load += new System.EventHandler(this.CreateEscalation_Load);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.Button btnRunEscalation;
        private System.Windows.Forms.Label lblDaysOfWeek;
        private System.Windows.Forms.ComboBox cmbDaysOfWeek;
        private System.Windows.Forms.MonthCalendar mntCalendar;
        private System.Windows.Forms.TextBox txtMessage;
    }
}