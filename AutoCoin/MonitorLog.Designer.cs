namespace AutoCoin
{
    partial class MonitorLog
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
            this.panGraphic = new System.Windows.Forms.Panel();
            this.lbStart = new System.Windows.Forms.Label();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panGraphic.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panGraphic
            // 
            this.panGraphic.Controls.Add(this.lbStart);
            this.panGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panGraphic.Location = new System.Drawing.Point(0, 0);
            this.panGraphic.Name = "panGraphic";
            this.panGraphic.Size = new System.Drawing.Size(1351, 599);
            this.panGraphic.TabIndex = 4;
            // 
            // lbStart
            // 
            this.lbStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStart.AutoSize = true;
            this.lbStart.Location = new System.Drawing.Point(81, 514);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(29, 13);
            this.lbStart.TabIndex = 0;
            this.lbStart.Text = "Start";
            this.lbStart.Visible = false;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRefresh});
            this.cmsMenu.Name = "cmsConfigMonitor";
            this.cmsMenu.Size = new System.Drawing.Size(114, 26);
            // 
            // cmsRefresh
            // 
            this.cmsRefresh.Name = "cmsRefresh";
            this.cmsRefresh.Size = new System.Drawing.Size(113, 22);
            this.cmsRefresh.Text = "Refresh";
            this.cmsRefresh.Click += new System.EventHandler(this.cmsRefresh_Click);
            // 
            // MonitorLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmsMenu;
            this.Controls.Add(this.panGraphic);
            this.Name = "MonitorLog";
            this.Size = new System.Drawing.Size(1351, 599);
            this.Load += new System.EventHandler(this.MonitorLog_Load);
            this.panGraphic.ResumeLayout(false);
            this.panGraphic.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panGraphic;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem cmsRefresh;
        private System.Windows.Forms.Label lbStart;
    }
}