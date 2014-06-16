namespace AutoCoin
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.edtUserCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.edtPrefix = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edtConfig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edtPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edtResetValue = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtUserCode
            // 
            this.edtUserCode.Location = new System.Drawing.Point(115, 25);
            this.edtUserCode.Name = "edtUserCode";
            this.edtUserCode.Size = new System.Drawing.Size(119, 20);
            this.edtUserCode.TabIndex = 0;
            this.edtUserCode.TextChanged += new System.EventHandler(this.edtUserCode_TextChanged);
            this.edtUserCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtUserCode_KeyDown);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(409, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // edtPrefix
            // 
            this.edtPrefix.ContextMenuStrip = this.contextMenuStrip1;
            this.edtPrefix.Enabled = false;
            this.edtPrefix.Location = new System.Drawing.Point(603, 272);
            this.edtPrefix.Name = "edtPrefix";
            this.edtPrefix.Size = new System.Drawing.Size(36, 20);
            this.edtPrefix.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDefaultToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 26);
            // 
            // loadDefaultToolStripMenuItem
            // 
            this.loadDefaultToolStripMenuItem.Name = "loadDefaultToolStripMenuItem";
            this.loadDefaultToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.loadDefaultToolStripMenuItem.Text = "Load Default";
            this.loadDefaultToolStripMenuItem.Click += new System.EventHandler(this.loadDefaultToolStripMenuItem_Click);
            // 
            // edtConfig
            // 
            this.edtConfig.ContextMenuStrip = this.contextMenuStrip1;
            this.edtConfig.Enabled = false;
            this.edtConfig.Location = new System.Drawing.Point(603, 293);
            this.edtConfig.Name = "edtConfig";
            this.edtConfig.Size = new System.Drawing.Size(36, 20);
            this.edtConfig.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Account Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Worker Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CGMiner Config";
            // 
            // edtPass
            // 
            this.edtPass.Location = new System.Drawing.Point(115, 50);
            this.edtPass.Name = "edtPass";
            this.edtPass.PasswordChar = '*';
            this.edtPass.Size = new System.Drawing.Size(119, 20);
            this.edtPass.TabIndex = 1;
            this.edtPass.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(19, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(240, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "( Register )";
            this.label4.Click += new System.EventHandler(this.REGISTER);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "AutoRestart Time";
            // 
            // edtResetValue
            // 
            this.edtResetValue.Enabled = false;
            this.edtResetValue.Location = new System.Drawing.Point(603, 313);
            this.edtResetValue.Name = "edtResetValue";
            this.edtResetValue.Size = new System.Drawing.Size(46, 20);
            this.edtResetValue.TabIndex = 12;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 146);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtResetValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtConfig);
            this.Controls.Add(this.edtPrefix);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.edtPass);
            this.Controls.Add(this.edtUserCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.AddUserCode_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtUserCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox edtPrefix;
        private System.Windows.Forms.TextBox edtConfig;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadDefaultToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtResetValue;
    }
}