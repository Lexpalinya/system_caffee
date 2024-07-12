
namespace cafeshopCsharp
{
    partial class frmReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ລາຍງານຍອດຂາຍToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ລາຍງານບນຊToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ລາຍງານຈາຍເງນເດອນToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crystalReportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1630, 1065);
            this.panel1.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1630, 1065);
            this.crystalReportViewer1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1630, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ລາຍງານຍອດຂາຍToolStripMenuItem,
            this.ລາຍງານບນຊToolStripMenuItem,
            this.ລາຍງານຈາຍເງນເດອນToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Phetsarath OT", 14.25F);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(78, 31);
            this.toolStripMenuItem1.Text = "ລາຍງານ";
            // 
            // ລາຍງານຍອດຂາຍToolStripMenuItem
            // 
            this.ລາຍງານຍອດຂາຍToolStripMenuItem.Name = "ລາຍງານຍອດຂາຍToolStripMenuItem";
            this.ລາຍງານຍອດຂາຍToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.ລາຍງານຍອດຂາຍToolStripMenuItem.Text = "ລາຍງານຍອດຂາຍ";
            this.ລາຍງານຍອດຂາຍToolStripMenuItem.Click += new System.EventHandler(this.ລາຍງານຍອດຂາຍToolStripMenuItem_Click);
            // 
            // ລາຍງານບນຊToolStripMenuItem
            // 
            this.ລາຍງານບນຊToolStripMenuItem.Name = "ລາຍງານບນຊToolStripMenuItem";
            this.ລາຍງານບນຊToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.ລາຍງານບນຊToolStripMenuItem.Text = "ລາຍງານບັນຊີ";
            this.ລາຍງານບນຊToolStripMenuItem.Click += new System.EventHandler(this.ລາຍງານບນຊToolStripMenuItem_Click);
            // 
            // ລາຍງານຈາຍເງນເດອນToolStripMenuItem
            // 
            this.ລາຍງານຈາຍເງນເດອນToolStripMenuItem.Name = "ລາຍງານຈາຍເງນເດອນToolStripMenuItem";
            this.ລາຍງານຈາຍເງນເດອນToolStripMenuItem.Size = new System.Drawing.Size(238, 32);
            this.ລາຍງານຈາຍເງນເດອນToolStripMenuItem.Text = "ລາຍງານຈ່າຍເງິນເດືອນ";
            this.ລາຍງານຈາຍເງນເດອນToolStripMenuItem.Click += new System.EventHandler(this.ລາຍງານຈາຍເງນເດອນToolStripMenuItem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Phetsarath OT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Phetsarath OT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(1447, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(171, 35);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1630, 1100);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmReport";
            this.Text = "report";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ລາຍງານຍອດຂາຍToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ລາຍງານບນຊToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ລາຍງານຈາຍເງນເດອນToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}