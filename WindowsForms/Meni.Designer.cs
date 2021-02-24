namespace SQLModifications
{
    partial class Meni
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
            this.CreateMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.columnToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.columnToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escalationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateMenuStrip1
            // 
            this.CreateMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CreateMenuStrip1.Name = "CreateMenuStrip1";
            this.CreateMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.CreateMenuStrip1.Text = "Create";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.tableToolStripMenuItem,
            this.columnToolStripMenuItem,
            this.viewTableToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 100);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.tableToolStripMenuItem.Text = "Table";
            // 
            // columnToolStripMenuItem
            // 
            this.columnToolStripMenuItem.Name = "columnToolStripMenuItem";
            this.columnToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.columnToolStripMenuItem.Text = "Column";
            // 
            // viewTableToolStripMenuItem
            // 
            this.viewTableToolStripMenuItem.Name = "viewTableToolStripMenuItem";
            this.viewTableToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.viewTableToolStripMenuItem.Text = "View table";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem1,
            this.updateToolStripMenuItem,
            this.escalationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(799, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createToolStripMenuItem1
            // 
            this.createToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem1,
            this.columnToolStripMenuItem1,
            this.viewTableToolStripMenuItem1});
            this.createToolStripMenuItem1.Name = "createToolStripMenuItem1";
            this.createToolStripMenuItem1.Size = new System.Drawing.Size(66, 24);
            this.createToolStripMenuItem1.Text = "Create";
            // 
            // tableToolStripMenuItem1
            // 
            this.tableToolStripMenuItem1.Name = "tableToolStripMenuItem1";
            this.tableToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.tableToolStripMenuItem1.Text = "Table";
            this.tableToolStripMenuItem1.Click += new System.EventHandler(this.tableToolStripMenuItem1_Click);
            // 
            // columnToolStripMenuItem1
            // 
            this.columnToolStripMenuItem1.Name = "columnToolStripMenuItem1";
            this.columnToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.columnToolStripMenuItem1.Text = "Column";
            this.columnToolStripMenuItem1.Click += new System.EventHandler(this.columnToolStripMenuItem1_Click);
            // 
            // viewTableToolStripMenuItem1
            // 
            this.viewTableToolStripMenuItem1.Name = "viewTableToolStripMenuItem1";
            this.viewTableToolStripMenuItem1.Size = new System.Drawing.Size(162, 26);
            this.viewTableToolStripMenuItem1.Text = "View table";
            this.viewTableToolStripMenuItem1.Click += new System.EventHandler(this.viewTableToolStripMenuItem1_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem2,
            this.columnToolStripMenuItem2,
            this.viewToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // tableToolStripMenuItem2
            // 
            this.tableToolStripMenuItem2.Name = "tableToolStripMenuItem2";
            this.tableToolStripMenuItem2.Size = new System.Drawing.Size(143, 26);
            this.tableToolStripMenuItem2.Text = "Table";
            this.tableToolStripMenuItem2.Click += new System.EventHandler(this.tableToolStripMenuItem2_Click);
            // 
            // columnToolStripMenuItem2
            // 
            this.columnToolStripMenuItem2.Name = "columnToolStripMenuItem2";
            this.columnToolStripMenuItem2.Size = new System.Drawing.Size(143, 26);
            this.columnToolStripMenuItem2.Text = "Column";
            this.columnToolStripMenuItem2.Click += new System.EventHandler(this.columnToolStripMenuItem2_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // escalationToolStripMenuItem
            // 
            this.escalationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem2});
            this.escalationToolStripMenuItem.Name = "escalationToolStripMenuItem";
            this.escalationToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.escalationToolStripMenuItem.Text = "Escalation";
            // 
            // createToolStripMenuItem2
            // 
            this.createToolStripMenuItem2.Name = "createToolStripMenuItem2";
            this.createToolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.createToolStripMenuItem2.Text = "Create";
            this.createToolStripMenuItem2.Click += new System.EventHandler(this.createToolStripMenuItem2_Click);
            // 
            // Meni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 330);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Meni";
            this.Text = "Meni";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CreateMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTableToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem columnToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewTableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tableToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem columnToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escalationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem2;
    }
}

