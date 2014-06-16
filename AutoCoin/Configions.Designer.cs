namespace AutoCoin
{
    partial class Configions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCopyCoins = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.edtKey = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROFILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCRYPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NFACTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PCID,
            this.PROFILE,
            this.STT,
            this.SCRYPT,
            this.X11,
            this.NFACTOR});
            this.dgv.ContextMenuStrip = this.cmsMenu;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 20);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(876, 350);
            this.dgv.TabIndex = 3;
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.cmsCopyCoins,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.cmsRefresh});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(114, 98);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Visible = false;
            // 
            // cmsCopyCoins
            // 
            this.cmsCopyCoins.Name = "cmsCopyCoins";
            this.cmsCopyCoins.Size = new System.Drawing.Size(113, 22);
            this.cmsCopyCoins.Text = "Copy";
            this.cmsCopyCoins.Click += new System.EventHandler(this.cmsCopyCoins_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.cmsDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // cmsRefresh
            // 
            this.cmsRefresh.Name = "cmsRefresh";
            this.cmsRefresh.Size = new System.Drawing.Size(113, 22);
            this.cmsRefresh.Text = "Refresh";
            this.cmsRefresh.Click += new System.EventHandler(this.cmsRefresh_Click);
            // 
            // edtKey
            // 
            this.edtKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtKey.Location = new System.Drawing.Point(0, 0);
            this.edtKey.Name = "edtKey";
            this.edtKey.Size = new System.Drawing.Size(876, 20);
            this.edtKey.TabIndex = 2;
            this.edtKey.TextChanged += new System.EventHandler(this.edtKey_TextChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // PCID
            // 
            this.PCID.DataPropertyName = "PCID";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PCID.DefaultCellStyle = dataGridViewCellStyle1;
            this.PCID.HeaderText = "PCID";
            this.PCID.Name = "PCID";
            this.PCID.ReadOnly = true;
            this.PCID.Width = 160;
            // 
            // PROFILE
            // 
            this.PROFILE.DataPropertyName = "PROFILE";
            this.PROFILE.HeaderText = "PROFILE";
            this.PROFILE.Name = "PROFILE";
            this.PROFILE.Width = 90;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Snow;
            this.STT.DefaultCellStyle = dataGridViewCellStyle2;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 30;
            // 
            // SCRYPT
            // 
            this.SCRYPT.DataPropertyName = "SCRYPT";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SCRYPT.DefaultCellStyle = dataGridViewCellStyle3;
            this.SCRYPT.HeaderText = "SCRYPT";
            this.SCRYPT.Name = "SCRYPT";
            this.SCRYPT.Width = 400;
            // 
            // X11
            // 
            this.X11.DataPropertyName = "X11";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.X11.DefaultCellStyle = dataGridViewCellStyle4;
            this.X11.HeaderText = "X11";
            this.X11.Name = "X11";
            this.X11.Width = 300;
            // 
            // NFACTOR
            // 
            this.NFACTOR.DataPropertyName = "NFACTOR";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NFACTOR.DefaultCellStyle = dataGridViewCellStyle5;
            this.NFACTOR.HeaderText = "NFACTOR";
            this.NFACTOR.Name = "NFACTOR";
            this.NFACTOR.Width = 300;
            // 
            // Configions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 370);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.edtKey);
            this.Name = "Configions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configions";
            this.Load += new System.EventHandler(this.CONFIGION_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox edtKey;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmsCopyCoins;
        private System.Windows.Forms.ToolStripMenuItem cmsRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROFILE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCRYPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn X11;
        private System.Windows.Forms.DataGridViewTextBoxColumn NFACTOR;
    }
}